using System;
using System.Collections.Generic;
using System.Linq;

namespace ListPredicates
{
    class ListPredicate
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int[] dividers = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).Distinct().ToArray();

            Func<int, int, bool> predicate = (num, d) => num % d == 0;


            for (int i = 1; i <= n; i++)
            {
                if (dividers.All(d => predicate(i, d)))
                {
                    Console.Write(i + " ");
                }
            }
        }
    }
}
