using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema_de_registros_de_usuarios.DataBase
{
    internal class DbConnection
    {
        private static readonly DbConnection _instance = new DbConnection();
        private readonly string _connectionString;

        private DbConnection()
        {
            _connectionString = "Server=localhost\\SQLEXPRESS;Database=ScheduleApp;Trusted_Connection=True;";
        }

        public static DbConnection Instance => _instance;

        public SqlConnection GetConnection()
        {
            var conn = new SqlConnection(this._connectionString);
            conn.Open();
            return conn;
        }
    }
}
