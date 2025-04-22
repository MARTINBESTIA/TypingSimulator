using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeopleDepartment.CommonLibrary
{
    public class PersonCollection : ICollection<Person>, INotifyCollectionChanged
    {
        private readonly List<Person> _people = [];
        public int Count => _people.Count;
        public bool IsReadOnly => false;

        public event NotifyCollectionChangedEventHandler? CollectionChanged;
        public void Add(Person item)
        {
            _people.Add(item);
            CollectionChanged?.Invoke(this, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add, item));// vygenereovane
        }

        public void Clear()
        {
            CollectionChanged?.Invoke(this, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Remove, _people)); // vygenereovane
            _people.Clear();       
        }

        public bool Contains(Person item)
        {
            return _people.Contains(item);
        }

        public void CopyTo(Person[] array, int arrayIndex)
        {
            _people.CopyTo(array, arrayIndex);
        }
        public IEnumerator<Person> GetEnumerator()
        {
            return _people.GetEnumerator();
        }

        public bool Remove(Person item)
        {
            CollectionChanged?.Invoke(this, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add, item)); // vygenereovane
            return _people.Remove(item);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return (IEnumerator)_people; // neviem neviem ci je toto dobre
        }
        public void LoadFromCsv(FileInfo csvFile) 
        {
            using var sr = new StreamReader(csvFile.Name);
            string? line;
            line = sr.ReadLine();
            while ((line = sr.ReadLine()) != null)
            {
                string[] values = line.Split(';');
                Add(new Person(values[0], values[1], values[2], values[3], values[4], values[5]));
            }
            sr.Close();
        }
        public void SaveToCsv(FileInfo csvFile)
        {
            using var sw = new StreamWriter(csvFile.Name);
            foreach (var person in this)
            {
                sw.WriteLine($"{person.FirstName};{person.LastName};{person.DisplayName};{person.Position};{person.Email};{person.Department}");
            }
            sw.Close();
        }
        public DepartmentReport[] GenerateDepartmentReports() 
        {
            DepartmentReport[] report = new DepartmentReport[SortedDepartmentNames().Length];
            for (int i = 0; i < SortedDepartmentNames().Length; i++)
            {
                string dep = SortedDepartmentNames()[i];
                report[i] = new DepartmentReport(
                    dep,
                    GetHeadOfDepartment(dep),
                    GetDeputyOfDepartment(dep),
                    GetSecretaryOfDepartment(dep),
                    GetNumberOfProfessors(dep),
                    GetNumberOfAssociateProfessors(dep),
                    GetNumberOfEmployees(dep),
                    GetNumberOfPhDStudents(dep),
                    GetEmployees(dep),
                    GetPhDStudents(dep)
                );
            }
            return report;
        }

        private int GetNumberOfPhDStudents(string dep)
        {
            return _people
                .Where(p => p.Department == dep && p.Position == "doktorand")
                .Count();
        }

        private int GetNumberOfEmployees(string dep)
        {
            return _people
                .Where(p => p.Department == dep && p.Position != "doktorand")
                .Count();
        }

        private string[] SortedDepartmentNames() { 
            return [.. _people
                .Select(p => p.Department)
                .Distinct()
                .OrderBy(p => p)];
        }
        private Person? GetHeadOfDepartment(string dep) 
        { 
            return _people
                .Where(p => p.Department == dep)
                .FirstOrDefault(p => p.Position == "vedúci");
        }
        private Person? GetDeputyOfDepartment(string dep)
        {
            return _people
                .Where(p => p.Department == dep)
                .FirstOrDefault(p => p.Position == "zástupca vedúceho");
        }
        private Person? GetSecretaryOfDepartment(string dep)
        {
            return _people
                .Where(p => p.Department == dep)
                .FirstOrDefault(p => p.Position == "sekretárka");
        }
        private int GetNumberOfProfessors(string dep)
        {
            return _people
                .Where(p => p.Department == dep && p.TitleBefore != null)
                .Count(p => p.TitleBefore!.Split(' ')[0] == "prof.");
        }
        private int GetNumberOfAssociateProfessors(string dep)
        {
            return _people
                .Where(p => p.Department == dep && p.TitleBefore != null)
                .Count(p => p.TitleBefore!.Split(' ')[0] == "doc.");
        }
        private Person[] GetEmployees(string dep) 
        { 
            return [.. _people
                .Where(p => p.Department == dep && p.Position != "doktorand")
                .OrderBy(p => p.FirstName)
                .ThenBy(p => p.LastName)];
        }
        private Person[] GetPhDStudents(string dep)
        {
            return [.. _people
                .Where(p => p.Department == dep && p.Position == "doktorand")
                .OrderBy(p => p.FirstName)
                .ThenBy(p => p.LastName)];
        }
    }
}
