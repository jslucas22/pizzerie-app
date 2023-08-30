using Pizzerie.Domain.Models.Application;
using Pizzerie.Domain.Models.GuestCheckPad;

namespace Pizzerie.Business.Services.Abstractions
{
    public interface IEmployeeCheckPadService
    {
        /// <summary>
        /// Returns all the info of the check pad of all employees
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<EmployeeCheckPadGetResponse>> GetAsync();
        /// <summary>
        /// Returns all the info of the check pad of a employee
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<EmployeeCheckPadGetResponse>> GetEmployeeAsync(string idEmployee);
        /// <summary>
        /// Create a checkpad
        /// </summary>
        /// <returns></returns>
        Task<ContentResult> CreateAsync(EmployeeCheckPadCreateRequest model);
        /// <summary>
        /// Update payer name
        /// </summary>
        /// <returns></returns>
        Task<ContentResult> EditAsync(string idCheckpad, string idEmployee, string clientName);
        /// <summary>
        /// Edit the data of a specific checkpad
        /// </summary>
        /// <returns></returns>
        Task<ContentResult> EditAsync(EmployeeCheckPadEditRequest model);
        /// <summary>
        /// Delete some products
        /// </summary>
        /// <returns></returns>
        Task<ContentResult> DeleteAsync(string idCheckpad, string idEmployee);
    }
}
