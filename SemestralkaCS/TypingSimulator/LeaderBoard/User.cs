using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TypingSimulator.LeaderBoard
{
    public class User
    {
        public User(int userId, string lang, int score)
        {
            string? uN = SqlScripts.UsersDAO.GetUserName(userId);
            UserName = uN == null ? "Unknown" : uN;
            UserId = userId;
            Language = lang;
            Score = score;
        }

        public int UserId { get; }
        public string Language { get; }
        public int Score { get; } 
        public string UserName { get; }
        
    }
}
