using System;
using System.Linq;
using System.Collections.Generic;

namespace CountSymbol
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            Dictionary<char, int> characters = new Dictionary<char, int>();

            for (int i = 0; i < text.Length; i++)
            {
                if (!characters.ContainsKey(text[i]))
                {
                    characters[text[i]] = 1;
                }
                else
                {
                    characters[text[i]]++;
                }
            }

            foreach (var pair in characters.OrderBy(c => c.Key))
            {
                Console.WriteLine($"{pair.Key}: {pair.Value} time/s");
            }
        }
    }
}
