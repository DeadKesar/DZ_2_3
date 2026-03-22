using System;

namespace ConsoleApp2.srp
{
    class Case2
    {
        class User
        {
            public string Name { get; set; } = "";
            public string Email { get; set; } = "";
            public string Password { get; set; } = "";
        }

        class UserService
        {
            public void Register(User user, string name, string email, string password)
            {
                user.Name = name;
                user.Email = email;
                user.Password = password;
                Console.WriteLine("User registered!");
            }

            public void ChangePassword(User user, string newPassword)
            {
                user.Password = newPassword;
                Console.WriteLine("Password changed!");
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
                User user = new User();
                UserService userService = new UserService();
                UserPrinter userPrinter = new UserPrinter();
                EmailService emailService = new EmailService();

                userService.Register(user, "Tim", "tim@example.com", "123456");
                userPrinter.PrintUserInfo(user);
                emailService.SendEmail(user, "Hello!");
            }
        }
    }
}