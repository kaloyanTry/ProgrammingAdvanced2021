using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.CustomMinFunction
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<List<int>, int> minNumber = inputNums =>
            {
                int minNum = int.MaxValue;
                foreach (int num in inputNums)
                {
                    if (num < minNum)
                    {
                        minNum = num;
                    }
                }

                return minNum;
            };


            List<int> inputNums = Console.ReadLine().Split().Select(int.Parse).ToList();
            int number = minNumber(inputNums);

            Console.WriteLine(number);
        }
    }
}
