using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] inputNames = Console.ReadLine().Split();
            int n = int.Parse(Console.ReadLine());

            Queue<string> queueNames = new Queue<string>(inputNames);

            while (queueNames.Count > 1)
            {
                for (int i = 1; i < n; i++)
                {
                    queueNames.Enqueue(queueNames.Dequeue());
                }

                Console.WriteLine($"Removed {queueNames.Dequeue()}");
            }

            Console.WriteLine("Last is " + queueNames.Dequeue());
        }
    }
}
