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
        public bool fileSaved = false;
        public PersonCollection PersonList { get; set; } 
        public MainWindow()
        {
            InitializeComponent();
            PersonList = [];

            DataContext = this;
            PersonList.CollectionChanged += SetWindowChanged;
            PersonList.CollectionChanged += UpdateCount;
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
            new DepartmentViewer(PersonList).ShowDialog();
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
        private void FileExit_Click(object sender, RoutedEventArgs e)
        {
            bool saved = false;
            if (fileSaved || PersonList.Count == 0) {
                this.Close();
                return;
            };
            if (windowChanged)
            {
                var result = MessageBox.Show("The collection has been modified. Do you want to save it?",
                                            "Save colection", MessageBoxButton.YesNoCancel);
                switch (result)
                {
                    case MessageBoxResult.Yes:
                        saved = SaveFile();
                        break;
                    case MessageBoxResult.No:
                        this.Close();
                        break;
                    case MessageBoxResult.None:
                        break;
                }
            }
            if (saved) this.Close();
        }
        private void SetWindowChanged(object? sender, NotifyCollectionChangedEventArgs e)
        {
            windowChanged = true;
            fileSaved = false;
        }
        private void UpdateCount(object? sender, NotifyCollectionChangedEventArgs e)
        {
            CountText.Text = PersonList.Count.ToString();
        }
        private bool SaveFile()
        {                   // https://learn.microsoft.com/en-us/dotnet/api/microsoft.win32.savefiledialog?view=windowsdesktop-9.0
            SaveFileDialog dlg = new()
            {
                FileName = "Document", // Default file name
                DefaultExt = ".csv", // Default file extension
                Filter = "Text documents (.csv)|*.csv" // Filter files by extension
            };
            // Show save file dialog box
            var result = dlg.ShowDialog();
            if (result.HasValue == false) return false;
            if (result.Value)
            {
                PersonList.SaveToCsv(new FileInfo(dlg.FileName));
                fileSaved = true;
                return true;
            }
            return false;
        }
        private void OpenFile() {

            OpenFileDialog openFileDialog = new()
            {
                InitialDirectory = "c:\\",
                Filter = "csv files (*.csv)|*.csv|All files (*.*)|*.*",
                FilterIndex = 2,
                RestoreDirectory = true
            };
            if (openFileDialog.ShowDialog() == true)
            {
                PersonList.Clear();
                PersonList.LoadFromCsv(new FileInfo(openFileDialog.FileName));
            }
            windowChanged = false;
            fileSaved = true;
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
                        windowChanged = true;
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
                        windowChanged = true;
                        break;
                }
                if (result == MessageBoxResult.Yes && saved)
                    PersonList.Clear();

                    windowChanged = false;
            }
            if (fileSaved)
            {
                PersonList.Clear();
                windowChanged = false;
            }
        }
        private void Add_Click(object sender, RoutedEventArgs e)
        {
            new AddPersonDialog(PersonList, null).ShowDialog();
        }
        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            var selected = (Person)itemsControl.SelectedItem;
            if (selected != null)
            {
                new AddPersonDialog(PersonList, selected).ShowDialog();
            }
            itemsControl.Items.Refresh();
        }
        private void Remove_Click(object sender, RoutedEventArgs e)
        {
            Person selected = (Person)itemsControl.SelectedItem;
            if (selected == null)
            {
                MessageBox.Show("No person selected");
                return;
            }
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
        private void ItemsControl_Selected(object sender, RoutedEventArgs e)
        {
            Person selected = (Person)itemsControl.SelectedItem;
            if (selected == null)
            {
                editButton.Opacity = 0.5;
                removeButton.Opacity = 0.5;
                dockEdit.Opacity = 0.5;
                dockRemove.Opacity = 0.5;
                editButton.IsEnabled = false;
                removeButton.IsEnabled = false;
                dockEdit.IsEnabled = false;
                dockRemove.IsEnabled = false;
            }
            else
            {
                editButton.Opacity = 1;
                removeButton.Opacity = 1;
                dockEdit.Opacity = 1;
                dockRemove.Opacity = 1;
                editButton.IsEnabled = true;
                removeButton.IsEnabled = true;
                dockEdit.IsEnabled = true;
                dockRemove.IsEnabled = true;
            }
        }
        private void ShowAboutWindow_Click(object sender, RoutedEventArgs e)
        {
           new AboutWindow().ShowDialog();
        }
    }
}