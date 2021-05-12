using System;
using System.Collections.Generic;
using System.Linq;

namespace Ex02.KnightsOfHonor
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> inputNames = Console.ReadLine().Split().ToList();

            Action<List<string>> printKnights = x => Console.WriteLine(string.Join(Environment.NewLine, x.Select(y => $"Sir {y}")));

            printKnights(inputNames);
        }
    }
}
