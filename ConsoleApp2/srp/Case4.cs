using System;
using System.IO;

namespace ConsoleApp2.srp
{
    class Case4
    {
        class Employee
        {
            public string Name { get; set; }
            public double Salary { get; private set; }

            public Employee(string name, double salary)
            {
                Name = name;
                Salary = salary;
            }

            public void SetSalary(double amount)
            {
                Salary = amount;
            }
        }

        class EmployeePrinter
        {
            public void PrintInfo(Employee employee)
            {
                Console.WriteLine($"Employee: {employee.Name} Salary: ${employee.Salary}");
            }
        }

        class EmployeeFileRepository
        {
            private readonly string _filePath;

            public EmployeeFileRepository(string filePath)
            {
                _filePath = filePath;
            }

            public void Save(Employee employee)
            {
                File.WriteAllText(_filePath, $"{employee.Name} - {employee.Salary}");
                Console.WriteLine("Employee saved to file!");
            }

            public string Load()
            {
                string data = File.ReadAllText(_filePath);
                Console.WriteLine("Loaded: " + data);
                return data;
            }
        }

        class Program
        {
            static void Main()
            {
                Employee emp = new Employee("John", 5000);
                EmployeePrinter printer = new EmployeePrinter();
                EmployeeFileRepository repository = new EmployeeFileRepository("employee.txt");
                printer.PrintInfo(emp);
                repository.Save(emp);
                repository.Load();
            }
        }
    }
}
