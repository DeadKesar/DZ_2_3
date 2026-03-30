using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2.Dip
{
    public interface IMessageSender
    {
        void Send(string recipient, string subject, string message);
    }

    public interface ILogger
    {
        void Log(string message);
    }

    public sealed class EmailServerSettings
    {
        public string SmtpServer { get; }
        public int Port { get; }

        public EmailServerSettings(string smtpServer, int port)
        {
            if (string.IsNullOrWhiteSpace(smtpServer))
            {
                throw new ArgumentException("SMTP server cannot be empty.", nameof(smtpServer));
            }

            if (port <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(port), "Port must be greater than 0.");
            }

            SmtpServer = smtpServer;
            Port = port;
        }
    }

    public sealed class EmailSender : IMessageSender
    {
        private readonly EmailServerSettings _settings;

        public EmailSender(EmailServerSettings settings)
        {
            _settings = settings ?? throw new ArgumentNullException(nameof(settings));
        }

        public void Send(string recipient, string subject, string message)
        {
            ValidateRecipient(recipient);
            ValidateSubject(subject);
            ValidateMessage(message);

            Connect();

            try
            {
                Console.WriteLine($"Sending email to {recipient} with subject \"{subject}\"");
                Console.WriteLine($"Message: {message}");
            }
            finally
            {
                Disconnect();
            }
        }

        private void Connect()
        {
            Console.WriteLine($"Connecting to SMTP server {_settings.SmtpServer}:{_settings.Port}");
        }

        private void Disconnect()
        {
            Console.WriteLine($"Disconnecting from SMTP server {_settings.SmtpServer}");
        }

        private static void ValidateRecipient(string recipient)
        {
            if (string.IsNullOrWhiteSpace(recipient))
            {
                throw new ArgumentException("Recipient cannot be empty.", nameof(recipient));
            }
        }

        private static void ValidateSubject(string subject)
        {
            if (string.IsNullOrWhiteSpace(subject))
            {
                throw new ArgumentException("Subject cannot be empty.", nameof(subject));
            }
        }

        private static void ValidateMessage(string message)
        {
            if (message is null)
            {
                throw new ArgumentNullException(nameof(message));
            }
        }
    }

    public sealed class ConsoleLogger : ILogger
    {
        public void Log(string message)
        {
            if (message is null)
            {
                throw new ArgumentNullException(nameof(message));
            }

            Console.WriteLine($"Log: {message}");
        }
    }

    public sealed class Notifier
    {
        private readonly IMessageSender _messageSender;
        private readonly ILogger _logger;

        public string Name { get; private set; }

        public Notifier(string name, IMessageSender messageSender, ILogger logger)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("Notifier name cannot be empty.", nameof(name));
            }

            _messageSender = messageSender ?? throw new ArgumentNullException(nameof(messageSender));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            Name = name;
        }

        public void Notify(string recipient, string subject, string message)
        {
            _messageSender.Send(recipient, subject, message);
            _logger.Log($"Notification sent by {Name} to {recipient}");
        }

        public void Rename(string newName)
        {
            if (string.IsNullOrWhiteSpace(newName))
            {
                throw new ArgumentException("Notifier name cannot be empty.", nameof(newName));
            }

            Name = newName;
        }

        public void ShowInfo()
        {
            Console.WriteLine($"Notifier: {Name}");
        }
    }
}
