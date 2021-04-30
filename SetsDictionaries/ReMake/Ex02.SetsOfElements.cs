using System;
using System.Collections.Generic;
using System.Linq;

namespace Ex02.SetsOfElements
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] inputs = Console.ReadLine().Split().Select(int.Parse).ToArray();

            HashSet<int> firstSet = new HashSet<int>();
            HashSet<int> secondSet = new HashSet<int>();

            for (int i = 0; i < inputs[0]; i++)
            {
                int num = int.Parse(Console.ReadLine());
                firstSet.Add(num);
            }

            for (int j = 0; j < inputs[1]; j++)
            {
                int num = int.Parse(Console.ReadLine());
                secondSet.Add(num);
            }

            firstSet.IntersectWith(secondSet);
            Console.WriteLine(string.Join(" ", firstSet));
        }
    }
}
