﻿using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using TypingSimulator.Views;
using TypingSimulator.SqlScripts;

namespace TypingSimulator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
            ViewNavigator.Loginview = new LoginView();
            ViewNavigator.MainView = null; 
            ViewNavigator.NavigateToLoginView();
            TableCreations.CreateUserTable();
        }
    }
}