using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using TypingSimulator.MainViewScripts;


namespace TypingSimulator.Views
{
    /// <summary>
    /// Interaction logic for MainView.xaml
    /// </summary>
    public partial class MainView : UserControl
    {
        private readonly UserSession _userSession;
        public MainView(UserSession userSession)
        {
            _userSession = userSession;
            InitializeComponent();
            UpdateGUITimers();
            UserNameLabel.Content = "Welcome, " + _userSession.UserName + "!";
        }

        private async void UpdateGUITimers() 
        {
            while (true) 
            {
                TotalPlayTime.Content = "Total play time: " + _userSession.GetTotalTimeSpan();
                TodayPlayTime.Content = "Session play time: " + _userSession.GetSessionTimeSpan();
                await Task.Delay(1000); 
            }    
        }
    }
}
