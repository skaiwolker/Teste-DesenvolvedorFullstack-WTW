using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace Infrastructure.Context
{
    public static class DapperConnection
    {
        public static IDbConnection AddConnection(this IDbConnection connection, IConfiguration configuration)
        {
            connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection"));

            return connection;
        }
    }
}
