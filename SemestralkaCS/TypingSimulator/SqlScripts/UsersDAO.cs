using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using TypingSimulator.LeaderBoard;

namespace TypingSimulator.SqlScripts
{
    internal class UsersDAO
    {
        public static void InsertUser(string username, string password)
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
        public static bool UserExists(string username)
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

        public static int GetUserId(string username)
        {
            string sql = @"
    SELECT Id FROM Users WHERE Username = @username;
";
            using var connection = new MySqlConnection("server=sql7.freesqldatabase.com;port=3306;database=sql7780834;user=sql7780834;password=eFL3xaXrCE");
            connection.Open();
            using var command = new MySqlCommand(sql, connection);
            command.Parameters.AddWithValue("@username", username);
            object result = command.ExecuteScalar(); // tento a riadok pod nim pomohol AI
            return result != null ? Convert.ToInt32(result) : -1;
        }

        public static bool CheckPassword(string username, string password)
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

        public static TimeSpan GetUserTotalTimeSpan(int userId)
        {
            string sql = @"
    SELECT PlayTime FROM Users WHERE Id = @userId;
";
            using var connection = new MySqlConnection("server=sql7.freesqldatabase.com;port=3306;database=sql7780834;user=sql7780834;password=eFL3xaXrCE");
            connection.Open();
            using var command = new MySqlCommand(sql, connection);
            command.Parameters.AddWithValue("@userId", userId);
            object result = command.ExecuteScalar();
            if (result != null && TimeSpan.TryParse(result.ToString(), out TimeSpan playTime))
            {
                return playTime;
            }
            else
            {
                return TimeSpan.Zero;
            }
        }

        public static void UpdateUserPlayTime(int userId, TimeSpan playTime)
        {
            string sql = @"
    UPDATE Users SET PlayTime = @playTime WHERE Id = @userId;
";
            using var connection = new MySqlConnection("server=sql7.freesqldatabase.com;port=3306;database=sql7780834;user=sql7780834;password=eFL3xaXrCE");
            connection.Open();
            using var command = new MySqlCommand(sql, connection);
            command.Parameters.AddWithValue("@playTime", playTime);
            command.Parameters.AddWithValue("@userId", userId);
            command.ExecuteNonQuery();
        }

        public static void UpdateUserBestEffort(int userId, string language, int score)
        {
            string sql = @"
    INSERT INTO BestEfforts (UserId, PickedLanguage, HighestScore)
    VALUES (@userId, @language, @score)
    ON DUPLICATE KEY UPDATE HighestScore = GREATEST(HighestScore, @score);
";
            using var connection = new MySqlConnection("server=sql7.freesqldatabase.com;port=3306;database=sql7780834;user=sql7780834;password=eFL3xaXrCE");
            connection.Open();
            using var command = new MySqlCommand(sql, connection);
            command.Parameters.AddWithValue("@userId", userId);
            command.Parameters.AddWithValue("@language", language);
            command.Parameters.AddWithValue("@score", score);
            command.ExecuteNonQuery();
        }
        public static IReadOnlyList<User> FilterEffortsByLanguage(string language)
        {
            string sql = @"
    SELECT * FROM BestEfforts WHERE PickedLanguage = @language;
";
            using var connection = new MySqlConnection("server=sql7.freesqldatabase.com;port=3306;database=sql7780834;user=sql7780834;password=eFL3xaXrCE");
            connection.Open();
            using var command = new MySqlCommand(sql, connection);
            command.Parameters.AddWithValue("@language", language);
            List<User> users = new List<User>();
            using var reader = command.ExecuteReader();
            while (reader.Read())
            {
                // Process each row
                int userId = reader.GetInt32("UserId");
                string lang = reader.GetString("PickedLanguage");
                int score = reader.GetInt32("HighestScore");
                users.Add(new User(userId, lang, score));
            }
            return users.AsReadOnly();
        }

        public static string? GetUserName(int userId)
        {
            string sql = @"
    SELECT Username FROM Users WHERE Id = @userId;
";
            using var connection = new MySqlConnection("server=sql7.freesqldatabase.com;port=3306;database=sql7780834;user=sql7780834;password=eFL3xaXrCE");
            connection.Open();
            using var command = new MySqlCommand(sql, connection);
            command.Parameters.AddWithValue("@userId", userId);
            object result = command.ExecuteScalar();
            return result != null ? result.ToString() : string.Empty;
        }

        public static IReadOnlyList<User> GetAllBestEfforts()
        {
            string sql = @"
    SELECT * FROM BestEfforts;
";
            using var connection = new MySqlConnection("server=sql7.freesqldatabase.com;port=3306;database=sql7780834;user=sql7780834;password=eFL3xaXrCE");
            connection.Open();
            using var command = new MySqlCommand(sql, connection);
            List<User> users = new List<User>();
            using var reader = command.ExecuteReader();
            while (reader.Read())
            {
                int userId = reader.GetInt32("UserId");
                string lang = reader.GetString("PickedLanguage");
                int score = reader.GetInt32("HighestScore");
                users.Add(new User(userId, lang, score));
            }
            return users.AsReadOnly();
        }
    }
}
