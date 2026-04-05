using System;

namespace ConsoleApp2.srp
{
    class Case2
    {
        class User
        {
            public string Name { get; private set; }
            public string Email { get; private set; }
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
                Console.WriteLine("Password changed!");
            }
        }

        class UserService
        {
            public User Register(string name, string email, string password)
            {
                Console.WriteLine("User registered!");
                return new User(name, email, password);
            }
        }

        class UserPrinter
        {
            public void PrintUserInfo(User user)
            {
                Console.WriteLine("User: " + user.Name + " Email: " + user.Email);
            }
        }

        class EmailService
        {
            public void SendEmail(User user, string message)
            {
                Console.WriteLine("Email sent to " + user.Email + ": " + message);
            }
        }

        public class App
        {
            public void Execute()
            {
                UserService userService = new UserService();
                UserPrinter userPrinter = new UserPrinter();
                EmailService emailService = new EmailService();

                User user = userService.Register("Tim", "tim@example.com", "123456");
                userPrinter.PrintUserInfo(user);
                emailService.SendEmail(user, "Hello!");
            }
        }
    }
}
