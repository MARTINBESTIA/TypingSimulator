using System;
using System.CommandLine;
using System.IO;
using System.Security.Cryptography;
using PeopleDepartment.CommonLibrary;
using static System.Net.WebRequestMethods;

namespace PeopleDepartment.ReportConsoleApp
{
    public class Program
    {
        public static int Main(string[] args)
        {
            var inputFile = new Option<string>("--input")
            {
                IsRequired = true // povinny argument vygeneroval chatgpt
            };
            var template = new Option<string>("--template")
            {
                IsRequired = true // vygeneroval chatgpt
            };
            var outputFolder = new Option<string>("--output", () => "");
            var rootComand = new RootCommand("Process")
            {
                inputFile,
                template,
                outputFolder
            };
            rootComand.SetHandler(WriteOut, inputFile, template, outputFolder);
            return rootComand.Invoke(args);
        }
        private static void WriteOut(string pInputFile, string pTemplate, string pOutputFolder)
        {
            PersonCollection collection = [];
            try
            {
                collection.LoadFromCsv(new FileInfo(pInputFile));
            }
            catch (FileNotFoundException)
            {
                Console.Error.WriteLine($"Csv file or template file not found");
                return;
            }
            catch (Exception)
            {
                Console.WriteLine($"Some Error occured");
                return;
            }
            string reportFolderPath = "";
            if (pOutputFolder != null) // nenasiel som nikde v slidoch o priecinkoch tak som si tuto vetvu vygeneroval AI
            {
                reportFolderPath = Path.Combine(Directory.GetCurrentDirectory(), pOutputFolder);

                if (!Directory.Exists(reportFolderPath))
                {
                    Directory.CreateDirectory(reportFolderPath);
                }
            }
            foreach (var coll in collection.GenerateDepartmentReports())
            {
                using var sw = new StreamWriter(Path.Combine(reportFolderPath, coll.Department + ".txt"));
                foreach (var line in System.IO.File.ReadAllLines(pTemplate))
                {
                    string s = line.Replace("[[Department]]", coll.Department).Replace("[[Head]]", ProccessIndWord(coll.Head)) //.Replace poradené vami
                        .Replace("[[Deputy]]", ProccessIndWord(coll.Deputy)).Replace("[[Secretary]]", ProccessIndWord(coll.Secretary))
                        .Replace("[[NumberOfProfessors]]", coll.NumberOfProfessors.ToString()).Replace("[[NumberOfAssociateProfessors]]", coll.NumberOfAssociateProffesors.ToString())
                        .Replace("[[NumberOfEmployees]]", coll.NumberOfEmployees.ToString()).Replace("[[NumberOfPhDStudents]]", coll.NumberOfPhDStudents.ToString())
                        .Replace("[[Employees]]", string.Join('\n', coll.Employees.Select(p => p.ToFormattedString()))).Replace("[[PhDStudents]]", string.Join('\n', coll.PhDStudents.Select(p => p.ToFormattedString())));
                    if (pOutputFolder == "")
                    {
                        Console.WriteLine(s);
                    }
                    else
                    {
                        sw.WriteLine(s);
                    }
                }
                sw.Close();
            }
        }
        private static string ProccessIndWord(Person? p)
        {
            if (p == null) return "----";
            else
            {
                return p.DisplayName;
            }
        }
    }
}