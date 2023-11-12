using System.Diagnostics;
using Pizzerie.Business.Services.Abstractions;
using Pizzerie.Data.Repositories.Abstractions;
using Pizzerie.Domain.Models.User;

namespace Pizzerie.Business.Services.Authentication;

public class UserService : IUserService
{
    #region ..:: Variables ::..

    private readonly IUserRepository _repository;
    private readonly IPasswordHasherService _passwordHasherService;

    #endregion

    #region ..:: Constructor ::..

    public UserService(IUserRepository repository, IPasswordHasherService service)
    {
        _repository = repository;
        _passwordHasherService = service;
    }

    #endregion

    #region ..:: Methods ::..

    public async Task<UserResponse?> GetAsync(UserRequest model)
    {
        try
        {
            var user = await _repository.GetAsync(model.Username);

            if (user == null)
                throw new UnauthorizedAccessException("User does not exists.");

            if (!_passwordHasherService.VerifyPassword(model.Password, user.Password))
                throw new UnauthorizedAccessException("Invalid email or password.");

            user.ClearPassword();

            return user;
        }
        catch (UnauthorizedAccessException uEx)
        {
            Debug.WriteLine(uEx);
            // _logger.LogError(uEx, $"An error occurred while trying to authenticate this user.", uEx);
            return null;
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex);
            // _logger.LogError(ex, $"An error occurred while trying to authenticate this user.", ex);
            return null;
        }
    }

    #endregion
}