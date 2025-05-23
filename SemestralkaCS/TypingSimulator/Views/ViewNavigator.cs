using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;

namespace TypingSimulator.Views
{
    public static class ViewNavigator
    {
        public static void Navigate(UserControl view)
        {
            var mainWindow = (MainWindow)Application.Current.MainWindow;
            mainWindow.MainFrame.Content = view;
        }
    }
}
