using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2.dip
{
    internal class Case1
    {
        public interface IMessageSender // Добавлен interface по скольку модули верхнего и нижнего уровня должны зависить от абстракции(исходя из принципа DIP)	
        {
            void Connect();
            void SendMessage(string recipient, string subject, string message);
            void Disconnect();
            void LogMessage(string log);
        }
        public class EmailSender : IMessageSender // Добавлена реализация интерфейса
        {
            public string SmtpServer { get; set; } 
            public int Port { get; set; }
            public EmailSender(string smtpServer, int port)
            {
                SmtpServer = smtpServer;
                Port = port;
            }
            public void Connect() 
            {
                Console.WriteLine("Connecting to SMTP server " + SmtpServer + ":" + Port);
            }

            public void SendMessage(string recipient, string subject, string message)
            {
                Console.WriteLine("Sending email to " + recipient + " with subject " + subject);
            }
            public void Disconnect()
            {
                Console.WriteLine("Disconnecting from SMTP server " + SmtpServer);
            }
            public void LogMessage(string log)
            {
                Console.WriteLine("Logging email: " + log);
            }
        }
        public class Notifier
        {
            private IMessageSender _messageSender; // изменил тип поля и имя переменной
            public string NotifierName { get; set; }
            public Notifier(string name, IMessageSender messageSender) // добален параметр к конструктору
            {
                NotifierName = name;
                _messageSender = messageSender; // сразу передается все значение
            }
            public void NotifyByEmail(string recipient, string subject, string message)
            {
                _messageSender.Connect();
                _messageSender.SendMessage(recipient, subject, message);
                _messageSender.Disconnect();
            }
            public void LogNotification(string log)
            {
                _messageSender.LogMessage(log);
            }
            public void UpdateNotifierName(string newName)
            {
                NotifierName = newName;
                Console.WriteLine("Notifier name updated to " + NotifierName);
            }
            public void ShowNotifierInfo()
            {
                Console.WriteLine("Notifier: " + NotifierName);
            }
        }
    }
}
