using System;
using System.IO;

namespace LineNumbers
{
    class LineNumbers
    {
        static void Main(string[] args)
        {
            using (StreamReader reader = new StreamReader("../../../input.txt"))
            {
                using (StreamWriter writer = new StreamWriter("../../../output.txt"))
                {
                    string input = reader.ReadLine();
                    int row = 1;
                    while (input != null)
                    {
                        writer.WriteLine($"{row}. {input}");
                        row++;
                        input = reader.ReadLine();
                    }
                }
            }
        }
    }
}
