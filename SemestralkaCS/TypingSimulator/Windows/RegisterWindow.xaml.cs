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
using System.Windows.Shapes;
using TypingSimulator.SqlScripts;

namespace TypingSimulator.Windows
{
    /// <summary>
    /// Interaction logic for RegisterWindow.xaml
    /// </summary>
    public partial class RegisterWindow : Window
    {
        public RegisterWindow()
        {
            InitializeComponent();
        }

        private void RWOKbutton_Click(object sender, RoutedEventArgs e)
        {
            if (UsernameBox.Text.Length == 0 || RWConfirmpasswordBox.Password.Length == 0 || RWPasswordBox.Password.Length == 0) { 
                MessageBox.Show("Please fill in all fields");
                return;
            }
            if (RWConfirmpasswordBox.Password != RWPasswordBox.Password) { 
                MessageBox.Show("Passwords do not match");
                return;
            }
            if (new UsersDAO().UserExists(UsernameBox.Text))
            {
                MessageBox.Show("Username already exists");
                return;
            }
            new UsersDAO().InsertUser(UsernameBox.Text, RWPasswordBox.Password);
            MessageBox.Show("User succesfully created!");
            this.Close();
        }
    }
}
