using System.Configuration;
using System.Data.SqlClient;

namespace DAL
{
    public class Connection
    {
        private static Connection _cn = new Connection();
        private static readonly object LockObject = new object();
        private static string _connectionString = ConfigurationManager.ConnectionStrings["MiConexion"].ConnectionString;
        private static SqlConnection _connection = new SqlConnection(_connectionString);

        public static SqlConnection GetConnection()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["MiConexion"].ConnectionString;
            if (_connection == null) _connection = new SqlConnection(_connectionString);
            return _connection;
        }

        public static void OpenConnection()
        {
            if (_connection != null) _connection.Open();
        }

        public static void CloseConnection()
        {
            if (_connection != null)
            {
                _connection.Close();
                _connection.Dispose();
                _connection = null;
            }
        }
    }
}