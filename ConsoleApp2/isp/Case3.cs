using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2.isp
{
    internal class Case3
    {
        public interface IReadableFile // добавлен интерфейс, содержащий функции для чтения файла
        {
            void OpenFile();
            string ReadFile();
        }
        public interface IFileRoleOperations : IReadableFile // наследование интерфейса чтения, чтобы не прописывать чтение файла
        {
            void WriteFile(string content);
            void ShareFile(string recipient);
            void ArchiveFile();
        }
        public class StandardFile : IFileRoleOperations
        {
            public string FileName { get; set; }
            public string FilePath { get; set; }

            public StandardFile(string fileName, string filePath)
            {
                FileName = fileName;
                FilePath = filePath;
            }

            public void OpenFile()
            {
                Console.WriteLine("Opening file " + FileName + " at " + FilePath);
            }

            public string ReadFile()
            {
                return "Contents of " + FileName;
            }

            public void WriteFile(string content)
            {
                Console.WriteLine("Writing to file " + FileName + ": " + content);
            }

            public void ShareFile(string recipient)
            {
                Console.WriteLine("Sharing file " + FileName + " with " + recipient);
            }

            public void ArchiveFile()
            {
                Console.WriteLine("Archiving file " + FileName);
            }

            public void GetFileDetails() // специфичные для класса функции не прописаны в интерфейсе, чтобы не нарушать принцип разделения
            {
                Console.WriteLine("File details: " + FileName + ", located at " + FilePath);
            }
        }

        public class ReadOnlyFile : IReadableFile
        {
            public string FileName { get; set; }
            public string FilePath { get; set; }

            public ReadOnlyFile(string fileName, string filePath)
            {
                FileName = fileName;
                FilePath = filePath;
            }

            public void OpenFile()
            {
                Console.WriteLine("Opening read-only file " + FileName + " at " + FilePath);
            }

            public string ReadFile()
            {
                return "Read-only content from " + FileName;
            }
            
            public void GetFileInfo() // такая же специфичная функция
            {
                Console.WriteLine("File Info: " + FileName + " at " + FilePath);
            }
        }     // заглушки теперь не нужны

    }
}
