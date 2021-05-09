using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace _03.WordCount
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> wordsDict = new Dictionary<string, int>();
 
            using (StreamReader reader = new StreamReader("../../../words.txt"))
            {
                string inputWords = reader.ReadLine();

                while (inputWords != null)
                {
                    string[] wordsLine = inputWords.Split().Select(w => w.ToLower()).ToArray();

                    foreach (var word in wordsLine)
                    {
                        if (!wordsDict.ContainsKey(word))
                        {
                            wordsDict[word] = 0;
                        }
                    }

                    inputWords = reader.ReadLine();
                }
            }

            using (StreamReader reader = new StreamReader("../../../text.txt"))
            {
                string inputText = reader.ReadLine();

                while (inputText != null)
                {
                    string[] textWords = inputText.Split()
                        .Select(w => w.ToLower())
                        .Select(w => w.TrimStart(new[] { '-', ',', '.', '!', '?' }))
                        .Select(w => w.TrimEnd(new[] { '-', ',', '.', '!', '?' }))
                        .ToArray();

                    foreach (var word in textWords)
                    {
                        if (wordsDict.ContainsKey(word))
                        {
                            wordsDict[word]++;
                        }
                    }

                    inputText = reader.ReadLine();
                }
            }

            using (StreamWriter writer = new StreamWriter("../../../output.txt"))
            {
                foreach (var pair in wordsDict.OrderByDescending(w => w.Value))
                {
                    writer.WriteLine($"{pair.Key} - {pair.Value}");
                }
            }
        }

    }
}
