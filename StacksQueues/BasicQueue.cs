using System;
using System.Linq;
using System.Collections.Generic;

namespace BasicQueueOperations
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int numEnque = input[0];
            int numDeque = input[1];
            int numLook = input[2];

            int[] numsInput = Console.ReadLine().Split().Select(int.Parse).ToArray();
           
            int smallestNum = int.MaxValue;
            Queue<int> nums = new Queue<int>();

            for (int i = 0; i < numEnque; i++)
            {
                nums.Enqueue(numsInput[i]);
            }

            for (int j = 0; j < numDeque; j++)
            {
                nums.Dequeue();
            }

            if (nums.Contains(numLook))
            {
                Console.WriteLine("true");
            }
            else if (nums.Count == 0)
            {
                Console.WriteLine("0");
            }
            else
            {
                smallestNum = nums.Min();
                Console.WriteLine(smallestNum);
            }
        }
    }
}
