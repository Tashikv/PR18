using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkingBD
{
    public class Class1
    {
        readonly static string path = "server=127.0.0.1;port=3306;database=airlines;uid=root;";
        public static MySqlConnection OpenConnection()
        {
            MySqlConnection connection = new MySqlConnection(path);
            connection.Open();
            return connection;
        }
        public static MySqlDataReader Query(string SQL, MySqlConnection connection)
        {
            MySqlCommand command = new MySqlCommand(SQL, connection);
            return command.ExecuteReader();
        }

        public static void CloseConnection(MySqlConnection connection)
        {
            connection.Close();
            MySqlConnection.ClearPool(connection);
        }
    }
}
