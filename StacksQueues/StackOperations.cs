using System;
using System.Collections.Generic;
using System.Linq;

namespace BasicStackOperations
{
    class StackOperations
    {
        static void Main(string[] args)
        {
            
            int[] inputNums = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int nPush = inputNums[0];
            int sPop = inputNums[1];
            int xContains = inputNums[2];

            int[] inputArray = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Stack<int> intStack = new Stack<int>();

            for (int i = 0; i < nPush; i++)
            {
                intStack.Push(inputArray[i]);
            }

            for (int i = 0; i < sPop; i++)
            {
                intStack.Pop();
            }

            if (intStack.Count != 0)
            {
                if (intStack.Contains(xContains))
                {
                    Console.WriteLine("true");
                }
                else
                {
                    Console.WriteLine(intStack.Min());
                }
            }
            else
            {
                Console.WriteLine(0);
            }
       
        }
    }
}