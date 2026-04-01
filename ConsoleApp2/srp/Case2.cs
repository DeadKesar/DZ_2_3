using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// srp принцип: один класс - одна задача
namespace ConsoleApp2.srp
{
    class Case2
    {
        class User //Только хранение данных
        {
            protected string Name;
            protected string Email;
            protected string Password;
        }
          class Reg: User{  //Из данных юзера только регистрация 
              public void Register(string name, string email, string password)
            {
                Name = name;
                Email = email;
                Password = password;
                Console.WriteLine("User registered!");
            }
                   }
        class PrintUserinf:Reg {// Только вывод данных из регистрации
            public void PrintUserInfo()
            {
                Console.WriteLine("User: " + Name + " Email: " + Email);
            }
        }
        class MyPassword{// Только именение пароля
            public void ChangePassword(string newPassword)
            {
                Password = newPassword;
                Console.WriteLine("Password changed!");
            }
        }
        class Mailsend:Reg{// Только отправка сообщения
            public void SendEmail(string message)
            {
                Console.WriteLine("Email sent to " + Email + ": " + message);
            }
        }

        public class App
        {
            public void Execute()
            {
                User user = new User();// для корректной работы 
                Reg.Register("Tim", "tim@example.com", "123456"); // смена класса
                PrintUserinf.PrintUserInfo();//смена класаа
                Mailsend.SendEmail("Hello!");// смена класса
            }
        }
    }
}
