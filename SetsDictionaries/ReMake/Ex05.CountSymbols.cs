using System;
using System.Collections.Generic;
using System.Linq;

namespace Ex05.CountSymbols
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            Dictionary<char, int> charsDict = new Dictionary<char, int>();

            foreach (var currentChar in input)
            {
                if (!charsDict.ContainsKey(currentChar))
                {
                    charsDict[currentChar] = 1;
                }
                else
                {
                    charsDict[currentChar]++;
                }
            }

            foreach (var ch in charsDict.OrderBy(c => c.Key))
            {
                Console.WriteLine($"{ch.Key}: {ch.Value} time/s");
            }
        }
    }
}
