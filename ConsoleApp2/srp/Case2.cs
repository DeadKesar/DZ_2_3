using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Authentication.ExtendedProtection.Configuration;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ConsoleApp2.srp
{
    class Case2
    {
        // До этого класс User был god object. Теперь у нас разделены обязанности.

        // 1-ый класс для хранения
        // 2-ой для регистрации пользователя
        // 3-ий для имэйлов

        // Класс для хранения встроенных(первоначальных) типов данных пользователя (int, string, bool и т.д.)
        class User
        {
            public string Name;
            public string Email;
            public string Password;

            public User(string name, string email, string password)
            {
                Name = name;
                Email = email;
                Password = password;
            }
            public void PrintUserInfo()
            {
                Console.WriteLine("User: " + Name + " Email: " + Email);
            }
        }

        // Класс для регистрации пользователя
        class UserHandler
        {
            public User Register(string name, string email, string password)
            {
                User user = new User(name, email, password);
                Console.WriteLine("User registered!");
                return user;
            }

            public void ChangePassword(User user, string new_password)
            {
                user.Password = new_password;
                Console.WriteLine("Password changed!");
            }

        }

        // Класс для работы с имэйлами
        class EmailHandler
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
                UserHandler userhandler = new UserHandler();
                EmailHandler emailhandler = new EmailHandler();

                User user = userhandler.Register("Arseniy Kharin", "trololololololil@kester.ru", "adji_kester123");
                user.PrintUserInfo();
                emailhandler.SendEmail(user, "Hello, Kester! I wan't to enter the Military Training Center");
            }
        }
    }
}
