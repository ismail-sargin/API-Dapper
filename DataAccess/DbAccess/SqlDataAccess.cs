

using Dapper;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace DataAccess.DbAccess; 
public class SqlDataAccess : ISqlDataAccess
{
    readonly IConfiguration _config;
    public SqlDataAccess(IConfiguration config)
    {
        _config = config;
    }

    public async Task<IEnumerable<T>> LoadData<T, U>(
        string storedProducere,
        U parameters,
        string connectionId = "Default")
    {
        using IDbConnection connection = new SqlConnection(_config.GetConnectionString(connectionId));
        return await connection.QueryAsync<T>(storedProducere, parameters,
            commandType: CommandType.StoredProcedure);
    }

    public async Task SaveData<T>(
        string storedProducere,
        T parameters,
        string connectionId = "Default")
    {
        using IDbConnection connection = new SqlConnection(_config.GetConnectionString(connectionId));
        await connection.ExecuteAsync(storedProducere, parameters, commandType: CommandType.StoredProcedure);

    }
}
