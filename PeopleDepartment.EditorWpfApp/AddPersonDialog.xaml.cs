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
using PeopleDepartment.CommonLibrary;

namespace PeopleDepartment.EditorWpfApp
{
    /// <summary>
    /// Interaction logic for AddPersonDialog.xaml
    /// </summary>
    public partial class AddPersonDialog : Window
    {
        private PersonCollection _personCollection;
        private Person? selectedPerson;
        public AddPersonDialog(PersonCollection collection, Person? selectedPerson)
        {
            InitializeComponent();
            this._personCollection = collection;
            DataContext = this;
            this.selectedPerson = selectedPerson;
            if (selectedPerson != null) {
                FirstNameBox.Text = selectedPerson.FirstName;
                LastNameBox.Text = selectedPerson.LastName;
                DisplayNameBox.Text = selectedPerson.DisplayName;
                PositionBox.Text = selectedPerson.Position;
                EmailBox.Text = selectedPerson.Email;
                TitleBeforeBox.Text = selectedPerson.TitleBefore;
                TitleAfterBox.Text = selectedPerson.TitleAfter;
                DepartmentBox.Text = selectedPerson.Department;
            }
        }

        private void Ok_Click(object sender, RoutedEventArgs e)
        {
            if (selectedPerson != null)
            {
                selectedPerson.Position = PositionBox.Text;
                selectedPerson.Email = EmailBox.Text;
                selectedPerson.Department = DepartmentBox.Text;
                selectedPerson.FirstName = FirstNameBox.Text;
                selectedPerson.LastName = LastNameBox.Text;
                //selectedPerson.TitleBefore = TitleBeforeBox.Text; Opytat sa Totha
                //TitleAfter = TitleAfterBox.Text;
                selectedPerson.DisplayName = TitleBeforeBox.Text + " " + FirstNameBox.Text + " " + LastNameBox.Text + ", " + TitleAfterBox.Text;
                this.DialogResult = true;
            }
            else
            {
                string displayName = TitleBeforeBox.Text + " " + FirstNameBox.Text + " " + LastNameBox.Text + ", " + TitleAfterBox.Text;
                _personCollection.Add(new Person(FirstNameBox.Text, LastNameBox.Text, displayName, PositionBox.Text, EmailBox.Text, DepartmentBox.Text));
                this.DialogResult = true;
            }
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }

        private void UpdateDisplayName(object sender, TextChangedEventArgs e)
        {
            DisplayNameBox.Text = TitleBeforeBox.Text + " " + FirstNameBox.Text + " " + LastNameBox.Text + ", " + TitleAfterBox.Text;
        }
    }
}
