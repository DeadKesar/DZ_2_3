using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2.isp
{
    internal class Case3
    {
        public interface IFileOpener
        {
            void OpenFile();
        }

        public interface IFileReader
        {
            string ReadFile();
        }

        public interface IFileWriter
        {
            void WriteFile(string content);
        }

        public interface IFileSharer
        {
            void ShareFile(string recipient);
        }

        public interface IFileArchiver
        {
            void ArchiveFile();
        }

        public class StandardFile : IFileOpener, IFileReader, IFileWriter, IFileSharer, IFileArchiver
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

            public void GetFileDetails()
            {
                Console.WriteLine("File details: " + FileName + ", located at " + FilePath);
            }
        }

        public class ReadOnlyFile : IFileOpener, IFileReader
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

            public void GetFileInfo()
            {
                Console.WriteLine("File info: " + FileName + " at " + FilePath);
            }
        }
    }
}
