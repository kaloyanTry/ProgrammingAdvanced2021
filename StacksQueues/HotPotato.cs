using System;
using System.Collections.Generic;
namespace HotPotato
{
    class HotPotato
    {
        static void Main(string[] args)
        {
            string[] inputNames = Console.ReadLine().Split();

            int n = int.Parse(Console.ReadLine());

            Queue<string> kidsQueue = new Queue<string>(inputNames);

            while (kidsQueue.Count != 1)
            {
                for (int i = 1; i < n; i++)
                {
                    kidsQueue.Enqueue(kidsQueue.Dequeue());

                }
                Console.WriteLine($"Removed {kidsQueue.Dequeue()}");
            }

            Console.WriteLine("Last is " + kidsQueue.Dequeue());
        }
    }
}
