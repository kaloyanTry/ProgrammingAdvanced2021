using System;
using System.Collections.Generic;
using System.Linq;

namespace Ex03.PeriodicTable
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            HashSet<string> elementsSet = new HashSet<string>();
            

            for (int i = 0; i < n; i++)
            {
                string[] elements = Console.ReadLine().Split();

                foreach (var element in elements)
                {
                    elementsSet.Add(element);
                }
            }

            elementsSet = elementsSet.OrderBy(n => n).ToHashSet();

            Console.WriteLine(string.Join(" ", elementsSet));

        }
    }
}
