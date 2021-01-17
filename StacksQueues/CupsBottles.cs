using System;
using System.Linq;
using System.Collections.Generic;

namespace CupsBottles
{
    class CupsBottles
    {
        static void Main(string[] args)
        {
            int[] cups = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int[] bottles = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int wastedWater = 0;

            Queue<int> cupsCapacity = new Queue<int>(cups);
            Stack<int> bottlesCapacity = new Stack<int>(bottles);

            while (cupsCapacity.Any() && bottlesCapacity.Any())
            {
                int cup = cupsCapacity.Peek();
                int currentCupLevel = 0;
                while (currentCupLevel < cup && bottlesCapacity.Any())
                {
                    int bottle = bottlesCapacity.Pop();
                    currentCupLevel += bottle;
                }

                cupsCapacity.Dequeue();
                wastedWater += currentCupLevel - cup;
            }

            if (!cupsCapacity.Any())
            {
                Console.WriteLine("Bottles: " + string.Join(" ", bottlesCapacity));
            }
            else if (!bottlesCapacity.Any())
            {
                Console.WriteLine("Cups: " + string.Join(" ", cupsCapacity));
            }

            Console.WriteLine("Wasted litters of water: " + wastedWater);
        }
    }
}
