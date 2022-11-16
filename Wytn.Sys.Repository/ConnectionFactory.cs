using System.Data;
using System.Data.SqlClient;

using Wytn.Sys.Repository.Interface;
using MySqlConnector;

namespace Wytn.Sys.Repository
{
    /// <inheritdoc/>
    public class ConnectionFactory : IConnectionFactory
    {
        private readonly string connectionString;
        public ConnectionFactory(string connectionString)
        {
            this.connectionString = connectionString;
        }
        public IDbConnection createConnection()
        {
            return new MySqlConnection(connectionString);
        }
        public string getConnectionString()
        {
            return connectionString;
        }
    }
}
