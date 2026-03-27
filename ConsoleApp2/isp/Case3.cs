using System;

namespace ConsoleApp2.isp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Тестирование StandardFile");
            var standardFile = new Case3.StandardFile("отчет.txt", "C:/docs");
            standardFile.OpenFile();
            standardFile.WriteFile("Новые данные");
            standardFile.ShareFile("admin@example.com");

            Console.WriteLine("\nТестирование ReadOnlyFile");
            var readOnlyFile = new Case3.ReadOnlyFile("конфиг.sys", "C:/system");
            readOnlyFile.OpenFile();
            Console.WriteLine(readOnlyFile.ReadFile());
            Console.WriteLine("\nНажмите любую клавишу для выхода");
            Console.ReadKey();
        }
    }

    internal class Case3
    {
        public interface IReadable { void OpenFile(); string ReadFile(); }
        public interface IWritable { void WriteFile(string content); }
        public interface IShareable { void ShareFile(string recipient); }
        public interface IArchivable { void ArchiveFile(); }

        public class StandardFile : IReadable, IWritable, IShareable, IArchivable
        {
            public string FileName { get; set; }
            public string FilePath { get; set; }

            public StandardFile(string fileName, string filePath)
            {
                FileName = fileName;
                FilePath = filePath;
            }

            public void OpenFile() => Console.WriteLine($"Открытие: {FileName}");
            public string ReadFile() => $"Чтение данных из {FileName}";
            public void WriteFile(string content) => Console.WriteLine($"Запись в {FileName}: {content}");
            public void ShareFile(string recipient) => Console.WriteLine($"Файл {FileName} отправлен {recipient}");
            public void ArchiveFile() => Console.WriteLine($"Файл {FileName} архивирован");
        }

        public class ReadOnlyFile : IReadable
        {
            public string FileName { get; set; }
            public string FilePath { get; set; }

            public ReadOnlyFile(string fileName, string filePath)
            {
                FileName = fileName;
                FilePath = filePath;
            }

            public void OpenFile() => Console.WriteLine($"Открытие (только чтение): {FileName}");
            public string ReadFile() => $"Данные из защищенного файла {FileName}";
        }
    }
}
