using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.FlowerWreaths
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<int> liliesStack = new Stack<int>(Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse));
            Queue<int> rosesQueue = new Queue<int>(Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse));

            int wreaths = 0;
            int flowersLeft = 0;

            while (liliesStack.Any() && rosesQueue.Any())
            {
                int lily = liliesStack.Peek();
                int rose = rosesQueue.Peek();

                if (lily + rose == 15)
                {
                    wreaths += 1;

                    liliesStack.Pop();
                    rosesQueue.Dequeue();
                }

                if (lily + rose > 15)
                {
                    int decreasedLily = lily - 2;

                    liliesStack.Pop();
                    liliesStack.Push(decreasedLily);
                }

                if (lily + rose < 15)
                {
                    flowersLeft += lily;
                    flowersLeft += rose;

                    liliesStack.Pop();
                    rosesQueue.Dequeue();
                }
            }

            for (int i = 1; i <= flowersLeft; i++)
            {
                if (i % 15 == 0)
                {
                    wreaths += 1;
                }
            }

            if (wreaths >= 5)
            {
                Console.WriteLine($"You made it, you are going to the competition with {wreaths} wreaths!");
            }
            else
            {
                Console.WriteLine($"You didn't make it, you need {5 - wreaths} wreaths more!");
            }
        }
    }
}
