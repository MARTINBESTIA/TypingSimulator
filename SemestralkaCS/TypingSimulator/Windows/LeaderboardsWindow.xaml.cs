using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using TypingSimulator.LeaderBoard;
using TypingSimulator.SqlScripts;

namespace TypingSimulator.Windows
{
    public partial class LeaderboardsWindow : Window
    {
        public string[] LanguageTypes { get; } = { "Python", "Csharp", "Cpp", "Java", "All" };
        public ObservableCollection<User> Users { get; } = new ObservableCollection<User>();
        private IReadOnlyList<User> Efforts { get; } = UsersDAO.GetAllBestEfforts();
        public LeaderboardsWindow()
        {
            InitializeComponent();
            Dropdown.SelectedIndex = 4;
            DataContext = this;
            FilterLeaderboards();
        }
        private void Dropdown_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            FilterLeaderboards();
        }
        private void FilterLeaderboards()
        {
            List<User>? userss = new List<User>();
            if (Dropdown.SelectedIndex < 0 || Dropdown.SelectedIndex == 4)
            {
                userss = Efforts.OrderByDescending(user => user.Score).ToList();
            }
            else
            {
                userss = Efforts.Where(user => user.Language == LanguageTypes[Dropdown.SelectedIndex])
                    .OrderByDescending(user => user.Score)
                    .ToList();
            }
            Users.Clear();
            foreach (var user in userss) { 
                Users.Add(user);
            }
        }
    }
}
