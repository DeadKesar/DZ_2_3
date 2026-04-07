using System;

namespace ConsoleApp2.srp
{
    class User
    {
        public string Name;
        public string Email;
        public string Password;
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
    class EmailService
    {
        public void SendEmail(string email, string message)
        {
            Console.WriteLine("Email sent to " + email + ": " + message);
        }
    }
    class UserPrinter
    {
        public void Print(User user)
        {
            Console.WriteLine("User: " + user.Name + " Email: " + user.Email);
        }
    }

    public class App
    {
        public void Execute()
        {
            User user = new User();

            UserService userService = new UserService();
            EmailService emailService = new EmailService();
            UserPrinter printer = new UserPrinter();

            userService.Register(user, "Tim", "tim@example.com", "123456");
            printer.Print(user);
            emailService.SendEmail(user.Email, "Hello!");
        }
    }
}
