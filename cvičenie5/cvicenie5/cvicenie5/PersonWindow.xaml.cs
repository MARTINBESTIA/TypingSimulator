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
using BigLib;

namespace cvicenie5
{
    /// <summary>
    /// Interaction logic for PersonWindow.xaml
    /// </summary>
    public partial class PersonWindow : Window
    {
        public Person? person;
        public PersonWindow()
        {
            InitializeComponent();
        }
        
        public void OKButton_OnClick(object sender, RoutedEventArgs e) 
        {
            this.person = new Person(FirstNameTextBox.Text, LastNameTextBox.Text, DateTime.Parse(BirthdateDatePicker.Text));
            DialogResult = true;
            Close();
        }

        public void CancelButton_OnClick(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }

    }
}
