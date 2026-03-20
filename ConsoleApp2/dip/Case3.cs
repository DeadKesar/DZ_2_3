using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// жесткая зависимость ReportGenerator от MySQLDatabase. 
// Добавил интерфейс IDatabase + исправил инициализацию reportData

namespace ConsoleApp2.dip
{
    internal class Case3
    {
        public interface IDatabase {
            void Connect();
            void Disconnect();
            List<string> GetRecords();
            void WriteLogEntry(string entry);
        }

        public class MySQLDatabase : IDatabase
        {
            private string connectionString;
            public MySQLDatabase(string connectionString)
            {
                this.connectionString = connectionString; 
            }

            public void Connect()
            {
                Thread.Sleep(3000);
                Console.WriteLine($"Connection done {connectionString}");
            }

            public void Disconnect()
            {
                Thread.Sleep(3000);
                Console.WriteLine($"Disconnection done {connectionString}");
            }

            public List<string> GetRecords()
            {
                return new List<string> { "data1", "data2" };
            }

            public void WriteLogEntry(string entry)
            {
                File.WriteAllText("log.txt", entry);
            }
        }

        public class ReportGenerator
        {
            private IDatabase database;
            private List<string> reportData;

            public ReportGenerator(IDatabase mySQLDatabase)
            {
                reportData = new List<string>();
                database = mySQLDatabase;
            }

            public void GenerateReport()
            {
                database.Connect();
                reportData = database.GetRecords();

                ProcessData();
                var s = FormatReport();
                SaveReport(string.Join(';', s));
            }

            private void ProcessData()
            {
                if (reportData.Count > 100)
                {
                    reportData = reportData.GetRange(0, 100);
                }
            }

            private List<string> FormatReport()
            {
                var res = new List<string>();
                foreach (var item in reportData)
                {
                    res.Add($"Item: {item.ToUpper()}");
                    Console.WriteLine($"Item: {item.ToUpper()}");
                }
                return res;
            }

            public void SaveReport(string formattedText)
            {
                database.WriteLogEntry(formattedText);
            }
        }
    }
}
