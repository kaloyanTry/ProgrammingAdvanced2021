using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.Bombs
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<int> bombsEffectQueue = new Queue<int>(Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse));
            Stack<int> bombsCasingStack = new Stack<int>(Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse));

            int bombsDatura = 0;
            int bombsChery = 0;
            int bombsSmokeDecony = 0;

            int datura = 40;
            int chery = 60;
            int smokeDecony = 120;

            while (bombsEffectQueue.Any() && bombsCasingStack.Any() && (bombsDatura < 3 || bombsChery < 3 || bombsSmokeDecony < 3))
            {
                int bombEffect = bombsEffectQueue.Peek();
                int bombCasing = bombsCasingStack.Peek();
                bool isCreatedBomb = false;

                if (bombEffect + bombCasing == datura)
                {
                    bombsDatura++;
                    isCreatedBomb = true;
                }
                else if (bombEffect + bombCasing == chery)
                {
                    bombsChery++;
                    isCreatedBomb = true;
                }
                else if (bombEffect + bombCasing == smokeDecony)
                {
                    bombsSmokeDecony++;
                    isCreatedBomb = true;
                }
                else
                {
                    int decresedCasing = bombCasing - 5;
                    if (decresedCasing < 0)
                    {
                        decresedCasing = 0;
                    }
                    bombsCasingStack.Pop();
                    bombsCasingStack.Push(decresedCasing);
                }

                if (isCreatedBomb)
                {
                    bombsCasingStack.Pop();
                    bombsEffectQueue.Dequeue();
                }

                if (bombsCasingStack.Count == 0 || bombsEffectQueue.Count == 0)
                {
                    break;
                }
            }

            if (bombsDatura < 3 || bombsChery < 3 || bombsSmokeDecony < 3)
            {
                Console.WriteLine("You don't have enough materials to fill the bomb pouch.");
            }
            else
            {
                Console.WriteLine("Bene! You have successfully filled the bomb pouch!");
            }

            if (bombsEffectQueue.Any())
            {
                Console.WriteLine("Bomb Effects: " + string.Join(", ", bombsEffectQueue));
            }
            else
            {
                Console.WriteLine("Bomb Effects: empty");
            }

            if (bombsCasingStack.Any())
            {
                Console.WriteLine("Bomb Casings: " + string.Join(", ", bombsCasingStack));
            }
            else
            {
                Console.WriteLine("Bomb Casings: empty");
            }

            Console.WriteLine($"Cherry Bombs: {bombsChery}");
            Console.WriteLine($"Datura Bombs: {bombsDatura}");
            Console.WriteLine($"Smoke Decoy Bombs: {bombsSmokeDecony}");
        }
    }
}
