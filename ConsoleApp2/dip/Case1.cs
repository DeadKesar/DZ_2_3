using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2.dip
{
    internal class Case1
    {
        public interface INotificationSender
        {
            void Send(string recipient, string subject, string message);
            void Log(string log);
        }

        public class EmailSender : INotificationSender
        {
            public string SmtpServer { get; set; }
            public int Port { get; set; }

            public EmailSender(string smtpServer, int port)
            {
                SmtpServer = smtpServer;
                Port = port;
            }

            private void Connect()
            {
                Console.WriteLine("Connecting to SMTP server " + SmtpServer + ":" + Port);
            }

            private void Disconnect()
            {
                Console.WriteLine("Disconnecting from SMTP server " + SmtpServer);
            }

            public void Send(string recipient, string subject, string message)
            {
                Connect();
                Console.WriteLine("Sending email to " + recipient + " with subject " + subject);
                Console.WriteLine("Message: " + message);
                Disconnect();
            }

            public void Log(string log)
            {
                Console.WriteLine("Logging email: " + log);
            }
        }

        public class Notifier
        {
            private readonly INotificationSender _notificationSender;
            public string NotifierName { get; private set; }

            public Notifier(string name, INotificationSender notificationSender)
            {
                NotifierName = name;
                _notificationSender = notificationSender;
            }

            public void Notify(string recipient, string subject, string message)
            {
                _notificationSender.Send(recipient, subject, message);
            }

            public void LogNotification(string log)
            {
                _notificationSender.Log(log);
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
