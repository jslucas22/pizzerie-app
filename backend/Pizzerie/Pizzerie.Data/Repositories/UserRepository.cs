using System.Transactions;
using Dapper;
using Pizzerie.Data.DbConfig;
using Pizzerie.Data.Repositories.Abstractions;
using Pizzerie.Domain.Models.User;

namespace Pizzerie.Data.Repositories;

public class UserRepository : IUserRepository
{
    #region ..:: Variables ::..

    private readonly IDatabaseConnectionFactory _connectionFactory;

    #endregion

    public UserRepository(IDatabaseConnectionFactory connectionFactory)
    {
        _connectionFactory = connectionFactory;
    }

    public async Task<UserLoginResponse?> GetAsync(string username)
    {
        using var connection = _connectionFactory.GetConnection();

        const string query = @"
        SELECT  
            e.uuid,
            e.name,
            e.username,
            e.password,
            l.description AS level,
            e.created_at,
            e.updated_at
        FROM 
            employees AS e
            JOIN employees_levels AS l ON e.level_id = l.id
        WHERE
            e.username = @Username;";

        var result = await connection.QueryFirstOrDefaultAsync(query, new { Username = username });

        if (result == null)
        {
            return null;
        }

        var user = new UserLoginResponse
        {
            Id = result.uuid,
            Name = result.name,
            Username = result.username,
            Password = result.password,
            Level = result.level,
            CreatedAt = result.created_at,
            UpdatedAt = result.updated_at
        };

        return user;
    }

    public async Task<string?> CreateAsync(UserRegisterRequest model)
    {
        using var connection = _connectionFactory.GetConnection();
        connection.Open();

        const string query = @"
        INSERT INTO employees (name, username, password, level_id)
        VALUES (@Name, @Username, @Password, @Level)
        RETURNING uuid;";

        var result = await connection.QueryFirstOrDefaultAsync<Guid>(query,
            new { model.Name, model.Username, model.Password, model.Level });
        
        if (result == Guid.Empty)
        {
            throw new InvalidOperationException("Something went wrong attempting to insert this employee, try again later");
        }
        
        return result.ToString();
    }
}