using System;
using System.Collections.Generic;
using System.Linq;

namespace AppliedArithmetics
{
    class AppliedArithmetics
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToList();

            string command = Console.ReadLine();

            while (command != "end")
            {
                Func<int, int> applyOperation = CreateOperation(command);

                if (command != "print")
                {
                    numbers = numbers.Select(applyOperation).ToList();
                }
                else
                {
                    Console.WriteLine(string.Join(" ", numbers));
                }

                command = Console.ReadLine();
            }
        }

        private static Func<int, int> CreateOperation(string command)
        {
            if (command == "add")
            {
                return x => x + 1;
            }
            if (command == "subtract")
            {
                return x => x - 1;
            }

            return x => x * 2;
        }
    }
}
