using System;
using System.Linq;

namespace _02.SumNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            Func<string, int> parser = n => int.Parse(n);

            int[] inputNumbers = input
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(parser).ToArray();

            Console.WriteLine(inputNumbers.Length);
            Console.WriteLine(inputNumbers.Sum());
        }
    }
}
