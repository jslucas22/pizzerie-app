using System.Data;

namespace Pizzerie.Data.DbConfig;

public interface IDatabaseConnectionFactory
{
    IDbConnection GetConnection();
}