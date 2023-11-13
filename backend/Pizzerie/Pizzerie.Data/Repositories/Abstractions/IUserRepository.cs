using Pizzerie.Domain.Models.User;

namespace Pizzerie.Data.Repositories.Abstractions;

public interface IUserRepository
{
    /// <summary>
    /// Get user by email
    /// </summary>
    /// <param name="username">username of the employee</param>
    /// <returns></returns>
    Task<UserLoginResponse?> GetAsync(string username);

    /// <summary>
    /// Create user account async
    /// </summary>
    /// <param name="model">employee model content</param>
    /// <returns></returns>
    Task<string?> CreateAsync(UserRegisterRequest model);
}