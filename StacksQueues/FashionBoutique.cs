using System;
using System.Linq;
using System.Collections.Generic;

namespace FashionBoutique
{
    class FashionBoutique
    {
        static void Main(string[] args)
        {
            int[] allClothesInBox = Console.ReadLine().Split().Select(int.Parse).ToArray();

            Stack<int> allClothes = new Stack<int>(allClothesInBox);

            int boxCapacity = int.Parse(Console.ReadLine());

            int currentRackCapacity = boxCapacity;
            int racksCount = 1;

            while (allClothes.Any())
            {
                int clothes = allClothes.Pop();

                currentRackCapacity -= clothes;

                if (currentRackCapacity < 0)
                {
                    racksCount++;
                    currentRackCapacity = boxCapacity - clothes;
                }
            }

            Console.WriteLine(racksCount);
        }
    }
}
