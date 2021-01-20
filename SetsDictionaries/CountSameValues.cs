using System;
using System.Linq;
using System.Collections.Generic;

namespace CountSameValuesInArray
{
    class CountSameValues
    {
        static void Main(string[] args)
        {
            double[] input = Console.ReadLine().Split().Select(double.Parse).ToArray();

            Dictionary<double, int> dict = new Dictionary<double, int>();

            foreach (var num in input)
            {
                if (dict.ContainsKey(num))
                {
                    dict[num]++;
                }
                else
                {
                    dict[num] = 1;
                }
            }

            foreach (var num in dict)
            {
                Console.WriteLine($"{num.Key} - {num.Value} times");
            }
        }
    }
}
