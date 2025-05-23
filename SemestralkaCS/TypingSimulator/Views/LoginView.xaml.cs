using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Diagnostics;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using TypingSimulator.Windows;
using TypingSimulator.SqlScripts;

namespace TypingSimulator.Views
{
    /// <summary>
    /// Interaction logic for LoginView.xaml
    /// </summary>
    public partial class LoginView : UserControl
    {
        public LoginView()
        {
            InitializeComponent();
            Console.WriteLine("LoginView initialized");
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            if (PasswordBox.Password.Length == 0 || UserNameBox.Text.Length == 0) {
                MessageBox.Show("Please fill in all fields");
            }
            else if (new UsersDAO().UserExists(UserNameBox.Text))
            {
                if (new UsersDAO().CheckPassword(UserNameBox.Text, PasswordBox.Password))
                {
                    ViewNavigator.Navigate(new MainView());
                }
                else
                {
                    MessageBox.Show("Incorrect password");
                }
            }
            else
            {
                MessageBox.Show("User does not exist");
            }
        }

        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            new RegisterWindow().Show();
        }

        private void PasswordBox_GotFocus(object sender, RoutedEventArgs e)
        {
            PasswordWaterMark.Visibility = Visibility.Collapsed;
        }

        private void UserNameBox_GotFocus(object sender, RoutedEventArgs e)
        {
            UserNameWaterMark.Visibility = Visibility.Collapsed;
        }

        private void PasswordBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (PasswordBox.Password.Length == 0)
            {
                PasswordWaterMark.Visibility = Visibility.Visible;
            }
        }

        private void UserNameBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (UserNameBox.Text.Length == 0)
            {
                UserNameWaterMark.Visibility = Visibility.Visible;
            }
        }
    }
}
