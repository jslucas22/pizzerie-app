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

    public async Task<UserResponse?> GetAsync(string username)
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

        var user = new UserResponse
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
}