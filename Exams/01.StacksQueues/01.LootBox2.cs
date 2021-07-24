using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.Problem
{
    class Cooking
    {
        static void Main(string[] args)
        {
            List<int> claimedItems = new List<int>();

            Queue<int> firstLoot = new Queue<int>(Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));
            Stack<int> secondLoot = new Stack<int>(Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));
            
            while (firstLoot.Any() && secondLoot.Any())
            {
                int itemFirst = firstLoot.Peek();
                int itemSecond = secondLoot.Peek();

                if ((itemFirst + itemSecond) % 2 == 0)
                {
                    claimedItems.Add(itemFirst + itemSecond);
                    firstLoot.Dequeue();
                    secondLoot.Pop();
                }
                else
                {
                    int lastItemSecondLoot = itemSecond;
                    secondLoot.Pop();
                    firstLoot.Enqueue(lastItemSecondLoot);
                }
            }

            if (firstLoot.Count == 0)
            {
                Console.WriteLine("First lootbox is empty");
            }

            if (secondLoot.Count == 0)
            {
                Console.WriteLine("Second lootbox is empty");
            }

            if (claimedItems.Sum() >= 100)
            {
                Console.WriteLine($"Your loot was epic! Value: {claimedItems.Sum()}");
            }
            else
            {
                Console.WriteLine($"Your loot was poor... Value: {claimedItems.Sum()}");
            }
        }
    }
}
