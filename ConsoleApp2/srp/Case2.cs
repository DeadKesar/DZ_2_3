using System;

namespace ConsoleApp2.srp
{
    class Case2
    {
        public class User
        {
            public string Name { get; }
            public string Email { get; }
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

        public class UserRegistrationService
        {
            public User Register(string name, string email, string password)
            {
                var user = new User(name, email, password);
                Console.WriteLine("User registered!");
                return user;
            }
        }

        public class UserPrinter
        {
            public void PrintUserInfo(User user)
            {
                Console.WriteLine($"User: {user.Name} Email: {user.Email}");
            }
        }

        public class EmailService
        {
            public void SendEmail(string email, string message)
            {
                Console.WriteLine($"Email sent to {email}: {message}");
            }
        }

        public class App
        {
            public void Execute()
            {
                var registrationService = new UserRegistrationService();
                var printer = new UserPrinter();
                var emailService = new EmailService();

                User user = registrationService.Register("Tim", "tim@example.com", "123456");
                printer.PrintUserInfo(user);
                emailService.SendEmail(user.Email, "Hello!");

                user.ChangePassword("newStrongPassword");
                Console.WriteLine("Password changed!");
            }
        }
    }
}
