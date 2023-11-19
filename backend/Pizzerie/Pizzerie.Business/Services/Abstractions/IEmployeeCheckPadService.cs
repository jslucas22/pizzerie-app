using Pizzerie.Domain.Models.Application;
using Pizzerie.Domain.Models.EmployeeCheckPad;
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
        Task<IEnumerable<EmployeeCheckPadGetResponse>> GetEmployeeAsync(Guid idEmployee);

        /// <summary>
        /// Create a checkpad
        /// </summary>
        /// <returns></returns>
        Task<ContentResponse> CreateAsync(EmployeeCheckPadCreateRequest? model);

        /// <summary>
        /// Edit the data of a specific checkpad
        /// </summary>
        /// <returns></returns>
        Task<ContentResponse> EditAsync(EmployeeCheckPadEditRequest model);

        /// <summary>
        /// Delete some products
        /// </summary>
        /// <returns></returns>
        Task<ContentResponse> DeleteAsync(string idCheckpad, string idEmployee);
    }
}