using System;
using System.Linq;
using System.Collections.Generic;

namespace LootBox
{
    class LootBox
    {
        static void Main(string[] args)
        {
            int[] firstInput = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int[] secondInput = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            Queue<int> firstBoxQueue = new Queue<int>(firstInput.Length);
            Stack<int> secondBoxStack = new Stack<int>(secondInput.Length);

            for (int i = 0; i < firstInput.Length; i++)
            {
                firstBoxQueue.Enqueue(firstInput[i]);
            }
            for (int i = 0; i < secondInput.Length; i++)
            {
                secondBoxStack.Push(secondInput[i]);
            }

            int sumClaimedItems = 0;

            while (firstBoxQueue.Count > 0 && secondBoxStack.Count > 0)
            {
                int currentFirst = firstBoxQueue.Peek();
                int currentSecond = secondBoxStack.Peek();
                int currentsSum = currentFirst + currentSecond;

                if (currentsSum % 2 == 0)
                {
                    sumClaimedItems += currentsSum;
                    firstBoxQueue.Dequeue();
                    secondBoxStack.Pop();
                }
                else
                {
                    int temp = currentSecond;
                    secondBoxStack.Pop();
                    firstBoxQueue.Enqueue(temp);
                }
            }

            if (firstBoxQueue.Count == 0 && secondBoxStack.Count > 0)
            {
                Console.WriteLine("First lootbox is empty");
            }
            else
            {
                Console.WriteLine("Second lootbox is empty");
            }

            if (sumClaimedItems >= 100)
            {
                Console.WriteLine($"Your loot was epic! Value: {sumClaimedItems}");

            }
            else
            {
                Console.WriteLine($"Your loot was poor... Value: {sumClaimedItems}");
            }
        }
    }
}
