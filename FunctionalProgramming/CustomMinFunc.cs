using System;
using System.Collections.Generic;
using System.Linq;

namespace CustomMinFunc
{
    class CustomMinFunc
    {
        static void Main(string[] args)
        {
            Func<List<int>, int> minNumber = numbers =>
            {
                int minNum = int.MaxValue;
                foreach (int num in numbers)
                {
                    if (num < minNum)
                    {
                        minNum = num;
                    }
                }

                return minNum;
            };

            List<int> numbers = Console.ReadLine().Split(" ").Select(int.Parse).ToList();
            int numNumber = minNumber(numbers);
            Console.WriteLine(numNumber);
        }
    }
}
