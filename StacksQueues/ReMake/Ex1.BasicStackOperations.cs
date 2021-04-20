using System;
using System.Collections.Generic;
using System.Linq;

namespace _11.BasicStackOperations
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] inputCmd = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int nPush = inputCmd[0];
            int sPop = inputCmd[1];
            int xSearch = inputCmd[2];
            Stack<int> stackNums = new Stack<int>();

            int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();

            for (int i = 0; i < nPush; i++)
            {
                stackNums.Push(input[i]);
            }

            for (int i = 0; i < sPop; i++)
            {
                stackNums.Pop();
            }

            if (stackNums.Contains(xSearch))
            {
                Console.WriteLine("true");
            }
            else
            {
                if (stackNums.Count > 0)
                {
                    Console.WriteLine(stackNums.Min());
                }
                else
                {
                    Console.WriteLine(0);
                }
            }
        }
    }
}
