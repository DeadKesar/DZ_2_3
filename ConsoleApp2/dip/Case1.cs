using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// жесткая зависимость Notifier от EmailSender. Заменил на ISender

namespace ConsoleApp2.dip
{
    internal class Case1
    {
        public interface ISender {
            void Send(string recipient, string subject, string message);
            void Log(string log);
        }

        public class EmailSender : ISender
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

            public void Send(string recipient, string subject, string message)
            {
                Console.WriteLine("Sending email to " + recipient + " with subject " + subject);
            }

            public void Disconnect()
            {
                Console.WriteLine("Disconnecting from SMTP server " + SmtpServer);
            }

            public void Log(string log)
            {
                Console.WriteLine("Logging email: " + log);
            }
        }

        public class Notifier
        {
            private ISender _sender;
            public string NotifierName { get; set; }

            public Notifier(string name, ISender sender)
            {
                NotifierName = name;
                _sender = sender;
            }

            public void Notify(string recipient, string subject, string message)
            {
                _sender.Send(recipient, subject, message);
            }

            public void LogNotification(string log)
            {
                _sender.Log(log);
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
