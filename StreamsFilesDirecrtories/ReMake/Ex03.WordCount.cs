using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Ex03.WordCount
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> wordsDict = new Dictionary<string, int>();
            string wordsPath = "../../../words.txt";
            string textPath = "../../../text.txt";
            string resultPath = "../../../actualResult.txt";

            using (StreamReader reader = new StreamReader(wordsPath))
            {
                string wordsLine = reader.ReadLine();

                while (wordsLine != null)
                {
                    string word = wordsLine.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray()[0].ToLower();

                    if (!wordsDict.ContainsKey(word))
                    {
                        wordsDict[word] = 0;
                    }

                    wordsLine = reader.ReadLine();
                }
            }

            using (StreamWriter writer = new StreamWriter(resultPath))
            {
                using (StreamReader reader = new StreamReader(textPath))
                {
                    string line = reader.ReadLine();

                    while (line != null)
                    {
                        string[] words = line.Split()
                            .Select(x => x.TrimStart(new[] { '-', ',', '.', '?', '!' }))
                            .Select(x => x.TrimEnd(new[] { '-', ',', '.', '?', '!' }))
                            .Select(x => x.ToLower())
                            .ToArray();

                        foreach (var word in words)
                        {
                            if (wordsDict.ContainsKey(word))
                            {
                                wordsDict[word]++;
                            }
                        }

                        line = reader.ReadLine();
                    }

                    foreach (var kvp in wordsDict.OrderByDescending(x => x.Value))
                    {
                        writer.WriteLine($"{kvp.Key} - {kvp.Value}");
                    }
                }
            }

            if (AreEqual(resultPath, "../../../expectedResult.txt"))
            {
                Console.WriteLine("Right Answer!");
            }
            else
            {
                Console.WriteLine("False!");
            }
        }

        private static bool AreEqual(string file1, string file2)
        {
            using (var reader1 = new StreamReader(file1))
            {
                using (var reader2 = new StreamReader(file2))
                {
                    string line1 = reader1.ReadLine();
                    string line2 = reader2.ReadLine();

                    while (line1 != null && line2 != null)
                    {
                        if (line1 != line2)
                        {
                            return false;
                        }

                        line1 = reader1.ReadLine();
                        line2 = reader2.ReadLine();
                    }
                }
            }

            return true;
        }
    }
}
