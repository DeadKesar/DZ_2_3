using System;
using System.IO;

namespace ConsoleApp2.srp
{
    class Case4
    {
        class Employee
        {
            public string Name { get; set; } = "";
            public double Salary { get; set; }
        }

        class EmployeeService
        {
            public void SetSalary(Employee employee, double amount)
            {
                employee.Salary = amount;
            }
        }

        class EmployeePrinter
        {
            public void PrintInfo(Employee employee)
            {
                Console.WriteLine("Employee: " + employee.Name + " Salary: $" + employee.Salary);
            }
        }

        class EmployeeFileManager
        {
            private const string FilePath = "employee.txt";

            public void SaveToFile(Employee employee)
            {
                File.WriteAllText(FilePath, employee.Name + " - " + employee.Salary);
                Console.WriteLine("Employee saved to file!");
            }

            public void LoadFromFile()
            {
                string data = File.ReadAllText(FilePath);
                Console.WriteLine("Loaded: " + data);
            }
        }

        public class App
        {
            public void Execute()
            {
                Employee emp = new Employee();
                EmployeeService service = new EmployeeService();
                EmployeePrinter printer = new EmployeePrinter();
                EmployeeFileManager fileManager = new EmployeeFileManager();

                emp.Name = "John";
                service.SetSalary(emp, 5000);

                printer.PrintInfo(emp);
                fileManager.SaveToFile(emp);
            }
        }
    }
}