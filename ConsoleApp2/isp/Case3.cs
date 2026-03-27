namespace ConsoleApp2.isp
{
    internal class Case3
    {
        public interface IFileOpenable
        {
            void OpenFile();
        }

        public interface IFileReadable
        {
            string ReadFile();
        }

        public interface IFileWritable
        {
            void WriteFile(string content);
        }

        public interface IFileShareable
        {
            void ShareFile(string recipient);
        }

        public interface IFileArchivable
        {
            void ArchiveFile();
        }

        public class StandardFile : IFileOpenable, IFileReadable, IFileWritable, IFileShareable, IFileArchivable
        {
            public string FileName { get; set; }
            public string FilePath { get; set; }

            public StandardFile(string fileName, string filePath)
            {
                FileName = fileName;
                FilePath = filePath;
            }

            public void OpenFile()
                => Console.WriteLine("Opening file " + FileName + " at " + FilePath);

            public string ReadFile()
                => "Contents of " + FileName;

            public void WriteFile(string content)
                => Console.WriteLine("Writing to file " + FileName + ": " + content);

            public void ShareFile(string recipient)
                => Console.WriteLine("Sharing file " + FileName + " with " + recipient);

            public void ArchiveFile()
                => Console.WriteLine("Archiving file " + FileName);

            public void GetFileDetails()
                => Console.WriteLine("File details: " + FileName + ", located at " + FilePath);
        }

        public class ReadOnlyFile : IFileOpenable, IFileReadable
        {
            public string FileName { get; set; }
            public string FilePath { get; set; }

            public ReadOnlyFile(string fileName, string filePath)
            {
                FileName = fileName;
                FilePath = filePath;
            }

            public void OpenFile()
                => Console.WriteLine("Opening read-only file " + FileName + " at " + FilePath);

            public string ReadFile()
                => "Read-only content from " + FileName;

            public void GetFileInfo()
                => Console.WriteLine("File Info: " + FileName + " at " + FilePath);
        }
    }
}
