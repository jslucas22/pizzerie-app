using Dapper;
using Pizzerie.Data.DbConfig;
using Pizzerie.Data.Repositories.Abstractions;
using Pizzerie.Domain.Models.Application;
using Pizzerie.Domain.Models.EmployeeCheckPad;
using Pizzerie.Domain.Models.GuestCheckPad;
using Pizzerie.Domain.Models.Product;

namespace Pizzerie.Data.Repositories
{
    public class EmployeeCheckPadRepository : IEmployeeCheckPadRepository
    {
        #region ..:: Variables ::..

        private readonly IDatabaseConnectionFactory _connectionFactory;

        #endregion

        #region ..:: Constructor ::..

        public EmployeeCheckPadRepository(IDatabaseConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        #endregion

        public async Task<bool> ExistsOpenOrderForCustomerAsync(string customerName, short tableNumber)
        {
            using var connection = _connectionFactory.GetConnection();
            var openOrderExists = await connection.QueryFirstOrDefaultAsync<bool>(
                "SELECT EXISTS(SELECT 1 FROM orders WHERE customer_name = @CustomerName AND status = 'Open' AND table_number = @TableNumber)",
                new { CustomerName = customerName, TableNumber = tableNumber });

            return openOrderExists;
        }

        public async Task<bool> OrderExistsAsync(Guid orderId)
        {
            using var connection = _connectionFactory.GetConnection();
            var exists = await connection.QueryFirstOrDefaultAsync<bool>(
                "SELECT EXISTS(SELECT 1 FROM orders WHERE id = @OrderId)",
                new { OrderId = orderId });

            return exists;
        }

        public async Task<bool> CanEditOrderAsync(Guid orderId)
        {
            using var connection = _connectionFactory.GetConnection();
            var status = await connection.QueryFirstOrDefaultAsync<string>(
                "SELECT status FROM orders WHERE id = @OrderId",
                new { OrderId = orderId });

            return status == "Open";
        }


        public async Task<ContentResponse> CreateAsync(EmployeeCheckPadCreateRequest? model)
        {
            using var connection = _connectionFactory.GetConnection();
            connection.Open();

            using var transaction = connection.BeginTransaction();
            try
            {
                // check employee exists

                const string orderInsertQuery = @"
                INSERT INTO orders (id, employee_id, table_number, customer_name, total_value, payment_method, status)
                VALUES (@Id, @EmployeeId, @TableNumber, @CustomerName, @TotalValue, @PaymentMethod, @Status)
                RETURNING id;";

                if (model?.Products != null)
                {
                    var totalValue = model.Products.Sum(p => p.Price);
                    var orderId = await connection.QuerySingleAsync<Guid>(orderInsertQuery, new
                    {
                        Id = Guid.NewGuid(),
                        EmployeeId = model.IdEmployee,
                        model.TableNumber,
                        CustomerName = model.ClientName,
                        TotalValue = totalValue,
                        model.PaymentMethod,
                        Status = "Open",
                    }, transaction);

                    foreach (var product in model.Products)
                    {
                        //const string productIdQuery = "SELECT id FROM products WHERE id = @ProductId";
                        //var productId = await connection.QuerySingleOrDefaultAsync<int?>(productIdQuery,
                        //    new { ProductId = product.Id }, transaction);

                        //if (!productId.HasValue)
                        //{
                        //    throw new KeyNotFoundException($"eca-02: Product not found.");
                        //}

                        const string insertQuery = @"
                        INSERT INTO order_items (id, order_id, product_id, quantity)
                        VALUES (@Id, @OrderId, @ProductId, @Quantity);";

                        await connection.ExecuteAsync(insertQuery, new
                        {
                            Id = Guid.NewGuid(),
                            OrderId = orderId,
                            ProductId = product.Id,
                            product.Quantity
                        }, transaction);
                    }
                }

                transaction.Commit();
                return new ContentResponse
                {
                    Message = $"The checkpad was created successfully for client {model?.ClientName}",
                    Success = true
                };
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw;
            }
        }

        public async Task<ContentResponse> DeleteAsync(string idCheckpad, string idEmployee)
        {
            using var connection = _connectionFactory.GetConnection();
            connection.Open();

            using var transaction = connection.BeginTransaction();
            try
            {
                const string validationQuery = @"
                SELECT COUNT(1)
                FROM orders o
                JOIN employees e ON o.employee_id = e.id
                WHERE o.id = @OrderId AND e.id = @EmployeeId;";

                var orderCount = await connection.ExecuteScalarAsync<int>(validationQuery,
                    new { OrderId = Guid.Parse(idCheckpad), EmployeeId = Guid.Parse(idEmployee) }, transaction);

                if (orderCount == 0)
                {
                    throw new KeyNotFoundException("Order or Employee not found.");
                }

                const string deleteOrderItemsQuery =
                    "DELETE FROM order_items WHERE order_id = (SELECT id FROM orders WHERE id = @OrderId);";
                await connection.ExecuteAsync(deleteOrderItemsQuery, new { OrderId = Guid.Parse(idCheckpad) },
                    transaction);

                const string deleteOrderQuery = "DELETE FROM orders WHERE id = @OrderId;";
                await connection.ExecuteAsync(deleteOrderQuery, new { OrderId = Guid.Parse(idCheckpad) },
                    transaction);

                transaction.Commit();

                return new ContentResponse
                {
                    Message = "The checkpad was deleted successfully.",
                    Success = true
                };
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                throw;
            }
        }


        public Task<ContentResponse> EditAsync(Guid idCheckpad, Guid idEmployee, string clientName)
        {
            return Task.FromResult(new ContentResponse
            {
                Message =
                    $"The checkpad with id {idCheckpad} of employee {idEmployee} updated successfully the client payer name for {clientName}",
                Success = true
            });
        }

        public async Task<ContentResponse> EditAsync(EmployeeCheckPadEditRequest model)
        {
            using var connection = _connectionFactory.GetConnection();
            connection.Open();
            using var transaction = connection.BeginTransaction();

            try
            {
                const string orderUpdateQuery = @"
                UPDATE orders
                SET
                    table_number = COALESCE(@TableNumber, table_number),
                    customer_name = COALESCE(@CustomerName, customer_name),
                    payment_method = COALESCE(@PaymentMethod, payment_method),
                    status = COALESCE(@Status, status),
                    note = COALESCE(@Note, note)
                WHERE id = @OrderId RETURNING id;";

                var updatedOrderId = await connection.QueryAsync<Guid>(orderUpdateQuery, new
                {
                    OrderId = model.Id,
                    model.TableNumber,
                    CustomerName = model.ClientName,
                    model.PaymentMethod,
                    model.Status,
                    model.Note
                }, transaction);

                if (model.Products != null)
                    foreach (var product in model.Products)
                    {
                        //const string productIdQuery = "SELECT id FROM products WHERE id = @ProductId";
                        //var productId = await connection.QuerySingleOrDefaultAsync<int?>(productIdQuery,
                        //    new { ProductId = product.Id }, transaction);

                        //if (productId == null)
                        //{
                        //    throw new KeyNotFoundException($"eea-01: Product not found.");
                        //}

                        if (product.Remove)
                        {
                            const string removeProductQuery =
                                "DELETE FROM order_items WHERE order_id = @OrderId AND product_id = @ProductId";
                            await connection.ExecuteAsync(removeProductQuery, new
                            {
                                OrderId = model.Id,
                                ProductId = product.Id
                            }, transaction);
                        }
                        else
                        {
                            const string productExistsQuery =
                                "SELECT 1 FROM order_items WHERE order_id = @OrderId AND product_id = @ProductId";
                            var productExists = await connection.QuerySingleOrDefaultAsync<bool>(productExistsQuery, new
                            {
                                OrderId = model.Id,
                                ProductId = product.Id
                            }, transaction);

                            if (productExists)
                            {
                                const string updateProductQuery = @"
                                UPDATE order_items
                                SET quantity = @Quantity, id_order_status = @IdOrderStatus            
                                WHERE order_id = @OrderId AND product_id = @ProductId";
                                await connection.ExecuteAsync(updateProductQuery, new
                                {
                                    OrderId = model.Id,
                                    ProductId = product.Id,
                                    model.IdOrderStatus,
                                    product.Quantity
                                }, transaction);
                            }
                            else
                            {
                                const string insertProductQuery = @"
                                INSERT INTO order_items (id, order_id, product_id, quantity)
                                VALUES (@Id, @OrderId, @ProductId, @Quantity)";

                                await connection.ExecuteAsync(insertProductQuery, new
                                {
                                    Id = Guid.NewGuid(),
                                    OrderId = model.Id,
                                    ProductId = product.Id,
                                    product.Quantity
                                }, transaction);
                            }
                        }
                    }

                transaction.Commit();
                return new ContentResponse
                {
                    Success = true,
                    Message = "Order updated successfully."
                };
            }
            catch
            {
                transaction.Rollback();
                throw;
            }
        }

        public async Task<IEnumerable<EmployeeCheckPadGetResponse>> GetAsync()
        {
            using var connection = _connectionFactory.GetConnection();

            const string query = @"
            SELECT
                MAX(o.id::text) as id,
                e.name as EmployeeName,
                MAX(o.customer_name) as ClientName,
                MAX(o.created_at) as Creation,
                MAX(o.updated_at) as LastChangeDate,
                MAX(p.id::text) as ProductId,
                MAX(p.description) as Description,
                MAX(p.category) as Category,
                MAX(p.price) as Price,
                MAX(oi.quantity) as Quantity,
                MAX(os.description) as OrderStatus
            FROM orders o
            JOIN employees e ON o.employee_id = e.id
            LEFT JOIN order_items oi ON o.id = oi.order_id
            JOIN order_status os ON oi.id_order_status = os.id
            LEFT JOIN products p ON oi.product_id = p.id
            GROUP BY 
                o.id, 
                e.name;";

            var response = await connection.QueryAsync(query);

            var resultDictionary = response.ToDictionary(x => x.id, x => x);
            var result = resultDictionary.Values.Select(x => new EmployeeCheckPadGetResponse
            {
                Id = x.id,
                EmployeeName = x.employeename,
                ClientName = x.clientname,
                OrderStatus = x.orderstatus,
                Creation = x.creation,
                LastChangeDate = x.lastchangedate,
                Products = response
                    .Where(p => p.id == x.id)
                    .Select(p => new ProductResponse
                    {
                        ProductId = p.productid,
                        Description = p.description,
                        Category = p.category,
                        Price = p.price
                    })
                    .ToList()
            }).ToList();

            return result;
        }

        public async Task<IEnumerable<EmployeeCheckPadGetResponse>> GetEmployeeAsync(Guid idEmployee)
        {
            using var connection = _connectionFactory.GetConnection();

            const string query = @"
            SELECT
                MAX(o.id::text) as id,
                e.name as EmployeeName,
                MAX(o.customer_name) as ClientName,
                MAX(o.created_at) as Creation,
                MAX(o.updated_at) as LastChangeDate,
                MAX(p.id::text) as ProductId,
                MAX(p.description) as Description,
                MAX(p.category) as Category,
                MAX(p.price) as Price,
                MAX(oi.quantity) as Quantity,
                MAX(os.description) as OrderStatus
            FROM orders o
            JOIN employees e ON o.employee_id = e.id
            LEFT JOIN order_items oi ON o.id = oi.order_id
            JOIN order_status os ON oi.id_order_status = os.id
            LEFT JOIN products p ON oi.product_id = p.id
            WHERE e.id = @EmployeeId
            GROUP BY 
                o.id, 
                e.name;";

            var response = await connection.QueryAsync(query, param: new { EmployeeId = idEmployee });

            var resultDictionary = response.ToDictionary(x => x.id, x => x);
            var result = resultDictionary.Values.Select(x => new EmployeeCheckPadGetResponse
            {
                Id = x.id,
                EmployeeName = x.employeename,
                ClientName = x.clientname,
                OrderStatus = x.orderstatus,
                Creation = x.creation,
                LastChangeDate = x.lastchangedate,
                Products = response
                    .Where(p => p.id == x.id)
                    .Select(p => new ProductResponse
                    {
                        ProductId = p.productid,
                        Description = p.description,
                        Category = p.category,
                        Price = p.price
                    })
                    .ToList()
            }).ToList();

            return result;
        }
    }
}