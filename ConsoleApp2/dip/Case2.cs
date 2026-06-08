using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2.dip
{
    internal class Case2
    {
        public class Logger
        {
            public string FilePath { get; set; }

            public Logger(string filePath)
            {
                FilePath = filePath;
            }

            public void WriteLog(string log)
            {
                Console.WriteLine("Writing log to file " + FilePath + ": " + log);
            }

            public void ClearLog()
            {
                Console.WriteLine("Clearing log file " + FilePath);
            }

            public void ArchiveLog()
            {
                Console.WriteLine("Archiving log file " + FilePath);
            }

            public void GetLogStatus()
            {
                Console.WriteLine("Checking log status for file " + FilePath);
            }
        }

        public class UserActivity
        {
            private Logger _logger;
            public string UserName { get; set; }
            public int ActivityCount { get; set; }

            public UserActivity(string userName)
            {
                UserName = userName;
                ActivityCount = 0;
                _logger = new Logger("user_activity.log");
            }

            public void RecordActivity(string activity)
            {
                ActivityCount++;
                _logger.WriteLog("User " + UserName + " did " + activity + ". Count: " + ActivityCount);
            }

            public void ResetActivityCount()
            {
                ActivityCount = 0;
                _logger.WriteLog("Reset activity count for " + UserName);
            }

            public void ArchiveActivity()
            {
                _logger.ArchiveLog();
            }

            public void DisplayActivity()
            {
                Console.WriteLine("User " + UserName + " has " + ActivityCount + " activities recorded.");
            }
        }

    }

    // Нарушение принципа DIP было в том, что класс высокого уровня UserActivity напрямую зависел от класса низкого уровня Logger. Из-за этого нельзя изменить способ логирования не переписывая сам класс UserActivity.
    // Решение: создать интерфейс ILogger (абстракцию) и внедрять его в UserActivity. Тогда класс UserActivity будет зависеть только от абстракции ILogger, но не от конкретных деталей реализации.
    class Case2better
    {
        // Создаем интерфейс для логгера
        public interface ILogger
        {
            void WriteLog(string log);
            void ClearLog();
            void ArchiveLog();
            void GetLogStatus();
        }

        // Реализуем конкретный логгер в файл (деталь реализации)
        public class FileLogger : ILogger
        {
            public string FilePath { get; set; }

            public FileLogger(string filePath)
            {
                FilePath = filePath;
            }

            public void WriteLog(string log)
            {
                Console.WriteLine("Writing log to file " + FilePath + ": " + log);
            }

            public void ClearLog()
            {
                Console.WriteLine("Clearing log file " + FilePath);
            }

            public void ArchiveLog()
            {
                Console.WriteLine("Archiving log file " + FilePath);
            }

            public void GetLogStatus()
            {
                Console.WriteLine("Checking log status for file " + FilePath);
            }
        }

        // Класс UserActivity теперь зависит ТОЛЬКО от абстракции ILogger - зависимость от интерфейса, а не от класса
        public class UserActivity
        {
            private readonly ILogger _logger; 
            public string UserName { get; set; }
            public int ActivityCount { get; set; }

            // Логгер теперь передается через конструктор
            public UserActivity(string userName, ILogger logger)
            {
                UserName = userName;
                ActivityCount = 0;
                _logger = logger;
            }

            public void RecordActivity(string activity)
            {
                ActivityCount++;
                _logger.WriteLog("User " + UserName + " did " + activity + ". Count: " + ActivityCount);
            }

            public void ResetActivityCount()
            {
                ActivityCount = 0;
                _logger.WriteLog("Reset activity count for " + UserName);
            }

            public void ArchiveActivity()
            {
                _logger.ArchiveLog();
            }

            public void DisplayActivity()
            {
                Console.WriteLine("User " + UserName + " has " + ActivityCount + " activities recorded.");
            }
        }
    }
}
