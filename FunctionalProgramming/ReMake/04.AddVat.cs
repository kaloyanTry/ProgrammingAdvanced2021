using System;
using System.Linq;

namespace _04.AddVat
{
    class Program
    {
        static void Main(string[] args)
        {
            decimal[] inputPrices = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(decimal.Parse).ToArray();

            decimal[] vatPrices = inputPrices.Select(p => p * 1.2m).ToArray();

            foreach (var price in vatPrices)
            {
                Console.WriteLine($"{price:F2}");
            }
        }
    }
}
