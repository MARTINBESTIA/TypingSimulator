using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TypingSimulator.MainViewScripts
{
    public class UserSession(int userId, string userName)
    {
        private DateTime TimeSpanBegin { get; } = DateTime.Now;
        public int UserId { get; } = userId;
        public string UserName { get; } = userName;

        public string GetSessionTimeSpan()
        {
            TimeSpan span = DateTime.Now - TimeSpanBegin;
            return span.Duration().ToString(@"hh\:mm\:ss");
        }
        public string GetTotalTimeSpan()
        {
            TimeSpan previousSpan = SqlScripts.UsersDAO.GetUserTotalTimeSpan(UserId);
            TimeSpan span = DateTime.Now - TimeSpanBegin + previousSpan;
            return span.Duration().ToString(@"dd\:hh\:mm");
        }

    }

}
