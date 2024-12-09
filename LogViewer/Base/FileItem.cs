using System.IO;

namespace LogViewer.Base
{
    public class FileItem
    {
        public long Length { get; set; }

        public FileSystemInfo Info { get; set; }

        public long TotalLength { get; set; }

        public long LeftLength { get; set; }

        public int TotalFileCount { get; set; }

        public int LeftFileCount { get; set; }

        public bool Completed { get; set; }
    }
}