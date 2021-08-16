using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.Bombs
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<int> effects = new Queue<int>(Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));

            Stack<int> casings = new Stack<int>(Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));

            bool isPouch = false;
            int datura = 0;
            int chery = 0;
            int smoke = 0;

            while (effects.Any() && casings.Any())
            {
                int effect = effects.Peek();
                int casing = casings.Peek();

                if (effect + casing == 40)
                {
                    datura++;
                    casings.Pop();
                    effects.Dequeue();
                }
                else if (effect + casing == 60)
                {
                    chery++;
                    casings.Pop();
                    effects.Dequeue();
                }
                else if (effect + casing == 120)
                {
                    smoke++;
                    casings.Pop();
                    effects.Dequeue();
                }
                else
                {
                    int decreasedCasing = casing - 5;
                    casings.Pop();
                    casings.Push(decreasedCasing);
                }

                if (datura >= 3 && smoke >= 3 && chery >= 3)
                {
                    isPouch = true;
                    break;
                }
            }

            if (isPouch)
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

            Console.WriteLine($"Cherry Bombs: {chery}");
            Console.WriteLine($"Datura Bombs: {datura}");
            Console.WriteLine($"Smoke Decoy Bombs: {smoke}");
        }
    }
}
