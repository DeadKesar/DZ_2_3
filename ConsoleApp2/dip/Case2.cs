using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2.dip
{
    internal class Case2
    {
        public interface ILogger 
        {
            public void WriteLog(string log);
            public void ClearLog();
            public void ArchiveLog();
            public void GetLogStatus();
        }
        
        public class Logger : ILogger
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
            private readonly ILogger _logger;
            public string UserName { get; set; }
            public int ActivityCount { get; set; }

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
