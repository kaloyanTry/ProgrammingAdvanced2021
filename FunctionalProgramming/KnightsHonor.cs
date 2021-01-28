using System;
using System.Linq;
using System.Collections.Generic;

namespace KnightsHonor
{
    class KnightsHonor
    {
        static void Main(string[] args)
        {
            List<string> names = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList();

            Action<List<string>> printer = x => Console.WriteLine(string.Join(Environment.NewLine, x.Select(y => $"Sir {y}")));

            printer(names);
        }
    }
}
