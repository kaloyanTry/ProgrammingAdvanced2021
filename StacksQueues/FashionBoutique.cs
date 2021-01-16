using System;
using System.Linq;
using System.Collections.Generic;

namespace FashionBoutique
{
    class FashionBoutique
    {
        static void Main(string[] args)
        {
            int[] clothesInBox = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int rackCapacity = int.Parse(Console.ReadLine());

            int rackFill = 0;
            int racksNumber = 1;

            Stack<int> stackClothes = new Stack<int>(clothesInBox);

            while (stackClothes.Any())
            {
                int clothes = stackClothes.Pop();
                rackFill += clothes;

                if (rackFill > rackCapacity)
                {
                    racksNumber++;
                    rackFill = clothes;
                }
            }

            Console.WriteLine(racksNumber);
        }
    }
}
