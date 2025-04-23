using System;
using System.Collections.Specialized;
using System.IO;
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
using Microsoft.Win32;
using PeopleDepartment.CommonLibrary;

namespace PeopleDepartment.EditorWpfApp
{
    
    public partial class MainWindow : Window
    {
        public bool windowChanged = false;
        public PersonCollection PersonList { get; set; } 
        public MainWindow()
        {
            InitializeComponent();
            PersonList = [];

            DataContext = this;
            PersonList.CollectionChanged += SetWindowChanged;
        }
        

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void New_Click(object sender, RoutedEventArgs e)
        {
            NewFile();
        }

        private void Open_Click(object sender, RoutedEventArgs e) // https://learn.microsoft.com/en-us/dotnet/api/system.windows.forms.openfiledialog?view=windowsdesktop-9.0
        {
            OpenFile();
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            SaveFile();
        }

        private void View_Click(object sender, RoutedEventArgs e)
        {

        }

        private void FileNew_Click(object sender, RoutedEventArgs e)
        {
            NewFile();
        }

        private void FileOpen_Click(object sender, RoutedEventArgs e)
        {
            OpenFile();
        }

        private void FileSave_Click(object sender, RoutedEventArgs e)
        {
            SaveFile();
        }

        private void FilePrint_Click(object sender, RoutedEventArgs e)
        {

        }

        private void FileExit_Click(object sender, RoutedEventArgs e)
        {

        }

        private void SetWindowChanged(object? sender, NotifyCollectionChangedEventArgs e)
        {
            windowChanged = true;
        }
        private bool SaveFile()
        {                   // https://learn.microsoft.com/en-us/dotnet/api/microsoft.win32.savefiledialog?view=windowsdesktop-9.0
            SaveFileDialog dlg = new();
            dlg.FileName = "Document"; // Default file name
            dlg.DefaultExt = ".csv"; // Default file extension
            dlg.Filter = "Text documents (.csv)|*.csv"; // Filter files by extension

            // Show save file dialog box
            var result = dlg.ShowDialog();

            // Process save file dialog box results
            if (result.Value)
            {
                PersonList.SaveToCsv(new FileInfo(dlg.FileName));
                string filename = dlg.FileName;
                return true;
            }
            return false;
        }
        private void OpenFile() {
            var fileContent = string.Empty;
            var filePath = string.Empty;

            OpenFileDialog openFileDialog = new();
            openFileDialog.InitialDirectory = "c:\\";
            openFileDialog.Filter = "csv files (*.csv)|*.csv|All files (*.*)|*.*";
            openFileDialog.FilterIndex = 2;
            openFileDialog.RestoreDirectory = true;

            if (openFileDialog.ShowDialog() == true)
            {
                filePath = openFileDialog.FileName;
                PersonList.LoadFromCsv(new FileInfo(filePath));
            }
        }
        private void NewFile() {
            if (windowChanged)
            {
                bool saved = false;
                var result = MessageBox.Show("The collection has been modified. Do you want to save it?",
                                            "Save colection", MessageBoxButton.YesNo);
                switch (result)
                {
                    case MessageBoxResult.Cancel:
                        break;
                    case MessageBoxResult.Yes:
                        saved = SaveFile();
                        if (!saved)
                        {
                            MessageBox.Show("File not saved");
                            return;
                        }
                        break;
                    case MessageBoxResult.No:
                        break;
                }
                if (result == MessageBoxResult.Yes && saved)
                    PersonList.Clear();
                    windowChanged = false;
            }
            else
            {
                PersonList.Clear();
                windowChanged = false;
            }
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new AddPersonDialog(PersonList, null).ShowDialog();
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            var selected = (Person)itemsControl.SelectedItem;
            if (selected != null)
            {
                var dialog = new AddPersonDialog(PersonList, selected).ShowDialog();
            }
        }

        private void Remove_Click(object sender, RoutedEventArgs e)
        {
            Person selected = (Person)itemsControl.SelectedItem;
            MessageBoxResult result = MessageBox.Show(
                $"Do you want to delete the selected person ({selected.DisplayName})",
                "Remove person",
                MessageBoxButton.YesNo,
                MessageBoxImage.Question // poradilo AI tento riadok
            );

            if (result == MessageBoxResult.Yes)
            {
                PersonList.Remove(selected);
                itemsControl.Items.Refresh();
            }
        }
    }
}