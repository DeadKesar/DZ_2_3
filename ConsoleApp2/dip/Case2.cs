using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2.dip
{
    internal class Case2
    {
        public interface ILogger // создаём интерфейс, который задействуется в UserActivity
        {
            void WriteLog(string log);
            void ClearLog();
            void ArchiveLog();
            void GetLogStatus();
        }
        public class Logger : ILogger // на основе интерфейса прописываем Logger (в нашем случае интерфейс на основе Logger, ведь логгер уже дан)
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
            private ILogger _logger;
            public string UserName { get; set; }
            public int ActivityCount { get; set; }

            public UserActivity(string userName, ILogger logger)
            {
                UserName = userName;
                ActivityCount = 0;
                _logger = logger; // передаём в конструктор объект с использованием интерфейса ILogger, в нашем случае Logger
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
void main(void) // написал main чтобы показать, что объект, в классе которого используется интерфейс, должен быть задан (создан) за пределами описания класса
{
    string userName = "Привет, меня зовут Влад и я зубная фея";
    ILogger logger = new Logger("user_activity.log"); // создаём объект с использованием интерфейса вне метода, в котором он будет использоваться
    var user = new UserActivity(userName,logger); // тип var - тип переменной задаётся компилятором (как auto в C++), необходимо явно указывать тип при определении переменной (в нашем случае через new)
}
