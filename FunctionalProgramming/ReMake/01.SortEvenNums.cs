using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleFunctional
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] inputArray = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            int[] orderedArray = inputArray.Where(n => n % 2 == 0).OrderBy(n => n).ToArray();

            Console.WriteLine(string.Join(", ", orderedArray));
        }
    }
}
