using System;
using System.Linq;
using System.Collections.Generic;

namespace EvenNumbers
{
    class EvenNumbers
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split(", ").Select(int.Parse).ToList();

            int[] evenNums = numbers.Where(n => n % 2 == 0).OrderBy(n => n).ToArray();

            Console.WriteLine(string.Join(", ", evenNums));
        }
    }
}
