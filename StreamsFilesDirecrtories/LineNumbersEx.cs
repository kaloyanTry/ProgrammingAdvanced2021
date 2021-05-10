using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace LineNumbersExercise
{
    class LineNumbers
    {
        static void Main(string[] args)
        {
            string[] lines = File.ReadAllLines("../../../text.txt");
            //List<char> punctuationMarks = new List<char>() { '-', ',', '.', '!', '?', '\'' };

            for (int i = 0; i < lines.Length; i++)
            {
                string line = lines[i];

                int letersCount = 0;
                int punctuationCount = 0;

                foreach (var ch in line)
                {
                    if (char.IsLetter(ch))
                    {
                        letersCOunt++;
                    }
                    else if (char.IsPunctuation(ch))
                    {
                        punctuationCount++;
                    }
                }

                string newLine = $"Line {i + 1}: {line} ({letersCOunt})({punctuationCount})";

                //Console.WriteLine(newLine);
                File.AppendAllText("../../../outputText.txt", newLine + Environment.NewLine);
            }
        }
    }
}
