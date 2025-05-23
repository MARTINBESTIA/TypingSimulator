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
    public partial class DepartmentViewer : Window
    {
        private readonly DepartmentReport[] _reports;
        private readonly PersonCollection _personCollection;
        private int _selectedIndex = 0;
        private bool _resizing = false;
        public IEnumerable<Person>? Employees { get; set; }
        public IEnumerable<Person>? PhDStudents { get; set; }
        public string[] DepartmentNames { get; }
        public DepartmentViewer(PersonCollection people)
        {
            _personCollection = people;
            _reports = _personCollection.GenerateDepartmentReports();
            DepartmentNames = _personCollection.Select(p => p.Department).OrderBy(p => p).Distinct().ToArray();
            InitializeComponent();

            DataContext = this;
            _selectedIndex = 0;
            Dropdown.ItemsSource = DepartmentNames;
            Dropdown.SelectedIndex = _selectedIndex;
            Dropdown.Items.Refresh();
            Update();
        }
        private void Update()
        {
            _selectedIndex = Dropdown.SelectedIndex;
            if (_reports.Length == 0) return;
            Head.Content = _reports[_selectedIndex].Head != null ? _reports[_selectedIndex].Head!.DisplayName : ""; // mam tu !. operator pretoze doslova to ternarne kontrolujem ci tam je null alebo nie visual studio nechape
            Deputy.Content = _reports[_selectedIndex].Deputy != null ? _reports[_selectedIndex].Deputy!.DisplayName : "";
            Secretary.Content = _reports[_selectedIndex].Secretary != null ? _reports[_selectedIndex].Secretary!.DisplayName : "";
            Employees = _reports[_selectedIndex].Employees;
            PhDStudents = _reports[_selectedIndex].PhDStudents;
            EmployeesCount.Content = _reports[_selectedIndex].NumberOfEmployees.ToString();
            PhDsCount.Content = _reports[_selectedIndex].NumberOfPhDStudents.ToString();
            itemsControlEmployees.ItemsSource = Employees; // Tieto 2 riadky mi vygeneroval copilot, vobec neviem preco ale opravilo mi to problem s akutalizovanim zoznamu
            itemsControlPhDs.ItemsSource = PhDStudents;    // studentov a zamestnancov, bindujem v xaml tak neviem preco nestaci zmenit hodnotu fieldu
            Dropdown.Items.Refresh();
            itemsControlEmployees.Items.Refresh();
            itemsControlPhDs.Items.Refresh();
        }

        private void Dropdown_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            _selectedIndex = Dropdown.SelectedIndex;
            Update();
        }

        private void Window_SizeChanged(object sender, SizeChangedEventArgs e) // celu tuto metodu poradilo AI
        {
            if (_resizing) return;

            _resizing = true;
            double desiredWidth = e.NewSize.Height * 2;
            double newHeight = e.NewSize.Width / 2;

            if (e.WidthChanged)
            {
                this.Height = newHeight;
            }
            else if (e.HeightChanged)
            {
                this.Width = desiredWidth;
            }

            _resizing = false;
        }
    }
}
