using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using BigLib;

namespace cvicenie5
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            /*
            myTextBox.Text = "Alohaaa";
            myTextBox.Width = 100;
            myTextBox.Height = 20;
            myTextBox.VerticalAlignment = VerticalAlignment.Center;
            myTextBox.HorizontalAlignment = HorizontalAlignment.Center;*/
            myButton.HorizontalAlignment = HorizontalAlignment.Left;
            myButton.VerticalAlignment = VerticalAlignment.Center;
            myButton.Width = 100;
            myButton.Height = 100;

            
        }
        private void MyButton_Click(object sender, RoutedEventArgs e)
        {
            // Display the content of the TextBox in a message box
            MessageBox.Show($"Eyouuu broski whatdup", "Okienko");
        }
        private void SwapColorOnBackground(object sender, RoutedEventArgs e)
        {
            // Display the content of the TextBox in a message box
            MessageBoxResult result = MessageBox.Show("Do you want to change the background color to blue?","Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes) {
                this.Background = Brushes.DeepSkyBlue;
            }
        }
        private void AddPersonClick(object sender, RoutedEventArgs e)
        {
            PersonWindow personWindow = new PersonWindow();
            if (personWindow.ShowDialog() == true)
            {
                personListBox.Items.Add(personWindow.person);
            }

        }

    }
        
}