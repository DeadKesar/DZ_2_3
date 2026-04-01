using System;

namespace ConsoleApp2.dip
{
    internal class Case2
    {
        public interface ILogger 
        {
            public void WriteLog(string log);
        }

        public interface ILogMaintence 
        {
            public void ClearLog();
            public void ArchiveLog();
            public void ShowLogStatus();
        }

        public interface IActivity
        {
            public void RecordActivity(string activity);
            public void ResetActivityCount();
            public void DisplayActivity();
        }
        
        public class FileLogger : ILogger, ILogMaintence
        {
            public string FilePath { get; }

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

            public void ShowLogStatus()
            {
                Console.WriteLine("Checking log status for file " + FilePath);
            }
        }

        public class LogService
        {
            private readonly ILogMaintence _logMaintence;

            public LogService(ILogMaintence logMaintence)
            {
                _logMaintence = logMaintence;
            }

            public void ClearLog()
            {
                _logMaintence.ClearLog();
            }
            
            public void ArchiveLog()
            {
                _logMaintence.ArchiveLog();
            }
            
            public void ShowLogStatus()
            {
                _logMaintence.ShowLogStatus();
            }
        }

        public class UserActivity : IActivity
        {
            private readonly ILogger _logger;
            
            public string UserName { get; }
            public int ActivityCount { get; private set; }

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

            public void DisplayActivity()
            {
                Console.WriteLine("User " + UserName + " has " + ActivityCount + " activities recorded.");
            }
        }

        public class ActivityManager 
        {
            private readonly IActivity _activity;
            private readonly LogService _logService;

            public ActivityManager(IActivity activity, LogService logService)
            {
                _activity = activity;
                _logService = logService;
            }

            public void RecordActivity(string activity)
            {
                _activity.RecordActivity(activity);
            }

            public void ResetActivityCount()
            {
                _activity.ResetActivityCount();
            }

            public void DisplayActivity()
            {
                _activity.DisplayActivity();
            }
            
            public void ArchiveActivity()
            {
                _logService.ArchiveLog();
            }

            public void ClearLog()
            {
                _logService.ClearLog();
            }
        }

    }
}
