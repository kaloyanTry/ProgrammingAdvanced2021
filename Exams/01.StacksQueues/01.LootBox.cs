using System;
using System.Linq;
using System.Collections.Generic;

namespace _01.LootBox
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<int> firstLootQueue = new Queue<int>(Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));
            Stack<int> secondLootStack = new Stack<int>(Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));
            int summedCollection = 0;

            while (firstLootQueue.Any() && secondLootStack.Any())
            {
                int firstLoot = firstLootQueue.Peek();
                int secondLoot = secondLootStack.Peek();

                if ((firstLoot + secondLoot) % 2 == 0)
                {
                    summedCollection += (firstLoot + secondLoot);

                    firstLootQueue.Dequeue();
                    secondLootStack.Pop();
                }
                else
                {
                    firstLootQueue.Enqueue(secondLoot);
                    secondLootStack.Pop();
                }

                if (firstLootQueue.Count == 0)
                {
                    Console.WriteLine("First lootbox is empty");
                    break;
                }

                if (secondLootStack.Count == 0)
                {
                    Console.WriteLine("Second lootbox is empty");
                    break;
                }
            }

            if (summedCollection >= 100)
            {
                Console.WriteLine($"Your loot was epic! Value: {summedCollection}");
            }
            else
            {
                Console.WriteLine($"Your loot was poor... Value: {summedCollection}");
            }
        }
    }
}