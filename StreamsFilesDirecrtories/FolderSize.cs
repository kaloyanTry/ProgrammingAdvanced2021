using System;
using System.IO;
using System.Collections.Generic;

namespace FolderSize
{
    class FolderSize
    {
        static void Main(string[] args)
        {
            string[] files = Directory.GetFiles("../../../TestFolder");
            double totalSizeMB = 0;

            foreach (var file in files)
            {
                FileInfo fileInfo = new FileInfo(file);
                double fileSizeMB = (double)fileInfo.Length / 1024 / 1024;
                totalSizeMB += fileSizeMB;
            }

            File.WriteAllText("../../../output.txt", totalSizeMB.ToString());
        }
    }
}