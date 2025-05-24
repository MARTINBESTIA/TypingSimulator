using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using TypingSimulator.SqlScripts;


namespace TypingSimulator.MainViewScripts
{
    public class UserSession
    {
        public UserSession(int userId, string userName)
        {
            TimeSpanBegin = DateTime.Now;
            UserId = userId;
            UserName = userName;
            Application.Current.Exit += SaveTotalTimeSpan;
        }

        private DateTime TimeSpanBegin { get; }
        public int UserId { get; }
        public string UserName { get; }

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

        internal void SaveTotalTimeSpan(object sender, ExitEventArgs e)
        {
            var span = DateTime.Now - TimeSpanBegin + SqlScripts.UsersDAO.GetUserTotalTimeSpan(UserId); 
            UsersDAO.UpdateUserPlayTime(UserId, span);
        }
    }

}
