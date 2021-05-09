using System;
using System.IO;

namespace _05.FolderSize
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] files = Directory.GetFiles("../../../TestFolder");

            double totalSizeMB = 0;

            foreach (var file in files)
            {
                FileInfo fileInfo = new FileInfo(file);
                double fileSizeMB = (double) fileInfo.Length / 1024 / 1024;
                totalSizeMB += fileSizeMB;
            }

            File.WriteAllText("../../../Output.txt", totalSizeMB.ToString());
        }
    }
}
