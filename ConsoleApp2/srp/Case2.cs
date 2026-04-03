using System;

namespace ConsoleApp2.srp
{
    class Case2
    {

        public class User
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
            }
        }

        public class UserService
        {
            public User Register(string name, string email, string password)
            {
                var user = new User(name, email, password);
                Console.WriteLine("User registered!"); 
                return user;
            }
        }

        public class EmailService
        {
            public void SendEmail(string toAddress, string message)
            {
                Console.WriteLine($"Email sent to {toAddress}: {message}");
            }
        }

        
        public class UserConsoleView
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
                var userService = new UserService();
                var emailService = new EmailService();
                var userView = new UserConsoleView();

                User user = userService.Register("Tim", "tim@example.com", "123456");
                userView.PrintUserInfo(user);
                emailService.SendEmail(user.Email, "Hello!");
            }
        }
    }
}
