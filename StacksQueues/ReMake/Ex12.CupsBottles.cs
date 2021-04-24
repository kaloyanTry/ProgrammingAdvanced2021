using System;
using System.Collections.Generic;
using System.Linq;

namespace Еx12.CupsBottles
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] inputCups = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int[] inputBottles = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int wastedWater = 0;

            Queue<int> cupsQueue = new Queue<int>(inputCups);
            Stack<int> bottlesStack = new Stack<int>(inputBottles);

            while (cupsQueue.Any() && bottlesStack.Any())
            {
                int currentCupCapacity = cupsQueue.Peek();
                int currentCupLevel = 0;

                while (currentCupLevel < currentCupCapacity && bottlesStack.Any())
                {
                    int currentBottle = bottlesStack.Pop();
                    currentCupLevel += currentBottle;
                }

                cupsQueue.Dequeue();
                wastedWater += currentCupLevel - currentCupCapacity;
            }

            if (!cupsQueue.Any())
            {
                Console.WriteLine("Bottles: " + string.Join(" ", bottlesStack));
            }
            else if (!bottlesStack.Any())
            {
                Console.WriteLine("Cups: " + string.Join(" ", cupsQueue));
            }

            Console.WriteLine("Wasted litters of water: " + wastedWater);
        }
    }
}
