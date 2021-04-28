using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleDictionaries
{
    class CountSameValue
    {
        static void Main(string[] args)
        {
            double[] inputNumbers = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(double.Parse)
                .ToArray();
            Dictionary<double, int> dictOccurrences = new Dictionary<double, int>();

            foreach (var num in inputNumbers)
            {
                if (dictOccurrences.ContainsKey(num))
                {
                    dictOccurrences[num]++;
                }
                else
                {
                    dictOccurrences[num] = 1;
                }
            }

            foreach (var num in dictOccurrences)
            {
                Console.WriteLine($"{num.Key} - {num.Value} times");
            }
        }
    }
}
