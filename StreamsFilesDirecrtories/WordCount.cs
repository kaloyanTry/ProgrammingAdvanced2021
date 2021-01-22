using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace WordCount
{
    class WordCount
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> wordOccurrences = new Dictionary<string, int>();

            using (StreamReader reader = new StreamReader("../../../words.txt"))
            {
                string input = reader.ReadLine();

                while (input != null)
                {
                    string[] words = input.Split().Select(w => w.ToLower()).ToArray();

                    foreach (var word in words)
                    {
                        if (!wordOccurrences.ContainsKey(word))
                        {
                            wordOccurrences[word] = 0;
                        }
                    }

                    input = reader.ReadLine();
                }
            }

            using (StreamReader reader = new StreamReader("../../../text.txt"))
            {
                string input = reader.ReadLine();

                while (input != null)
                {
                    string[] words = input.Split()
                        .Select(x => x.ToLower())
                        .Select(x => x.TrimStart(new[] { '-', ',', '.', '!', '?' }))
                        .Select(x => x.TrimEnd(new[] { '-', ',', '.', '!', '?' }))
                        .ToArray();
                    foreach (var word in words)
                    {
                        if (wordOccurrences.ContainsKey(word))
                        {
                            wordOccurrences[word]++;
                        }
                    }
                    input = reader.ReadLine();
                }
            }


            using (StreamWriter writer = new StreamWriter("../../../output.txt"))
            {
                foreach (var pair in wordOccurrences.OrderByDescending(w => w.Value))
                {
                    writer.WriteLine($"{pair.Key} - {pair.Value}");
                }
            }
        }
    }
}
