using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2.srp
{
    class Case2
    {
        class User
        {
            public string Name;
            public string Email;
            public string Password;

            public void Register(string name, string email, string password)
            {
                Name = name;
                Email = email;
                Password = password;
                Console.WriteLine("User registered!");
            }

            public void PrintUserInfo()
            {
                Console.WriteLine("User: " + Name + " Email: " + Email);
            }

            public void ChangePassword(string newPassword)
            {
                Password = newPassword;
                Console.WriteLine("Password changed!");
            }

            public void SendEmail(string message)
            {
                Console.WriteLine("Email sent to " + Email + ": " + message);
            }
        }

        public class App
        {
            public void Execute()
            {
                User user = new User();
                user.Register("Tim", "tim@example.com", "123456");
                user.PrintUserInfo();
                user.SendEmail("Hello!");
            }
        }
    }

    //класс User нарушал SRP
    //изменил также класс App
    class Case2Fixed 
    {
        public class User
        {
            public string Name;
            public string Email;
            public string Password;

            //вынес регистрацию в конструктор для удосбтва
            public User(string name, string email, string password)
            {
                Name = name;
                Email = email;
                Password = password;
            }

            //вывод информации о пользователе оставил без изменениый, тк не является нарушением SRP
            public void PrintUserInfo()
            {
                Console.WriteLine("User: " + Name + " Email: " + Email);
            }
        }

        //класс для смены пароля
        public class PasswordService
        {
            public void ChangePassword(User user, string newPassword)
            {
                user.Password = newPassword;
                Console.WriteLine("Password changed!");
            }
        }

        //класс для отправки email
        public class EmailService
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
                // Создание пользователя
                var user = new User("Tim", "tim@example.com", "123456");
                
                // Вывод информации
                user.PrintUserInfo();
                
                // Отправка email
                var emailService = new EmailService();
                emailService.SendEmail(user, "Hello!");
                
                // Смена пароля
                var passwordService = new PasswordService();
                passwordService.ChangePassword(user, "blabla");
            }
        }
    }
}
