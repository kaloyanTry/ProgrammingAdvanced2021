using System;
using System.Collections.Generic;

namespace _05.HashSetUniqueNames
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            HashSet<string> namesSet = new HashSet<string>();

            for (int i = 0; i < n; i++)
            {
                string name = Console.ReadLine();
                namesSet.Add(name);
            }

            foreach (var name in namesSet)
            {
                Console.WriteLine(name);
            }
        }
    }
}
