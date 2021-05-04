using System;
using System.IO;

namespace _02.LineNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            using (StreamReader reader = new StreamReader("../../../Input.txt") )
            {
                using (StreamWriter writer = new StreamWriter("../../../Output.txt"))
                {
                    string readerLine = reader.ReadLine();
                    int currentRow = 1;

                    while (readerLine != null)
                    {
                        writer.WriteLine($"{currentRow}. {readerLine}");

                        currentRow++;
                        readerLine = reader.ReadLine();
                    }
                }
            }
        }
    }
}
