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
                    string[] splittedLine = line.Split(' ');

                    foreach (var word in splittedLine)
                    {
                        string word1 = ProcessWord(word, coll);
                        if (pOutputFolder ==  "")
                        {
                            Console.Write(word1 + " ");
                        }
                        else
                        {
                            sw.Write(word1 + " ");
                        }
                    }
                    if (pOutputFolder == "")
                    {
                        Console.WriteLine();
                    }
                    else
                    {
                        sw.WriteLine();
                    }
                }
                sw.Close();
            }
        }

        private static string ProcessWord(string word, DepartmentReport report)
        {
            switch (word)
            {
                case "[[Department]]":
                    return report.Department;
                case "[[Head]]":
                    if (report.Head == null)
                    {
                        return "---";
                    }
                    return report.Head.DisplayName;
                case "[[Deputy]]":
                    if (report.Deputy == null)
                    {
                        return "---";
                    }
                    return report.Deputy.DisplayName;
                case "[[Secretary]]":
                    if (report.Secretary == null)
                    {
                        return "---";
                    }
                    return report.Secretary.DisplayName;
                case "[[NumberOfProfessors]]":
                    return report.NumberOfProfessors.ToString();
                case "[[NumberOfAssociateProfessors]]":
                    return report.NumberOfAssociateProffesors.ToString();
                case "[[NumberOfEmployees]]":
                    return report.NumberOfEmployees.ToString();
                case "[[NumberOfPhDStudents]]":
                    return report.NumberOfPhDStudents.ToString();
                case "[[Employees]]":
                    return string.Join('\n', report.Employees.Select(p => p.ToFormattedString()));
                case "[[PhDStudents]]":
                    return string.Join('\n', report.PhDStudents.Select(p => p.ToFormattedString()));
                default:
                    return word;
            }
        }
    }
}
