using Microsoft.AspNetCore.Mvc;
using Pizzerie.Business.Services.Abstractions;
using Pizzerie.Domain.Models.EmployeeCheckPad;
using Pizzerie.Domain.Models.GuestCheckPad;

namespace Pizzerie.Controllers
{
    [ApiController]
    [Route("api/EmployeeCheckPad")]
    public class EmployeeCheckPadController : ControllerBase
    {
        #region ..:: Variables ::..

        private readonly IEmployeeCheckPadService _service;

        #endregion

        #region ..:: Constructor ::..

        public EmployeeCheckPadController(IEmployeeCheckPadService service)
        {
            _service = service;
        }

        #endregion

        #region ..:: Methods ::..

        [HttpGet]
        public async Task<ActionResult<EmployeeCheckPadGetResponse>> GetAllAsync()
        {
            var result = await _service.GetAsync();

            if (_service == null)
                return NotFound();

            return Ok(result);
        }

        [HttpGet("{id_employee}")]
        public async Task<ActionResult<EmployeeCheckPadGetResponse>> GetEmployeeAsync(Guid id_employee)
        {
            var result = await _service.GetEmployeeAsync(id_employee);

            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<dynamic>> CreateAsync(EmployeeCheckPadCreateRequest? model)
        {
            var result = await _service.CreateAsync(model);

            if (result.Success == false)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpPatch]
        public async Task<ActionResult<dynamic>> EditAsync(EmployeeCheckPadEditRequest model)
        {
            var result = await _service.EditAsync(model);

            if (result.Success == false)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpDelete("{idCheckpad}/{idEmployee}")]
        public async Task<ActionResult<dynamic>> DeleteAsync(string idCheckpad, string idEmployee)
        {
            var result = await _service.DeleteAsync(idCheckpad, idEmployee);

            if (result.Message.ToLower().Contains("not found"))
                return NotFound(result);

            return Ok(result);
        }

        #endregion
    }
}