using System;
using System.IO;

namespace ConsoleStream
{
    class StreamReaderWriter
    {
        static void Main(string[] args)
        {
            //Streamreader:
            StreamReader reader = new StreamReader("../../../input.txt");

            string line = reader.ReadToEnd();
            //string alLines = reader.ReadToEnd();

            Console.WriteLine(line);

            reader.Close();

            //Streamwriter:
            StreamWriter writer = new StreamWriter("../../../input.txt", true);

            writer.WriteLine("We are the champs!");

            writer.Close();

            //USING: the same functionality but automaticly close the reader
            //Always use USING! This is a good practice

            //using (StreamReader readerStream = new StreamReader("../../../input.txt"))
            //{
            //    string streamLine = reader.ReadToEnd();
            //    Console.WriteLine(line);
            //}
        }
    }
}
