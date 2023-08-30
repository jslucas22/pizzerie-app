using Pizzerie.Data.Repositories.Abstractions;
using Pizzerie.Domain.Models.Application;
using Pizzerie.Domain.Models.GuestCheckPad;
using Pizzerie.Domain.Models.Product;
using System.Reflection;

namespace Pizzerie.Data.Repositories
{
    public class EmployeeCheckPadRepository : IEmployeeCheckPadRepository
    {
        public Task<ContentResult> CreateAsync(EmployeeCheckPadCreateRequest model)
        {
            return Task.FromResult(new ContentResult { Message = $"The checkpad was created successfully for client {model.ClientName}", Success = true });
        }

        public Task<ContentResult> DeleteAsync(string idCheckpad, string idEmployee)
        {
            return Task.FromResult(new ContentResult { Message = $"The checkpad with id {idCheckpad} was deleted successfully for employee with id {idEmployee}", Success = true });
        }

        public Task<ContentResult> EditAsync(string idCheckpad, string idEmployee, string clientName)
        {
            return Task.FromResult(new ContentResult { Message = $"The checkpad with id {idCheckpad} of employee {idEmployee} updated successfully the client payer name for {clientName}", Success = true });
        }

        public Task<ContentResult> EditAsync(EmployeeCheckPadEditRequest model)
        {
            return Task.FromResult(new ContentResult { Message = $"The checkpad with id {model.Id} of employee {model.IdEmployee} update successfully the data, the last change is {model.LastChange}", Success = true });
        }

        public Task<IEnumerable<EmployeeCheckPadGetResponse>> GetAsync()
        {
            return Task.FromResult<IEnumerable<EmployeeCheckPadGetResponse>>(
                    new List<EmployeeCheckPadGetResponse>()
                    {
                        new EmployeeCheckPadGetResponse()
                        {
                            Clients = new List<string>
                            {
                                Guid.NewGuid().ToString(),
                                Guid.NewGuid().ToString(),
                                Guid.NewGuid().ToString()
                            },
                            Id = Guid.NewGuid().ToString(),
                            Products = new List<ProductResponse>
                            {
                                new ProductResponse
                                {
                                    Id = Guid.NewGuid().ToString(),
                                    Category = "Tradicional",
                                    Name = "Mergherita",
                                    Description = "Muçarela, azeita, manjericão e Molho de Tomate",
                                    PhotoUrl = @"/img/pizzas/tradicional/merguerita.svg",
                                    Price = 57.35M
                                },
                                new ProductResponse
                                {
                                    Id = Guid.NewGuid().ToString(),
                                    Category = "Especial",
                                    Name = "Pepperoni",
                                    Description = "Pimentão, Salame Italiano, Pimentão, Queijo e Pimenta Calabresa",
                                    PhotoUrl = @"/dev/pizzas/especial/pepperone.svg",
                                    Price = 68.92M
                                },
                                new ProductResponse
                                {
                                    Id = Guid.NewGuid().ToString(),
                                    Category = "Vegana",
                                    Name = "Abobrinha",
                                    Description = "Molho de tomate natural, Abobrinha Italiana, Tomate Cereja, Queijo vegano e Alecrem",
                                    PhotoUrl = @"/dev/vega/especial/abobrinha.svg",
                                    Price = 91.23M
                                }
                            }
                        },
                        new EmployeeCheckPadGetResponse()
                        {
                            Clients = new List<string>
                            {
                                Guid.NewGuid().ToString(),
                                Guid.NewGuid().ToString(),
                                Guid.NewGuid().ToString()
                            },
                            Id = Guid.NewGuid().ToString(),
                            Products = new List<ProductResponse>
                            {
                                new ProductResponse
                                {
                                    Id = Guid.NewGuid().ToString(),
                                    Category = "Tradicional",
                                    Name = "Calabresa",
                                    Description = "2 Ovos, Mussarela em fatias e Linguiça Calabres Fatiada",
                                    PhotoUrl = @"/img/pizzas/tradicional/calabresa.svg",
                                    Price = 48.97M
                                },
                                new ProductResponse
                                {
                                    Id = Guid.NewGuid().ToString(),
                                    Category = "Especial",
                                    Name = "Executiva",
                                    Description = "Ovo, Presunto, Mussarela e Salsinha",
                                    PhotoUrl = @"/dev/pizzas/especial/executiva.svg",
                                    Price = 68.92M
                                },
                                new ProductResponse
                                {
                                    Id = Guid.NewGuid().ToString(),
                                    Category = "Vegana",
                                    Name = "Bahiana",
                                    Description = "2 Cidadões da Bahia, Pimenta, Calabresa e Bacon",
                                    PhotoUrl = @"/dev/vega/especial/bahiana.svg",
                                    Price = 68.92M
                                }
                            }
                        },
                        new EmployeeCheckPadGetResponse()
                        {
                            Clients = new List<string>
                            {
                                Guid.NewGuid().ToString(),
                                Guid.NewGuid().ToString(),
                                Guid.NewGuid().ToString()
                            },
                            Id = Guid.NewGuid().ToString(),
                            Products = new List<ProductResponse>
                            {
                                new ProductResponse
                                {
                                    Id = Guid.NewGuid().ToString(),
                                    Category = "Tradicional",
                                    Name = "Manjericão",
                                    Description = "2 Molho de Tomate, Muçarela Ralada Grosso, Rodelas de Tomate e Folhas de Manjericão",
                                    PhotoUrl = @"/img/pizzas/tradicional/calabresa.svg",
                                    Price = 48.97M
                                },
                                new ProductResponse
                                {
                                    Id = Guid.NewGuid().ToString(),
                                    Category = "Especial",
                                    Name = "Charchicha",
                                    Description = "Charchiva, Ovo, Calabresa e Mussarela em Pedaços",
                                    PhotoUrl = @"/dev/pizzas/especial/charchicha.svg",
                                    Price = 68.92M
                                },
                                new ProductResponse
                                {
                                    Id = Guid.NewGuid().ToString(),
                                    Category = "Vegana",
                                    Name = "Mineirinha",
                                    Description = "Pimenta, Pimenta do reino, Salmão e Pão de Queijo",
                                    PhotoUrl = @"/dev/vega/especial/mineirinha.svg",
                                    Price = 68.92M
                                }
                            }
                        }
                    }
                );
        }

        public Task<IEnumerable<EmployeeCheckPadGetResponse>> GetEmployeeAsync(string idEmployee)
        {
            return Task.FromResult<IEnumerable<EmployeeCheckPadGetResponse>>(
                new List<EmployeeCheckPadGetResponse>
                {
                    new EmployeeCheckPadGetResponse
                    {
                        Id = idEmployee,
                        Clients = new List<string>
                        {
                            Guid.NewGuid().ToString(),
                            Guid.NewGuid().ToString(),
                            Guid.NewGuid().ToString()
                        },
                        Creation = DateTime.Now.AddMinutes(-5 * DateTime.Now.Second),
                        EmployeeName = "José Hilario",
                        LastChangeDate = DateTime.Now,
                        Products = new List<ProductResponse>
                        {
                                new ProductResponse
                                {
                                    Id = Guid.NewGuid().ToString(),
                                    Category = "Tradicional",
                                    Name = "Merguerita",
                                    Description = "Muçarela, azeita, manjericão e Molho de Tomate",
                                    PhotoUrl = @"/img/pizzas/tradicional/merguerita.svg",
                                    Price = 57.35M
                                },
                                new ProductResponse
                                {
                                    Id = Guid.NewGuid().ToString(),
                                    Category = "Especial",
                                    Name = "Pepperoni",
                                    Description = "Pimentão, Salame Italiano, Pimentão, Queijo e Pimenta Calabresa",
                                    PhotoUrl = @"/dev/pizzas/especial/pepperone.svg",
                                    Price = 68.92M
                                },
                                new ProductResponse
                                {
                                    Id = Guid.NewGuid().ToString(),
                                    Category = "Vegana",
                                    Name = "Abobrinha",
                                    Description = "Molho de tomate natural, Abobrinha Italiana, Tomate Cereja, Queijo vegano e Alecrem",
                                    PhotoUrl = @"/dev/vega/especial/abobrinha.svg",
                                    Price = 68.92M
                                }
                        }
                    }
                }
                );
        }
    }
}
