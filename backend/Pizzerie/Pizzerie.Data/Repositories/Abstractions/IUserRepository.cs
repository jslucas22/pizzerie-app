using Pizzerie.Domain.Models.User;

namespace Pizzerie.Data.Repositories.Abstractions;

public interface IUserRepository
{
    /// <summary>
    /// Get user by email
    /// </summary>
    /// <param name="username">username of the employee</param>
    /// <returns></returns>
    Task<UserResponse?> GetAsync(string username);
}