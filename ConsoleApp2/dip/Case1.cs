using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2.dip
{
    // Интерфейсы для абстракций
    public interface IMessageSender
    {
        void SendMessage(string recipient, string subject, string message);
    }

    public interface ILogger
    {
        void Log(string message);
    }

    // Реализация email отправки
    public class EmailSender : IMessageSender
    {
        private readonly ILogger _logger;
        private readonly SmtpConfig _config;

        public EmailSender(SmtpConfig config, ILogger logger)
        {
            _config = config;
            _logger = logger;
            Connect();
        }

        private void Connect()
        {
            _logger.Log($"Connecting to SMTP server {_config.SmtpServer}:{_config.Port}");
        }

        public void SendMessage(string recipient, string subject, string message)
        {
            _logger.Log($"Sending email to {recipient} with subject {subject}");
            // Реальная отправка
        }

        private void Disconnect()
        {
            _logger.Log($"Disconnecting from SMTP server {_config.SmtpServer}");
        }

        public void Dispose()
        {
            Disconnect();
        }
    }

    // Отдельный логгер
    public class ConsoleLogger : ILogger
    {
        public void Log(string message)
        {
            Console.WriteLine($"Log: {message}");
        }
    }

    // Конфигурация SMTP
    public class SmtpConfig
    {
        public string SmtpServer { get; set; }
        public int Port { get; set; }
    }

    // Notifier зависит от абстракций, а не от конкретных классов
    public class Notifier
    {
        private readonly IMessageSender _messageSender;
        private readonly ILogger _logger;
        public string NotifierName { get; set; }

        public Notifier(string name, IMessageSender messageSender, ILogger logger)
        {
            NotifierName = name;
            _messageSender = messageSender;
            _logger = logger;
        }

        public void Notify(string recipient, string subject, string message)
        {
            _messageSender.SendMessage(recipient, subject, message);
            _logger.Log($"Notification sent by {NotifierName}");
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
