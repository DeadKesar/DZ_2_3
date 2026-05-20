using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2.srp
{
    class Case2
    {
        public class User
        {
            public string Name { get; set; }
            public string Email { get; set; }
            public string Password { get; private set; }

            public User(string name, string email, string password)
            {
                Name = name;
                Email = email;
                Password = password;
            }

            public void ChangePassword(string newPassword)
            {
                Password = newPassword;
            }
        }

        public class UserService
        {
            public User Register(string name, string email, string password)
            {
                User user = new User(name, email, password);
                Console.WriteLine("User registered!");
                return user;
            }
        }

        public class EmailService
        {
            public void SendEmail(string email, string message)
            {
                Console.WriteLine($"Email sent to {email}: {message}");
            }
        }

        public class UserPrinter
        {
            public void PrintUserInfo(User user)
            {
                Console.WriteLine($"User: {user.Name} Email: {user.Email}");
            }
        }

        public class App
        {
            public void Execute()
            {
                UserService userService = new UserService();
                User user = userService.Register("Tim", "tim@example.com", "123456");

                UserPrinter printer = new UserPrinter();
                printer.PrintUserInfo(user);

                EmailService emailService = new EmailService();
                emailService.SendEmail(user.Email, "Hello!");
            }
        }
    }
}
