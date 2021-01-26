using System;
using System.IO;
using System.Linq;

namespace EvenLinesExercise
{
    class EvenLines
    {
        static void Main(string[] args)
        {
            string inputPath = "../../../text.txt";
            string outputPath = "../../../output.txt";

            using (StreamReader reader = new StreamReader(inputPath))
            {
                using (StreamWriter writer = new StreamWriter(outputPath))
                {
                    string line = reader.ReadLine();

                    int row = 0;

                    while (line != null)
                    {
                        if (row++ % 2 == 0)
                        {
                            string[] words = line.Split().Reverse()
                            .Select(x => x.Replace("-", "@"))
                            .Select(x => x.Replace(",", "@"))
                            .Select(x => x.Replace(".", "@"))
                            .Select(x => x.Replace("!", "@"))
                            .Select(x => x.Replace("?", "@"))
                            .ToArray();

                            writer.WriteLine(string.Join(" ", words));
                        }

                        line = reader.ReadLine();
                    }
                }

            }
        }
    }
}
