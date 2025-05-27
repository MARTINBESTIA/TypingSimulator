using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;
using TypingSimulator.MainViewScripts;

namespace TypingSimulator.Views
{
    public static class ViewNavigator
    {
        private static MainView? _mainView;
        private static LoginView? _loginView;
        public static LoginView? Loginview
        {
            get => _loginView;
            set
            {
                if (_loginView == null && value != null)
                {
                    _loginView = value;
                }
            }
        }

        public static MainView? MainView
        {
            get => _mainView;
            set
            {
                if (_mainView == null && value != null)
                {
                    _mainView = value;
                }
            }
        }
        public static void Navigate(UserControl view)
        {
            var mainWindow = (MainWindow)Application.Current.MainWindow;
            mainWindow.MainFrame.Content = view;
        }
        public static void NavigateToLoginView()
        {
            Loginview ??= new LoginView();
            Navigate(Loginview);
        }
        public static void NavigateToMainView(UserSession session)
        {
            if (MainView == null)
            {
                MainView = new MainView(session);
            }
            else 
            {
                MainView.SwapSession(session);
            }
            Navigate(MainView);
        }
    }
}
