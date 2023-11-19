using System.Diagnostics;
using Pizzerie.Business.Services.Abstractions;
using Pizzerie.Business.Strategies.Abstractions;
using Pizzerie.Data.Repositories.Abstractions;
using Pizzerie.Domain.Models.Application;
using Pizzerie.Domain.Models.EmployeeCheckPad;
using Pizzerie.Domain.Models.GuestCheckPad;

namespace Pizzerie.Business.Services
{
    public class EmployeeCheckPadService : IEmployeeCheckPadService
    {
        #region ..:: Variables ::..

        private readonly IEmployeeCheckPadRepository _repository;
        private readonly IValidationStrategy<EmployeeCheckPadCreateRequest> _createValidationStrategy;
        private readonly IValidationStrategy<EmployeeCheckPadEditRequest> _editValidationStrategy;

        #endregion

        #region ..:: Constructor ::..

        public EmployeeCheckPadService(IEmployeeCheckPadRepository repository,
            IValidationStrategy<EmployeeCheckPadCreateRequest> createValidationStrategy,
            IValidationStrategy<EmployeeCheckPadEditRequest> editValidationStrategy)
        {
            _repository = repository;
            _createValidationStrategy = createValidationStrategy;
            _editValidationStrategy = editValidationStrategy;
        }

        #endregion

        #region ..:: Methods ::..

        public async Task<ContentResponse> CreateAsync(EmployeeCheckPadCreateRequest? model)
        {
            if (model != null)
            {
                var validateResult = _createValidationStrategy.Validate(model);
                if (!validateResult.Success)
                {
                    return validateResult;
                }
            }

            var orderExists = await _repository.ExistsOpenOrderForCustomerAsync(model.ClientName, model.TableNumber);
            if (orderExists)
            {
                return new ContentResponse
                {
                    Message = $"An open order already exists for customer {model.ClientName}.",
                    Success = false
                };
            }

            try
            {
                var response = await _repository.CreateAsync(model);
                return response;
            }
            catch (KeyNotFoundException kEx)
            {
                Debug.WriteLine(kEx.Message);
                return new ContentResponse
                {
                    Message = kEx.Message,
                    Success = false
                };
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return new ContentResponse
                {
                    Message = "Something went wrong, please try again later.",
                    Success = false
                };
            }
        }

        public async Task<ContentResponse> DeleteAsync(string idCheckpad, string idEmployee)
        {
            try
            {
                return await _repository.DeleteAsync(idCheckpad, idEmployee);
            }
            catch (KeyNotFoundException kEx)
            {
                Debug.Write(kEx.Message);
                return await Task.FromResult(new ContentResponse
                {
                    Message = kEx.Message,
                    Success = false
                });
            }
            catch (Exception ex)
            {
                Debug.Write(ex.Message);
                return await Task.FromResult(new ContentResponse
                {
                    Message = "Something went wrong",
                    Success = false
                });
            }
        }

        public async Task<ContentResponse> EditAsync(EmployeeCheckPadEditRequest? model)
        {
            try
            {
                if (model != null)
                {
                    var validateResult = _editValidationStrategy.Validate(model);
                    if (!validateResult.Success)
                    {
                        return validateResult;
                    }
                }

                var orderExists = model != null && await _repository.OrderExistsAsync(model.Id);
                if (!orderExists)
                {
                    return new ContentResponse
                    {
                        Success = false,
                        Message = "Order not found."
                    };
                }

                var canEdit = model != null && await _repository.CanEditOrderAsync(model.Id);
                if (!canEdit)
                {
                    return new ContentResponse
                    {
                        Success = false,
                        Message = "Order cannot be edited at its current status."
                    };
                }

                if (model != null)
                {
                    await _repository.EditAsync(model);
                    return new ContentResponse
                    {
                        Success = true,
                        Message = "Order updated successfully."
                    };
                }

                return new ContentResponse
                {
                    Success = true,
                    Message = "It looks like that you did not input the checkpad content."
                };
            }
            catch (KeyNotFoundException kEx)
            {
                Debug.Write(kEx.Message);
                return new ContentResponse
                {
                    Success = false,
                    Message = $"An error occurred while editing the order"
                };
            }
            catch (Exception ex)
            {
                Debug.Write(ex.Message);
                return new ContentResponse
                {
                    Success = false,
                    Message = $"An error occurred while editing the order"
                };
            }
        }

        public Task<IEnumerable<EmployeeCheckPadGetResponse>> GetAsync()
        {
            try
            {
                return _repository.GetAsync();
            }
            catch (Exception)
            {
                throw new NotImplementedException();
            }
        }

        public Task<IEnumerable<EmployeeCheckPadGetResponse>> GetEmployeeAsync(Guid idEmployee)
        {
            try
            {
                return _repository.GetEmployeeAsync(idEmployee);
            }
            catch (Exception)
            {
                throw new NotImplementedException();
            }
        }

        #endregion
    }
}