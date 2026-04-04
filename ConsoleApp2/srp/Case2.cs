using System; // удаление всего лишнего

namespace ConsoleApp2.srp
{
    class Case2
    {
        class User // класс только для сущности пользователя
        { // гарантируем что строки не null 
            public string Name = string.Empty;
            public string Email = string.Empty;
            public string Password = string.Empty;
        }

        class UserManager // отдельный класс для управлением пользователем
        {
            public User Register(string name, string email, string password)
            {
                User user = new User();
                user.Name = name;
                user.Email = email;
                user.Password = password;
                Console.WriteLine("User registered!");
                return user;
            }

            public void ChangePassword(User user, string newPassword)
            {
                user.Password = newPassword;
                Console.WriteLine("Password changed!");
            }
        }

        class UserPrinter // отдельный класс для печати пользователя
        {
            public void Print(User user)
            {
                Console.WriteLine("User: " + user.Name + " Email: " + user.Email);
            }
        }

        class EmailManager // отдельный класс для работы с почтой
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
                UserManager userManagerService = new UserManager();

                User user = userManagerService.Register("Tim", "tim@example.com", "123456");

                UserPrinter printer = new UserPrinter();
                printer.Print(user);

                EmailManager emailSender = new EmailManager(); 
                emailSender.SendEmail(user.Email, "Hello");
            }
        }
    }
}
