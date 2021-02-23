using System;
using System.Collections.Generic;
using System.Linq;

namespace SumArray
{
    class SumArray
    {
        static void Main(string[] args)
        {
            Console.Write("Please, input the numbers with a space between: ");
            int[] inputNumbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int index = 0;
            int result = SumArrayNumbers(inputNumbers, index);
            Console.WriteLine($"The sum of the numbers = {result}");
        }

        private static int SumArrayNumbers(int[] inputNumbers, int index)
        {
            if (index < inputNumbers.Length)
            {
                return inputNumbers[index] + SumArrayNumbers(inputNumbers, index + 1);
            }

            return 0;
        }
    }
}
