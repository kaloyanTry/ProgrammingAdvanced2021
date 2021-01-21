using System;
using System.Linq;
using System.Collections.Generic;

namespace SetsOfElements
{
    class SetElements
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int n = input[0];
            int m = input[1];

            HashSet<int> firstSet = new HashSet<int>();
            HashSet<int> secondSet = new HashSet<int>();

            for (int i = 0; i < n + m; i++)
            {
                if (i < n)
                {
                    int first = int.Parse(Console.ReadLine());
                    firstSet.Add(first);
                }
                else
                {
                    int second = int.Parse(Console.ReadLine());
                    secondSet.Add(second);
                }                              
            }

            firstSet.IntersectWith(secondSet);

            Console.WriteLine(string.Join(" ", firstSet));
        }
    }
}
