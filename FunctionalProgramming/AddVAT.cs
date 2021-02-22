using System;
using System.Linq;

namespace AddVAT
{
    class AddVAT
    {
        static void Main(string[] args)
        {
            decimal[] numbers = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(decimal.Parse).Select(n => n * 1.2m).ToArray();

            foreach (var num in numbers)
            {
                Console.WriteLine($"{num:F2}");
            }
        }
    }
}
