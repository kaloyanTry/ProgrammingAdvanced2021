using System;
using System.IO;

namespace OddLines
{
    class OddLines
    {
        static void Main(string[] args)
        {
            using (StreamReader reader = new StreamReader("../../../input.txt"))
            {
                string currentRow = reader.ReadLine();
                int row = 0;

                using (StreamWriter writer = new StreamWriter("../../../output.txt"))
                {
                    while (currentRow != null)
                    {
                        if (row % 2 == 1)
                        {
                            writer.WriteLine(currentRow);
                        }

                        currentRow = reader.ReadLine();
                        row++;
                    }
                }
            }
        }
    }
}
