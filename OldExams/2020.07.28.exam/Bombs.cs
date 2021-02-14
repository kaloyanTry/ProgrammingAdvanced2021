using System;
using System.Collections.Generic;
using System.Linq;

namespace Console2020._07._27
{
    class Bombs
    {
        static void Main(string[] args)
        {
            int[] inputBombs = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
            int[] inputCasing = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();

            Queue<int> bombEffectQueue = new Queue<int>(inputBombs.Length);
            Stack<int> bombCasingStack = new Stack<int>(inputCasing.Length);

            for (int i = 0; i < inputBombs.Length; i++)
            {
                bombEffectQueue.Enqueue(inputBombs[i]);
            }

            for (int i = 0; i < inputCasing.Length; i++)
            {
                bombCasingStack.Push(inputCasing[i]);
            }

            int daturaCount = 0;
            int cheryCount = 0;
            int smokeCount = 0;
            int decrease = 0;

            while (bombEffectQueue.Count > 0 && bombCasingStack.Count > 0)
            {
                if (daturaCount >= 3 && cheryCount >= 3 && smokeCount >= 3)
                {
                    break;
                }

                int currentEffect = bombEffectQueue.Peek();
                int currentCase = bombCasingStack.Peek() - decrease;
                bool bombCreated = false;

                if (currentEffect + currentCase == 40)
                {
                    daturaCount++;
                    bombCreated = true;

                }
                else if (currentEffect + currentCase == 60)
                {
                    cheryCount++;
                    bombCreated = true;
                }
                else if (currentEffect + currentCase == 120)
                {
                    smokeCount++;
                    bombCreated = true;              
                }
                if (bombCreated)
                {
                    bombEffectQueue.Dequeue();
                    bombCasingStack.Pop();
                    decrease = 0;
                }
                else if (currentCase <= 0)
                {
                    bombCasingStack.Pop();
                    decrease = 0;
                }
                else
                {
                    decrease += 5;
                }
            }

            if (daturaCount >= 3 && cheryCount >= 3 && smokeCount >= 3)
            {
                Console.WriteLine("Bene! You have successfully filled the bomb pouch!");
            }
            else
            {
                Console.WriteLine("You don't have enough materials to fill the bomb pouch.");
            }

            if (bombEffectQueue.Count == 0)
            {
                Console.WriteLine("Bomb Effects: empty");
            }
            else
            {
                Console.WriteLine($"Bomb Effects: {String.Join(", ", bombEffectQueue)}");
            }

            if (bombCasingStack.Count == 0)
            {
                Console.WriteLine("Bomb Casings: empty");
            }
            else
            {
                Console.WriteLine($"Bomb Casings: {String.Join(", ", bombCasingStack)}");
            }

            Console.WriteLine($"Cherry Bombs: {cheryCount}");
            Console.WriteLine($"Datura Bombs: {daturaCount}");
            Console.WriteLine($"Smoke Decoy Bombs: {smokeCount}");
        }
    }
}
