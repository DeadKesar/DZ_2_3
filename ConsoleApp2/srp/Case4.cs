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
            public string Name { get; private set; }
            public double Salary { get; private set; }

            public void SetSalary(double amount)
            {
                Salary = amount;
            }

            public Employee(string name, double salary)
            {
                Name = name;
                Salary = salary;
            }

        }


        static class EmployeeDisplay
        {
            public static void PrintInfo(Employee employee)
            {
                Console.WriteLine("Employee: " + employee.Name + " Salary: $" + employee.Salary);
            }
        }

        static class EmployeeFiles
        {
            public static void SaveToFile(Employee employee)
            {
                File.WriteAllText("employee.txt", employee.Name + " - " + employee.Salary);
                Console.WriteLine("Employee saved to file!");
            }

            public static void LoadFromFile()
            {
                string data = File.ReadAllText("employee.txt");
                Console.WriteLine("Loaded: " + data);
            }
        }

/* 
1. то, что напрямую не относится к employee, то есть сотруднику, поместил в отдельные статические классы.
2. сделал приватные сеттеры для полей сотрудника.
3. добавил конструктор с параметрами, чтобы было проще инициализировать объект
*/



        class Program
        {
            static void Main()
            {
                Employee emp = new Employee("John", 5000);
                EmployeeDisplay.PrintInfo(emp);
                EmployeeFiles.SaveToFile(emp);
            }
        }
    }
}
