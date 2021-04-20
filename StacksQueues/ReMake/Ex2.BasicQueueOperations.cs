using System;
using System.Collections.Generic;
using System.Linq;

namespace Ex2.BasicQueueOperations
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] inputCmd = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int nPush = inputCmd[0];
            int sPop = inputCmd[1];
            int xSearch = inputCmd[2];

            Queue<int> queueNums = new Queue<int>();

            int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();

            for (int i = 0; i < nPush; i++)
            {
                queueNums.Enqueue(input[i]);
            }

            for (int i = 0; i < sPop; i++)
            {
                queueNums.Dequeue();
            }

            if (queueNums.Contains(xSearch))
            {
                Console.WriteLine("true");
            }
            else
            {
                if (queueNums.Count > 0)
                {
                    Console.WriteLine(queueNums.Min());
                }
                else
                {
                    Console.WriteLine(0);
                }
            }
        }
    }
}
