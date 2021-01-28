using System;
using System.Collections.Generic;
using System.Linq;

namespace ActionPoint
{
    class ActionPoint
    {
        static void Main(string[] args)
        {
            List<string> names = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList();

            Action<string> printer = x => Console.WriteLine(x);

            names.ForEach(printer);
        }
    }
}
