using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace TypingSimulator.SqlScripts
{
    internal class UsersDAO
    {
        public void InsertUser(string username, string password)
        {
            string sql = @"
    INSERT INTO Users (Username, Password) VALUES (@username, @password);
";
            using var connection = new MySqlConnection("server=sql7.freesqldatabase.com;port=3306;database=sql7780834;user=sql7780834;password=eFL3xaXrCE");
            connection.Open();
            using var command = new MySqlCommand(sql, connection);
            command.Parameters.AddWithValue("@username", username);
            command.Parameters.AddWithValue("@password", password);
            command.ExecuteNonQuery();
        }
        public bool UserExists(string username)
        {
            string sql = @"
    SELECT COUNT(*) FROM Users WHERE Username = @username;
";
            using var connection = new MySqlConnection("server=sql7.freesqldatabase.com;port=3306;database=sql7780834;user=sql7780834;password=eFL3xaXrCE");
            connection.Open();
            using var command = new MySqlCommand(sql, connection);
            command.Parameters.AddWithValue("@username", username);
            int count = Convert.ToInt32(command.ExecuteScalar());
            return count > 0;
        }

        public bool CheckPassword(string username, string password)
        {
            string sql = @"
    SELECT COUNT(*) FROM Users WHERE Username = @username AND Password = @password;
";
            using var connection = new MySqlConnection("server=sql7.freesqldatabase.com;port=3306;database=sql7780834;user=sql7780834;password=eFL3xaXrCE");
            connection.Open();
            using var command = new MySqlCommand(sql, connection);
            command.Parameters.AddWithValue("@username", username);
            command.Parameters.AddWithValue("@password", password);
            int count = Convert.ToInt32(command.ExecuteScalar());
            return count > 0;

        }
    }
}
