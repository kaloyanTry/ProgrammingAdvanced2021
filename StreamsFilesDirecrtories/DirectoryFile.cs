using System;
using System.IO;

namespace ConsoleStreams
{
    class DirectoryFile
    {
        static void Main(string[] args)
        {
            Directory.CreateDirectory("../../../DirNew");

            File.Create("../../../DirNew/textNew.txt");
            File.Create("../../../DirNew/presiNew.ppt");

            string[] filesDir = Directory.GetFiles("../../../DirNew");

            foreach (var file in filesDir)
            {
                Console.WriteLine(file);

                //Do the same thing:
                //FileInfo fileInfo = new FileInfo(file);
                //Console.WriteLine(fileInfo);
            }

            //Delete directory:
            //Directory.Delete("../../../DirNew/Test2Dir", true);
        }
    }
}
