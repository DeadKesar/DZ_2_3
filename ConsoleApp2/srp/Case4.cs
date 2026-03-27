using System;
using System.IO;

namespace ConsoleApp2.srp
{
    class Case4
    {
        // только данные сотрудника
        class Employee
        {
            public string Name;
            public double Salary;

            public void SetSalary(double amount)
            {
                Salary = amount;
            }
        }

        // только отображение
        class EmployeePrinter
        {
            public void PrintInfo(Employee emp)
            {
                Console.WriteLine("Employee: " + emp.Name + " Salary: $" + emp.Salary);
            }
        }

        // только файловые операции
        class EmployeeRepository
        {
            private const string FilePath = "employee.txt";

            public void Save(Employee emp)
            {
                File.WriteAllText(FilePath, emp.Name + " - " + emp.Salary);
                Console.WriteLine("Employee saved to file!");
            }

            public void Load()
            {
                string data = File.ReadAllText(FilePath);
                Console.WriteLine("Loaded: " + data);
            }
        }

        class Program
        {
            static void Main()
            {
                Employee emp = new Employee();
                emp.Name = "John";
                emp.SetSalary(5000);

                EmployeePrinter printer = new EmployeePrinter();
                printer.PrintInfo(emp);

                EmployeeRepository repo = new EmployeeRepository();
                repo.Save(emp);
            }
        }
    }
}
