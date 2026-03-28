using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2.srp
{
    class Case2
    {
        // Унарный акк
        public class User
        {
            public string Name { get; set; } // Поставил публичный сет, так как это просто класс-хранилище
            public string Email { get; set; }
            public string Password { get; set; }

            public User(string name, string email, string password)
            {
                Name = name;
                Email = email;
                Password = password;
            }
        }

        // Класс регистрационной службы
        public class UserRegistrationService
        {
            public User Register(string name, string email, string password)
            {
                var user = new User(name, email, password);
                Console.WriteLine("User registered!");
                return user;
            }

            public void ChangePassword(User user, string newPassword)
            {
                user.Password = newPassword;
                Console.WriteLine("Password changed!");
            }
        }

        // Класс-справка
        public class UserPrinter
        {
            public void Print(User user)
            {
                Console.WriteLine("User: " + user.Name + " Email: " + user.Email);
            }
        }

        // Класс для почты
        public class EmailService
        {
            public void SendEmail(string email, string message)
            {
                Console.WriteLine("Email sent to " + email + ": " + message);
            }
        }

        public class App
        {
            public void Execute()
            {
                var registrationService = new UserRegistrationService();
                var user = registrationService.Register("Tim", "tim@example.com", "123456");

                var printer = new UserPrinter();
                printer.Print(user);

                var emailService = new EmailService();
                emailService.SendEmail(user.Email, "Hello!");
            }
        }
    }
}
