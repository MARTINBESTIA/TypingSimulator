using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace TypingSimulator.SqlScripts
{
    internal class TableCreations
    {
        public static void CreateUserTable()
        {
            string sql = @"
    CREATE TABLE IF NOT EXISTS Users (
        Id INT PRIMARY KEY AUTO_INCREMENT,
        Username VARCHAR(30) NOT NULL,
        Password VARCHAR(30) NOT NULL,
        PlayTime TIME NOT NULL DEFAULT '00:00:00',
        UNIQUE (Username)
    );   

    CREATE TABLE IF NOT EXISTS PythonLeaderboards (
        UserId INT PRIMARY KEY,
        HighestScore DECIMAL(6,2),
        FOREIGN KEY (UserId) REFERENCES Users(Id)
    );
";
            string sql2 = @"
    ALTER TABLE Users
    ADD COLUMN PlayTime TIME;
";

            // Execute the SQL command to create the Users table
            using var connection = new MySqlConnection("server =sql7.freesqldatabase.com;port=3306;database=sql7780834;user=sql7780834;password=eFL3xaXrCE");
            connection.Open();
            using var command = new MySqlCommand(sql, connection);
            command.ExecuteNonQuery();
        }
    }
}
