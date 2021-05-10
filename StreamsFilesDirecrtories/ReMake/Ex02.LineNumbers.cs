using System;
using System.Collections.Generic;
using System.IO;

namespace Ex02.LineNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            string pathText = "../../../text.txt";
            string pathResult = "../../../actualResult.txt";

            string[] readerAllLinesText = File.ReadAllLines(pathText);

            for (int i = 0; i < readerAllLinesText.Length; i++)
            {
                string readerLine = readerAllLinesText[i];

                int lettersCount = 0;
                int marksCount = 0;

                foreach (var ch in readerLine)
                {
                    if (char.IsLetter(ch))
                    {
                        lettersCount++;
                    }
                    else if (char.IsPunctuation(ch))
                    {
                        marksCount++;
                    }
                }

                string writerLine = $"Line {i + 1}: {readerLine} ({lettersCount})({marksCount})";

                File.AppendAllText((pathResult), writerLine + Environment.NewLine);
            }
        }
    }
}
