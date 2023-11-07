using Pizzerie.Domain.Models.Application;
using Pizzerie.Domain.Models.EmployeeCheckPad;
using Pizzerie.Domain.Models.GuestCheckPad;

namespace Pizzerie.Data.Repositories.Abstractions
{
    public interface IEmployeeCheckPadRepository
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
        /// Check if customer can create an order  
        /// </summary>
        /// <param name="customerName">the name of the customer</param>
        /// <param name="tableNumber">the number of the customer table</param>
        /// <returns></returns>
        Task<bool> ExistsOpenOrderForCustomerAsync(string customerName, short tableNumber);

        /// <summary>
        /// OrdeCheck if order exists 
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        Task<bool> OrderExistsAsync(Guid orderId);

        /// <summary>
        /// check if is it possible to edit the order
        /// </summary>
        /// <param name="orderId">the unique identifier of order</param>
        /// <returns></returns>
        Task<bool> CanEditOrderAsync(Guid orderId);

        /// <summary>
        /// Create a checkpad
        /// </summary>
        /// <returns></returns>
        Task<ContentResponse> CreateAsync(EmployeeCheckPadCreateRequest? model);

        /// <summary>
        /// Update payer name
        /// </summary>
        /// <returns></returns>
        Task<ContentResponse> EditAsync(Guid idCheckpad, Guid idEmployee, string clientName);

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