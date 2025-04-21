using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeopleDepartment.CommonLibrary
{
    public class DepartmentReport(string department, Person? head, Person? deputy, Person? secretary, int numberOfProfessors, int numberOfAssociateProffesors, int numberOfEmployees, int numberOfPhDStudent, IEnumerable<Person> employees, IEnumerable<Person> phDStudents)
    {
        public string Department { get; } = department;
        public Person? Head { get; } = head;
        public Person? Deputy { get; } = deputy;
        public Person? Secretary { get; } = secretary;
        public int NumberOfProfessors { get; } = numberOfProfessors;
        public int NumberOfAssociateProffesors { get; } = numberOfAssociateProffesors;
        public int NumberOfEmployees { get; } = numberOfEmployees;
        public int NumberOfPhDStudents { get; } = numberOfPhDStudent;
        public IEnumerable<Person> Employees { get; } = employees;
        public IEnumerable<Person> PhDStudents { get; } = phDStudents;
    }
}
