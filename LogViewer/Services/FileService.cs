using LogViewer.Base;
using System.Collections.Generic;
using System.IO;

namespace LogViewer.Services
{
    public static class FileService
    {
        private static readonly List<FileItem> fileList = new List<FileItem>();
        
        public static List<FileItem> Enlist(string path, string searchPattern)
        {
            fileList.Clear();

            if (Directory.Exists(path))
            {
                DirectoryInfo dirInfo = new DirectoryInfo(path);
                FileSystemInfo[] fsiArr = dirInfo.GetFileSystemInfos();
                EnlistFiles(fsiArr, searchPattern);
            }

            return fileList;
        }

        private static void EnlistFiles(FileSystemInfo[] fsiArr, string searchPattern = null)
        {
            foreach (FileSystemInfo fsi in fsiArr)
            {
                FileAttributes attr = File.GetAttributes(fsi.FullName);

                if (attr.HasFlag(FileAttributes.Directory))
                {
                    DirectoryInfo di = new DirectoryInfo(fsi.FullName);
                    EnlistFiles(di.GetFileSystemInfos(), searchPattern);
                }
                else
                {
                    if (string.IsNullOrWhiteSpace(searchPattern))
                    {
                        Add(fsi);
                    }
                    else
                    {
                        if (fsi.Name.Contains(searchPattern))
                        {
                            Add(fsi);
                        }
                    }
                }
            }
        }

        private static void Add(FileSystemInfo fsi)
        {
            if (fsi.Extension == ".xml")
            {
                long length = new FileInfo(fsi.FullName).Length;

                var fileItem = new FileItem()
                {
                    Length = length,
                    Info = fsi
                };

                fileList.Add(fileItem);
            }
        }
    }
}