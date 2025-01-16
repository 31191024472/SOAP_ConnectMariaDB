using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySqlConnector;
using SOAP_ConnectMariaDB.Entities;

namespace SOAP_ConnectMariaDB.DB
{
    public class ConnectDB
    {
        private static MySqlConnection connection;
        private static MySqlConnection connect(string server, string dbName, string userName, string password)
        {
            string connectionString = $"Server={server};Database={dbName};User={userName};" +
                $"Password={password};";
            connection = new MySqlConnection(connectionString);
            //connection.Open();
            return connection;
        }
        private ConnectDB()
        {
        }

        public static MySqlConnection getInstance()
        {
            if (connection == null)
                connection = connect("localhost", "world", "root", "ThanhGay17");
            return connection;
        }
    }
}