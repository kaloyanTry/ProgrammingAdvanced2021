using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.Problem
{
    class Program
    {
        static void Main(string[] args)
        {
            int daturaBombsCount = 0;
            int cherryBombsCount = 0;
            int smokeBombsCount = 0;

            Queue<int> bombEffect = new Queue<int>(Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));
            Stack<int> bombCasing = new Stack<int>(Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));

            while ((bombCasing.Any() && bombEffect.Any()) &&(daturaBombsCount < 3 || cherryBombsCount < 3 || smokeBombsCount < 3))
            {
                int casing = bombCasing.Peek();
                int effect = bombEffect.Peek();

                if (casing + effect == 40)
                {
                    daturaBombsCount++;
                    bombCasing.Pop();
                    bombEffect.Dequeue();
                }
                else if (casing + effect == 60)
                {
                    cherryBombsCount++;
                    bombCasing.Pop();
                    bombEffect.Dequeue();
                }
                else if (casing + effect == 120)
                {
                    smokeBombsCount++;
                    bombCasing.Pop();
                    bombEffect.Dequeue();
                }
                else
                {
                    casing -= 5;
                    if (casing < 0)
                    {
                        casing = 0;
                    }
                    bombCasing.Pop();
                    bombCasing.Push(casing);
                }
                
                //if (!bombCasing.Any() || !bombEffect.Any())
                //{
                //    break;
                //}
            }

            if (daturaBombsCount >= 3 && cherryBombsCount >= 3 && smokeBombsCount >= 3)
            {
                Console.WriteLine($"Bene! You have successfully filled the bomb pouch!");
            }
            else
            {
                Console.WriteLine("You don't have enough materials to fill the bomb pouch.");
            }

            if (bombEffect.Any())
            {
                Console.WriteLine("Bomb Effects: " + string.Join(", ", bombEffect));
            }
            else
            {
                Console.WriteLine("Bomb Effects: empty");
            }

            if (bombCasing.Any())
            {
                Console.WriteLine("Bomb Casings: " + string.Join(", ", bombCasing));
            }
            else
            {
                Console.WriteLine("Bomb Casings: empty");
            }

            Console.WriteLine($"Cherry Bombs: {cherryBombsCount}");
            Console.WriteLine($"Datura Bombs: {daturaBombsCount}");
            Console.WriteLine($"Smoke Decoy Bombs: {smokeBombsCount}");
        }
    }
}
