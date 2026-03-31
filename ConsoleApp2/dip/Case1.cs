using System;

namespace ConsoleApp2.dip
{
    internal class Case1
    {
        public interface IMessageSender
        {
            void Send(string recipient, string subject, string message);
        }
        
        public interface ILogger
        {
            void Log(string message);
        }
        
        public class EmailLogger : ILogger
        {
            public void Log(string message)
            {
                Console.WriteLine("Logging email: " + message);
            }
        }
        
        public class EmailSender : IMessageSender
        {
            public string SmtpServer { get; private set; } 
            public int Port { get; private set; }

            public EmailSender(string smtpServer, int port)
            {
                SmtpServer = smtpServer;
                Port = port;
            }

            public void Send(string recipient, string subject, string message)
            {
                Connect();
                Console.WriteLine("Sending email to " + recipient + " with subject " + subject + " with message: " + message);
                Disconnect();
            }
            
            private void Connect() 
            {
                Console.WriteLine("Connecting to SMTP server " + SmtpServer + ":" + Port);
            }
            
            private void Disconnect()
            {
                Console.WriteLine("Disconnecting from SMTP server " + SmtpServer);
            }
        }

        public class Notifier
        {
            private readonly IMessageSender _messageSender;
            private readonly ILogger _logger;
            public string NotifierName { get; private set; }

            public Notifier(string name, IMessageSender messageSender, ILogger logger)
            {
                NotifierName = name;
                _messageSender = messageSender;
                _logger = logger; 
            }

            public void Notify(string recipient, string subject, string message)
            {
                _messageSender.Send(recipient, subject, message);
            }

            public void LogNotification(string log)
            {
                _logger.Log(log);
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
