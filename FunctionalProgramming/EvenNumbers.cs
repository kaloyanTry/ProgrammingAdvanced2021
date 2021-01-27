using System;
using System.Linq;
using System.Collections.Generic;

namespace EvenNumbers
{
    class EvenNumbers
    {
        static void Main(string[] args)
        {
            int[] array = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(n => int.Parse(n)).Where(n => n % 2 == 0).OrderBy(n => n).ToArray();

            string evenArray = (string.Join(", ", array));

            Console.WriteLine(evenArray);
        }
    }
}
