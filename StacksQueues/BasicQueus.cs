using System;
using System.Linq;
using System.Collections.Generic;

namespace BasicQueueOperations
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] inputNums = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int nPush = inputNums[0];
            int sPop = inputNums[1];
            int xContains = inputNums[2];

            int[] inputArray = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Queue<int> intQueue = new Queue<int>();

            for (int i = 0; i < nPush; i++)
            {
                intQueue.Enqueue(inputArray[i]);
            }

            for (int i = 0; i < sPop; i++)
            {
                intQueue.Dequeue();

            }

            if (intQueue.Contains(xContains))
            {
                Console.WriteLine("true");
            }
            else if (intQueue.Count == 0)
            {
                Console.WriteLine(0);
            }
            else
            {
                Console.WriteLine(intQueue.Min());
            }

        }
    }
}
