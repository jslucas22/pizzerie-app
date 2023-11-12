namespace Pizzerie.Business.Services.Abstractions;

/// <summary>
/// Interface responsible for defining password hashing and verification methods.
/// </summary>
public interface IPasswordHasherService
{
    /// <summary>
    /// This method receives a password in string format and returns its encrypted correspondent (hash).
    /// The specific implementation of the hash algorithm depends on the class that implements the interface.
    /// </summary>
    /// <param name="password">Password in clear text format to be hashed.</param>
    /// <returns>The hashed password.</returns>
    string HashPassword(string password);

    /// <summary>
    /// This method takes a hashed password and a clear text password and verifies that they match.
    /// The specific implementation of the hash algorithm depends on the class that implements the interface.
    /// </summary>
    /// <param name="hashedPassword">Password in hashed format.</param>
    /// <param name="password">Password in clear text format.</param>
    /// <returns>True if the hashed password matches the cleartext password, false otherwise.</returns>
    bool VerifyPassword(string hashedPassword, string password);
}