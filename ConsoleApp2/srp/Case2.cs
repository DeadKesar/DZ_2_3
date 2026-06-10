using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2.dip
{
    internal class Case1
    {
        public interface IEmailSender
        {
            void Connect();
            void SendEmail(string recipient, string subject, string message);
            void Disconnect();
            void LogEmail(string log);
        }

        public class EmailSender : IEmailSender
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

            public void SendEmail(string recipient, string subject, string message)
            {
                Console.WriteLine("Sending email to " + recipient + " with subject " + subject);
            }

            public void Disconnect()
            {
                Console.WriteLine("Disconnecting from SMTP server " + SmtpServer);
            }

            public void LogEmail(string log)
            {
                Console.WriteLine("Logging email: " + log);
            }
        }

        public class Notifier
        {
            private IEmailSender _emailSender;
            public string NotifierName { get; set; }

            public Notifier(string name, IEmailSender emailSender)
            {
                NotifierName = name;
                _emailSender = emailSender;
            }

            public void NotifyByEmail(string recipient, string subject, string message)
            {
                _emailSender.Connect();
                _emailSender.SendEmail(recipient, subject, message);
                _emailSender.Disconnect();
            }

            public void LogNotification(string log)
            {
                _emailSender.LogEmail(log);
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
