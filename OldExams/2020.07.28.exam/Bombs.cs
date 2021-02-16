using System;
using System.Collections.Generic;
using System.Linq;

namespace Bombs
{
    class Bombs
    {
        static void Main(string[] args)
        {
            int[] firstInput = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int[] secondInput = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            Queue<int> effects = new Queue<int>(firstInput.Length);
            Stack<int> casings = new Stack<int>(secondInput.Length);

            for (int i = 0; i < firstInput.Length; i++)
            {
                effects.Enqueue(firstInput[i]);
            }
            for (int i = 0; i < secondInput.Length; i++)
            {
                casings.Push(secondInput[i]);
            }
            int daturaCount = 0;
            int cheryCount = 0;
            int smokeCount = 0;
            int decreaseCasing = 0;

            while (effects.Count > 0 && casings.Count > 0)
            {
                if (daturaCount >= 3 && cheryCount >= 3 && smokeCount >= 3)
                {
                    break;
                }

                int currEffect = effects.Peek();
                int currCasing = casings.Peek() - decreaseCasing;
                bool isBomb = false;

                if (currCasing + currEffect == 40)
                {
                    daturaCount++;
                    isBomb = true;
                }
                else if (currCasing + currEffect == 60)
                {
                    cheryCount++;
                    isBomb = true;
                }
                else if (currCasing + currEffect == 120)
                {
                    smokeCount++;
                    isBomb = true;
                }

                if (isBomb)
                {
                    effects.Dequeue();
                    casings.Pop();
                    decreaseCasing = 0;
                }
                else if (currCasing <= 0)
                {
                    casings.Pop();
                    decreaseCasing = 0;
                }
                else
                {
                    decreaseCasing += 5;
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

            if (effects.Count == 0)
            {
                Console.WriteLine("Bomb Effects: empty");
            }
            else
            {
                Console.Write("Bomb Effects: ");
                Console.WriteLine(string.Join(", ", effects));
            }

            if (casings.Count == 0)
            {
                Console.WriteLine("Bomb Casings: empty");
            }
            else
            {
                Console.Write("Bomb Casings: ");
                Console.WriteLine(string.Join(", ", casings));
            }

            Console.WriteLine($"Cherry Bombs: {cheryCount}");
            Console.WriteLine($"Datura Bombs: {daturaCount}");
            Console.WriteLine($"Smoke Decoy Bombs: {smokeCount}");
        }
    }
}
