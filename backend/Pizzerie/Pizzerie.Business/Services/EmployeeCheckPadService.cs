using Pizzerie.Business.Services.Abstractions;
using Pizzerie.Data.Repositories.Abstractions;
using Pizzerie.Domain.Models.Application;
using Pizzerie.Domain.Models.GuestCheckPad;

namespace Pizzerie.Business.Services
{
    public class EmployeeCheckPadService : IEmployeeCheckPadService
    {
        #region ..:: Variables ::..

        private readonly IEmployeeCheckPadRepository _repository;

        #endregion

        #region ..:: Constructor ::..

        public EmployeeCheckPadService(IEmployeeCheckPadRepository repository)
        {
            _repository = repository;
        }

        #endregion

        #region ..:: Methods ::..

        public Task<ContentResult> CreateAsync(EmployeeCheckPadCreateRequest model)
        {
            try
            {
                return _repository.CreateAsync(model);
            }
            catch(Exception)
            {
                return Task.FromResult(new ContentResult
                {                    
                    Message = "Something went wrong",
                    Success = false
                });
            }
        }

        public Task<ContentResult> DeleteAsync(string idCheckpad, string idEmployee)
        {
            try
            {
                return _repository.DeleteAsync(idCheckpad, idEmployee);
            }
            catch (Exception)
            {
                return Task.FromResult(new ContentResult
                {
                    Message = "Something went wrong",
                    Success = false
                });
            }
        }

        public Task<ContentResult> EditAsync(string idCheckpad, string idEmployee, string clientName)
        {
            try
            {
                return _repository.EditAsync(idCheckpad, idEmployee, clientName);
            }
            catch (Exception)
            {
                return Task.FromResult(new ContentResult
                {
                    Message = "Something went wrong",
                    Success = false
                });
            }
        }

        public Task<ContentResult> EditAsync(EmployeeCheckPadEditRequest model)
        {
            try
            {
                return _repository.EditAsync(model);
            }
            catch (Exception)
            {
                return Task.FromResult(new ContentResult
                {
                    Message = "Something went wrong",
                    Success = false
                });
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

        public Task<IEnumerable<EmployeeCheckPadGetResponse>> GetEmployeeAsync(string idEmployee)
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
