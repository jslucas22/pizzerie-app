using Pizzerie.Domain.Models.User;

namespace Pizzerie.Business.Services.Abstractions;

public interface IUserService
{
    /// <summary>
    /// Get user by email
    /// </summary>
    /// <param name="model">employee model content to authenticate</param>
    /// <returns></returns>
    Task<UserResponse?> GetAsync(UserRequest model);
}