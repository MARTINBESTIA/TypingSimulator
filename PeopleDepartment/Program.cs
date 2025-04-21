

using System;
using PeopleDepartment.CommonLibrary;

namespace PeopleDepartment
{
    public class Program
    {
        public static void Main(string[] args)
        {
            PersonCollection collection = new PersonCollection();
            FileInfo file = new("people-fri.csv");
            collection.LoadFromCsv(file);
            foreach (var coll in collection.GenerateDepartmentReports())
            {
                foreach (var report in coll.PhDStudents)
                {
                    Console.WriteLine(report.DisplayName);
                }
            }
            FileInfo fileN = new("people-fri-sorted.csv");
            collection.SaveToCsv(fileN);
        }
    }
}