using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace WordCountExercise
{
    class WordCount
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> wordOccurrences = new Dictionary<string, int>();

            using (StreamReader reader = new StreamReader("../../../words.txt"))
            {
                string line = reader.ReadLine();

                while (line != null)
                {
                    string word = line.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray()[0].ToLower();
                    if (!wordOccurrences.ContainsKey(word))
                    {
                        wordOccurrences[word] = 0;
                    }

                    line = reader.ReadLine();
                }
            }


            using (var writer = new StreamWriter("../../../actualResults.txt"))
            {
                using (var reader = new StreamReader("../../../text.txt"))
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
                            if (wordOccurrences.ContainsKey(word))
                            {
                                wordOccurrences[word]++;
                            }
                        }

                        line = reader.ReadLine();
                    }

                    foreach (var kvp in wordOccurrences.OrderByDescending(x => x.Value))
                    {
                        writer.WriteLine($"{kvp.Key} - {kvp.Value}");
                    }
                }
            }


            if (AreEqual("../../../actualResults.txt", "../../../expectedResult.txt"))
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