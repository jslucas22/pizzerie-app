using System.Diagnostics;
using Npgsql;
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

    public async Task<UserLoginResponse?> GetAsync(UserLoginRequest model)
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

    public async Task<string?> CreateAsync(UserRegisterRequest model)
    {
        try
        {
            var validateCreate = ValidateCreate(model);

            if (!string.IsNullOrEmpty(validateCreate))
            {
                return await Task.FromResult(validateCreate);
            }

            model.Password = _passwordHasherService.HashPassword(model.Password);
            var createEmployee = await _repository.CreateAsync(model);

            return createEmployee;
        }
        catch (InvalidOperationException iEx)
        {
            return iEx.Message;
        }
        catch (PostgresException pEx)
        {
            if (pEx.Message.ToLowerInvariant().Contains("duplicate key value violates"))
            {
                return "ve-01: An employee with this username already exists";
            }

            return "ve-02: An internal exception with the database has been thrown";
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            return await Task.FromResult("ie-01: Something went wrong attempting to create this employee, try again later");
        }
    }

    private static string ValidateCreate(UserRegisterRequest? model)
    {
        if (model == null)
        {
            return "vc-01: employee content can not be null";
        }

        if (model.Name.Length < 3)
        {
            return "vc-02: input a valid name for the employee";
        }

        if (model.Username.Trim().ToLowerInvariant().Length < 2)
        {
            return "vc-03: input a valid username for the employee";
        }   

        if (model.Password.Trim().Length < 8)
        {
            return "vc-04: at least a password with 8 characters is required";
        }

        if (model.RepeatPassword != model.Password)
        {
            return "vc-05: repeat password can not be different from password";
        }

        if (model.Level <= 0)
        {
            return "vc-06: it looks like that you did not add a valid level for the employee";
        }

        return string.Empty;
    }

    #endregion
}