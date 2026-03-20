using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// у кода было нарушено два принципа SOLID
// Первый принцип S - принцип единственности ответственности. У класса ReportGenerator было слишком много задач, поэтому я разделил его на
// три класса: ReportGenerator - куда закинул работу с базой данных, Filesave_ToUpper - как мы будем сохранять отчёт и GenerateReport - создание
// отчёта соединяя предыдущие классы

// Второй нарушенный принцип это D - принцип иерархии влияния. В классе ReportGenerator проиходил запрос к MySQLDatabase
// в котором использовался только 1 указатель.
// По принципу D необходимо содавать connectionString в классе.

namespace ConsoleApp2.dip
{
    internal class Case3
    {
        public class MySQLDatabase // немного поменял конструктор 
        {
            private string connectionString;
            public MySQLDatabase(string connectionString = "mysql://dsadlkasjdklasjdaklsjd") // добавил предустановленное значение
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
                // NOIMPL
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
        public class ReportGenerator // оставил только работу с базой данных
        {
            private MySQLDatabase database;
            private List<string> reportData = [];

            public ReportGenerator()
            {
                database = new MySQLDatabase();
            }

            private void ProcessData()
            {
                if (reportData.Count > 100)
                {
                    reportData = reportData.GetRange(0, 100);
                }
            }
        }
        public class Filesave_ToUpper{ // генерация метода сохранения 
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
        public class GenerateReport // само создание отчёта, сбор предыдущих установок
        {
            private MySQLDatabase base_;
            private ReportGenerator report_;
            private Filesave file_;

            public GenerateReport(MySQLDatabase _base_, ReportGenerator _report_, Filesave _file_)
            {
                this.base_ = _base_;
                this.report_ = _report_;
                this.file_ = _file_;
            }
            public CreateReport()
            {
                database.Connect();
                reportData = database.GetRecords();

                ProcessData();
                var s = FormatReport();
                SaveReport(string.Join(';', s));
            }
        }
    }
}