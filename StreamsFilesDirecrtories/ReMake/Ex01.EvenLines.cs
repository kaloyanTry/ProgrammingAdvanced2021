using System;
using System.IO;
using System.Linq;

namespace Ex01.EvenLines
{
    class Program
    {
        static void Main(string[] args)
        {
            string pathInput = "../../../text.txt";
            string pathOutput = "../../../output.txt";

            using (StreamReader reader = new StreamReader(pathInput))
            {
                using (StreamWriter writer = new StreamWriter(pathOutput))
                {
                    string readerLine = reader.ReadLine();
                    int readerRow = 0;

                    while (readerLine != null)
                    {
                        if (readerRow++ % 2 == 0)
                        {
                            string[] words = readerLine.Split().Reverse()
                                .Select(w => w.Replace('-', '@'))
                                .Select(w => w.Replace(',', '@'))
                                .Select(w => w.Replace('.', '@'))
                                .Select(w => w.Replace('!', '@'))
                                .Select(w => w.Replace('?', '@')).ToArray();

                            writer.WriteLine(string.Join(" ", words));
                        }

                        readerLine = reader.ReadLine();
                    }
                }
            }
        }
    }
}
