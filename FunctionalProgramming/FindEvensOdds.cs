using System;
using System.Linq;

namespace FindEvensOdds
{
    class FindEvensOdds
    {
        static void Main(string[] args)
        {
            int[] bounds = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            string condition = Console.ReadLine();

            Func<int, bool> filter = CreateEvenOddFilter(condition);

            for (int i = bounds[0]; i <= bounds[1]; i++)
            {
                if (filter(i))
                {
                    Console.Write(i + " ");
                }
            }
        }

        private static Func<int, bool> CreateEvenOddFilter(string condition)
        {
            if (condition == "even")
            {
                return x => x % 2 == 0;
            }

            return x => x % 2 != 0;
        }
    }
}
