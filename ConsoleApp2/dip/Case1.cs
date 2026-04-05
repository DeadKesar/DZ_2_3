using System;

namespace ConsoleApp2.dip
{
    internal class Case1
    {
        public interface IMessageSender
        {
            void Connect();
            void Send(string recipient, string subject, string message);
            void Disconnect();
            void Log(string log);
        }

        public class EmailSender : IMessageSender
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
                Console.WriteLine($"Connecting to SMTP server {SmtpServer}:{Port}");
            }

            public void Send(string recipient, string subject, string message)
            {
                Console.WriteLine($"Sending email to {recipient} with subject \"{subject}\"");
                Console.WriteLine($"Message: {message}");
            }

            public void Disconnect()
            {
                Console.WriteLine($"Disconnecting from SMTP server {SmtpServer}");
            }

            public void Log(string log)
            {
                Console.WriteLine($"Logging email: {log}");
            }
        }

        public class Notifier
        {
            private readonly IMessageSender _messageSender;
            public string NotifierName { get; private set; }

            public Notifier(string name, IMessageSender messageSender)
            {
                NotifierName = name;
                _messageSender = messageSender;
            }

            public void NotifyByEmail(string recipient, string subject, string message)
            {
                _messageSender.Connect();
                _messageSender.Send(recipient, subject, message);
                _messageSender.Disconnect();
            }

            public void LogNotification(string log)
            {
                _messageSender.Log(log);
            }

            public void UpdateNotifierName(string newName)
            {
                NotifierName = newName;
                Console.WriteLine($"Notifier name updated to {NotifierName}");
            }

            public void ShowNotifierInfo()
            {
                Console.WriteLine($"Notifier: {NotifierName}");
            }
        }
    }
}
