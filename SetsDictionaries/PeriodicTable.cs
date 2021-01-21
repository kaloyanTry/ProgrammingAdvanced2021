using System;
using System.Linq;
using System.Collections.Generic;

namespace PeriodicTable
{
    class PeriodicTable
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            HashSet<string> tableElements = new HashSet<string>();

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split().ToArray();

                for (int j = 0; j < input.Length; j++)
                {
                    tableElements.Add(input[j]);
                }
            }

            tableElements = tableElements.OrderBy(e => e).ToHashSet();

            Console.WriteLine(string.Join(" ", tableElements));
        }
    }
}
