using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2.srp
{
    class Case4
    {
        class Employee
        {
            public string Name;
            public double Salary;

            public void SetSalary(double amount)
            {
                Salary = amount;
            }

            public void PrintInfo()
            {
                Console.WriteLine("Employee: " + Name + " Salary: $" + Salary);
            }

            public void SaveToFile()
            {
                File.WriteAllText("employee.txt", Name + " - " + Salary);
                Console.WriteLine("Employee saved to file!");
            }

            public void LoadFromFile()
            {
                string data = File.ReadAllText("employee.txt");
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
                emp.PrintInfo();
                emp.SaveToFile();
            }
        }
    }

    class Case4Fixed
    {
        //зарплата указывается в конструкторе, оставил только метод вывода информации
        class Employee
        {
            public string Name;
            public double Salary;

            public Employee(double amount)
            {
                Salary = amount;
            }

            public void PrintInfo()
            {
                Console.WriteLine("Employee: " + Name + " Salary: $" + Salary);
            }
        }

        //класс для работы с файлами
        public class FileService{
            public void SaveToFile(Employee employee)
            {
                File.WriteAllText("employee.txt", employee.Name + " - " + employee.Salary);
                Console.WriteLine("Employee saved to file!");
            }

            public void LoadFromFile()
            {
                string data = File.ReadAllText("employee.txt");
                Console.WriteLine("Loaded: " + data);
            }
        }

        class Program
        {
            static void Main()
            {
                var emp = new Employee(5000);
                emp.Name = "John";
                emp.PrintInfo();

                var fileService = new FileService();
                fileService.SaveToFile(emp);
            }
        }
    }
}
