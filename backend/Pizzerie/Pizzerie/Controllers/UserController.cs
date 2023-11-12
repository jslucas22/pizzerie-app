using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Pizzerie.Business.Services.Abstractions;
using Pizzerie.Domain.Models.User;
using Pizzerie.Middlewares;

namespace Pizzerie.Controllers;

[ApiController]
[Route("api/user")]
public class UserController : ControllerBase
{
    #region ..:: Variables ::..

    private readonly IUserService _service;

    #endregion

    #region ..:: Constructor ::..

    public UserController(IUserService service)
    {
        _service = service;
    }

    #endregion

    [HttpPost]
    [Route("login")]
    [AllowAnonymous]
    public async Task<ActionResult<dynamic>> Login(UserRequest model)
    {
        try
        {
            var user = await _service.GetAsync(model);

            if (user == null)
                return NotFound(new { Success = false, Message = "User not found" });

            var token = AuthMiddleware.GetToken(user);

            return Ok(new
            {
                user,
                token
            });
        }
        catch (UnauthorizedAccessException uEx)
        {
            return Unauthorized(new { uEx.Message });
        }
        catch (Exception ex)
        {
            return Problem("Something went wrong attempting to log in");
        }
    }
}