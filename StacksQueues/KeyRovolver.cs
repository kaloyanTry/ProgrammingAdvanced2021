using System;
using System.Linq;
using System.Collections.Generic;

namespace KeyRevolver
{
    class KeyRovolver
    {
        static void Main(string[] args)
        {
            int bulletPrice = int.Parse(Console.ReadLine());
            int gunBarrelSize = int.Parse(Console.ReadLine());

            int[] bulletsInput = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Stack<int> bullets = new Stack<int>(bulletsInput);

            int[] lockInput = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Queue<int> locks = new Queue<int>(lockInput);

            int intelligenceValue = int.Parse(Console.ReadLine());
            int bulletCount = 0;

            int currentBarelSize = gunBarrelSize;
            while (bullets.Any() && locks.Any())
            {
  
                bulletCount++;
                currentBarelSize--;
                int currBullet = bullets.Pop();
                int currLock = locks.Peek();

                if (currBullet <= currLock)
                {
                    Console.WriteLine("Bang!");
                    locks.Dequeue();
                }
                else
                {
                    Console.WriteLine("Ping!");
                }

                if (currentBarelSize == 0 && bullets.Any())
                {
                    currentBarelSize = gunBarrelSize;
                    Console.WriteLine("Reloading!");

                }
            }

            if (!locks.Any())
            {
                int money = intelligenceValue - (bulletCount * bulletPrice);
                Console.WriteLine($"{bullets.Count} bullets left. Earned ${money}");
            }
            else
            {
                Console.WriteLine($"Couldn't get through. Locks left: {locks.Count}");
            }

            Console.WriteLine();
        }
    }
}
