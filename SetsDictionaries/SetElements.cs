using System;
using System.Linq;
using System.Collections.Generic;

namespace SetsOfElements
{
    class SetElements
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split();
            int nLenght = int.Parse(input[0]);
            int mLenght = int.Parse(input[1]);

            HashSet<int> firstSet = new HashSet<int>();
            HashSet<int> secondSet = new HashSet<int>();

            for (int i = 0; i < nLenght + mLenght; i++)
            {
                int nNums = int.Parse(Console.ReadLine());

                if (i < nLenght)
                {
                    firstSet.Add(nNums);
                }
                else
                {
                    secondSet.Add(nNums);
                }
            }

            firstSet.IntersectWith(secondSet);

            Console.WriteLine(string.Join(" ", firstSet));
        }
    }
}
