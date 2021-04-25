using System;
using System.Collections.Generic;
using System.Linq;

namespace Еx12.CupsBottles
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<int> cupsQueue = new Queue<int>(Console.ReadLine().Split().Select(int.Parse));
            Stack<int> bottlesStack = new Stack<int>(Console.ReadLine().Split().Select(int.Parse));

            int wastedWater = 0;

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
                wastedWater +=  currentCupLevel - currentCupCapacity;
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
