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
                "SELECT EXISTS(SELECT 1 FROM orders WHERE uuid = @OrderId)",
                new { OrderId = orderId });

            return exists;
        }

        public async Task<bool> CanEditOrderAsync(Guid orderId)
        {
            using var connection = _connectionFactory.GetConnection();
            var status = await connection.QueryFirstOrDefaultAsync<string>(
                "SELECT status FROM orders WHERE uuid = @OrderId",
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
                const string employeeIdQuery = @"
                SELECT 
                    id 
                FROM 
                    employees 
                WHERE uuid = @EmployeeUUID";

                var employeeId = await connection.QuerySingleOrDefaultAsync<int?>(employeeIdQuery,
                    new { EmployeeUUID = model?.IdEmployee }, transaction);

                if (!employeeId.HasValue)
                {
                    throw new KeyNotFoundException("eca-01: Employee not found.");
                }

                const string orderInsertQuery = @"
                INSERT INTO orders (employee_id, table_number, customer_name, total_value, payment_method, status)
                VALUES (@EmployeeId, @TableNumber, @CustomerName, @TotalValue, @PaymentMethod, @Status)
                RETURNING id;";

                if (model?.Products != null)
                {
                    var totalValue = model.Products.Sum(p => p.Price);
                    var orderId = await connection.QuerySingleAsync<int>(orderInsertQuery, new
                    {
                        EmployeeId = employeeId,
                        model.TableNumber,
                        CustomerName = model.ClientName,
                        TotalValue = totalValue,
                        model.PaymentMethod,
                        Status = "Open",
                    }, transaction);

                    foreach (var product in model.Products)
                    {
                        const string productIdQuery = "SELECT id FROM products WHERE uuid = @ProductUUID";
                        var productId = await connection.QuerySingleOrDefaultAsync<int?>(productIdQuery,
                            new { ProductUUID = product.Id }, transaction);

                        if (!productId.HasValue)
                        {
                            throw new KeyNotFoundException($"eca-02: Product not found.");
                        }

                        const string insertQuery = @"
                        INSERT INTO order_items (order_id, product_id, quantity)
                        VALUES (@OrderId, @ProductId, @Quantity);";

                        await connection.ExecuteAsync(insertQuery, new
                        {
                            OrderId = orderId,
                            ProductId = productId.Value,
                            product.Quantity
                        }, transaction);
                    }
                }

                transaction.Commit();
                return new ContentResponse
                {
                    Message = $"The checkpad was created successfully for client {model?.ClientName}", Success = true
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
            WHERE o.uuid = @OrderUuid AND e.uuid = @EmployeeUuid;";

                var orderCount = await connection.ExecuteScalarAsync<int>(validationQuery,
                    new { OrderUuid = Guid.Parse(idCheckpad), EmployeeUuid = Guid.Parse(idEmployee) }, transaction);

                if (orderCount == 0)
                {
                    throw new KeyNotFoundException("Order or Employee not found.");
                }

                const string deleteOrderItemsQuery =
                    "DELETE FROM order_items WHERE order_id = (SELECT id FROM orders WHERE uuid = @OrderUuid);";
                await connection.ExecuteAsync(deleteOrderItemsQuery, new { OrderUuid = Guid.Parse(idCheckpad) },
                    transaction);

                const string deleteOrderQuery = "DELETE FROM orders WHERE uuid = @OrderUuid;";
                await connection.ExecuteAsync(deleteOrderQuery, new { OrderUuid = Guid.Parse(idCheckpad) },
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
                WHERE uuid = @OrderId RETURNING id;";

                var updatedOrderId = await connection.ExecuteAsync(orderUpdateQuery, new
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
                        const string productIdQuery = "SELECT id FROM products WHERE uuid = @ProductUUID";
                        var productId = await connection.QuerySingleOrDefaultAsync<int?>(productIdQuery,
                            new { ProductUUID = product.Id }, transaction);

                        if (productId == null)
                        {
                            throw new KeyNotFoundException($"eea-01: Product not found.");
                        }

                        if (product.Remove)
                        {
                            const string removeProductQuery =
                                "DELETE FROM order_items WHERE order_id = @OrderId AND product_id = @ProductId";
                            await connection.ExecuteAsync(removeProductQuery, new
                            {
                                OrderId = model.Id,
                                ProductId = productId
                            }, transaction);
                        }
                        else
                        {
                            const string productExistsQuery =
                                "SELECT 1 FROM order_items WHERE order_id = @OrderId AND product_id = @ProductId";
                            var productExists = await connection.QuerySingleOrDefaultAsync<bool>(productExistsQuery, new
                            {
                                OrderId = updatedOrderId,
                                ProductId = productId
                            }, transaction);

                            if (productExists)
                            {
                                const string updateProductQuery = @"
                                UPDATE order_items
                                SET quantity = @Quantity
                                WHERE order_id = @OrderId AND product_id = @ProductId";
                                await connection.ExecuteAsync(updateProductQuery, new
                                {
                                    OrderId = updatedOrderId,
                                    ProductId = productId,
                                    product.Quantity
                                }, transaction);
                            }
                            else
                            {
                                const string insertProductQuery = @"
                                INSERT INTO order_items (order_id, product_id, quantity)
                                VALUES (@OrderId, @ProductId, @Quantity)";

                                await connection.ExecuteAsync(insertProductQuery, new
                                {
                                    OrderId = updatedOrderId,
                                    ProductId = productId,
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
            o.uuid as Id,
            e.name as EmployeeName,
            o.customer_name as ClientName,
            o.created_at as Creation,
            o.updated_at as LastChangeDate,
            p.uuid as ProductId,
            p.description as Description,
            p.category as Category,
            p.price as Price,
            oi.quantity as Quantity
        FROM orders o
        JOIN employees e ON o.employee_id = e.id
        LEFT JOIN order_items oi ON o.id = oi.order_id
        LEFT JOIN products p ON oi.product_id = p.id;";

            var orderDictionary = new Dictionary<string, EmployeeCheckPadGetResponse>();

            await connection.QueryAsync<EmployeeCheckPadGetResponse, ProductResponse, EmployeeCheckPadGetResponse>(
                query,
                (orderResponse, product) =>
                {
                    if (!orderDictionary.TryGetValue(orderResponse.Id.ToString(), out var orderEntry))
                    {
                        orderEntry = orderResponse;
                        orderEntry.ClientName = orderResponse.ClientName;
                        orderEntry.Products = new List<ProductResponse>();
                        orderDictionary.Add(orderEntry.Id.ToString(), orderEntry);
                    }

                    if (!string.IsNullOrEmpty(product.ProductId.ToString()))
                    {
                        orderEntry.Products?.Add(product);
                    }

                    return orderEntry;
                },
                splitOn: "ProductId"
            );

            return orderDictionary.Values;
        }

        public async Task<IEnumerable<EmployeeCheckPadGetResponse>> GetEmployeeAsync(Guid idEmployee)
        {
            using var connection = _connectionFactory.GetConnection();

            const string query = @"
            SELECT
                o.uuid as Id,
                e.name as EmployeeName,
                o.customer_name as ClientName,
                o.created_at as Creation,
                o.updated_at as LastChangeDate,
                p.uuid as ProductId,
                p.description as Description,
                p.category as Category,
                p.price as Price,
                oi.quantity as Quantity
            FROM orders o
            JOIN employees e ON o.employee_id = e.id
            LEFT JOIN order_items oi ON o.id = oi.order_id
            LEFT JOIN products p ON oi.product_id = p.id
        WHERE e.uuid = @EmployeeUuid;";

            var orderDictionary = new Dictionary<string, EmployeeCheckPadGetResponse>();

            await connection.QueryAsync<EmployeeCheckPadGetResponse, ProductResponse, EmployeeCheckPadGetResponse>(
                query,
                (orderResponse, product) =>
                {
                    if (!orderDictionary.TryGetValue(orderResponse.Id.ToString(), out var orderEntry))
                    {
                        orderEntry = orderResponse;
                        orderEntry.ClientName = orderResponse.ClientName;
                        orderEntry.Products = new List<ProductResponse>();
                        orderDictionary.Add(orderEntry.Id.ToString(), orderEntry);
                    }

                    if (!string.IsNullOrEmpty(product.ProductId.ToString()))
                    {
                        orderEntry.Products?.Add(product);
                    }

                    return orderEntry;
                },
                new { EmployeeUuid = idEmployee },
                splitOn: "ProductId"
            );

            return orderDictionary.Values;
        }
    }
}