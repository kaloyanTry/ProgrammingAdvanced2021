using System;
using System.Collections.Generic;
using System.Linq;

namespace CustomComparator
{
    class CustomComparator
    {
        static void Main(string[] args)
        {
            List<int> nums = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();

            Func<int, bool> evenFilter = CreateFilter("even");

            List<int> evens = Where(nums, evenFilter);
            evens.Sort();

            Func<int, bool> oddFilter = CreateFilter("odd");

            List<int> odds = Where(nums, oddFilter);
            odds.Sort();

            evens.AddRange(odds);
            Console.WriteLine(string.Join(" ", evens));
        }

        private static Func<int, bool> CreateFilter(string type)
        {
            if (type == "even")
            {
                return x => x % 2 == 0;
            }
            return x => x % 2 != 0;
        }

        private static List<int> Where(List<int> nums, Func<int, bool> filter)
        {
            List<int> res = new List<int>();
            for (int i = 0; i < nums.Count; i++)
            {
                if (filter(nums[i]))
                {
                    res.Add(nums[i]);
                }
            }

            return res;
        }
    }
}
