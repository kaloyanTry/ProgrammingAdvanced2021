using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.Problem
{
    class Bombs2
    {
        static void Main(string[] args)
        {
            int datura = 0;
            int cherry = 0;
            int smoke = 0;

            Queue<int> effects = new Queue<int>(Console.ReadLine().Split(',', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));
            Stack<int> casings = new Stack<int>(Console.ReadLine().Split(',', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));

            while (effects.Any() && casings.Any() && (datura < 3 || cherry < 3 || smoke < 3))
            {
                int effect = effects.Peek();
                int casing = casings.Peek();
                bool isBomb = false;

                if (effect + casing == 40)
                {
                    datura++;
                    isBomb = true;
                }
                else if (effect + casing == 60)
                {
                    cherry++;
                    isBomb = true;
                }
                else if (effect + casing == 120)
                {
                    smoke++;
                    isBomb = true;
                }
                else
                {
                    int decreasedCasing = casing - 5;
                    
                    if (decreasedCasing < 0)
                    {
                        decreasedCasing = 0;
                    }
                    
                    casings.Pop();
                    casings.Push(decreasedCasing);
                }

                if (isBomb)
                {
                    effects.Dequeue();
                    casings.Pop();
                }
            }

            if (datura >= 3 && cherry >= 3 && smoke >= 3)
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
                Console.WriteLine("Bomb Effects: " + string.Join(", ", effects));
            }

            if (casings.Count == 0)
            {
                Console.WriteLine("Bomb Casings: empty");
            }
            else
            {
                Console.WriteLine("Bomb Casings: " + string.Join(", ", casings));
            }

            Console.WriteLine($"Cherry Bombs: {cherry}");
            Console.WriteLine($"Datura Bombs: {datura}");
            Console.WriteLine($"Smoke Decoy Bombs: {smoke}");
        }
    }
}
