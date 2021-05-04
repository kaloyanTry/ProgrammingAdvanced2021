using System;
using System.IO;

namespace _01.OddLines
{
    class Program
    {
        static void Main(string[] args)
        {
            using (StreamReader reader = new StreamReader("../../../input.txt"))
            {
                string readCurrentRow = reader.ReadLine();
                int currentRow = 0;

                using (StreamWriter writer = new StreamWriter("../../../output.txt"))
                {
                    while (readCurrentRow != null)
                    {
                        if (currentRow % 2 == 1)
                        {
                            writer.WriteLine(readCurrentRow);
                        }

                        readCurrentRow = reader.ReadLine();
                        currentRow++;
                    }
                }
            }
        }
    }
}
