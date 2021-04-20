using System;
using System.Collections.Generic;
using System.Linq;

namespace Ex3.MaxMinElement
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            
            Stack<int> stackQueue = new Stack<int>();

            for (int i = 0; i < n; i++)
            {
                int[] inputNums = Console.ReadLine().Split().Select(int.Parse).ToArray();

                int firstNum = inputNums[0];

                if (firstNum == 1)
                {
                    int secondNum = inputNums[1];
                    stackQueue.Push(secondNum);
                }
                else if (firstNum == 2)
                {
                    if (stackQueue.Count > 0)
                    {
                        stackQueue.Pop();
                    }                
                }
                else if (firstNum == 3)
                {
                    if (stackQueue.Count > 0)
                    {
                        Console.WriteLine(stackQueue.Max());
                    }                   
                }
                else if (firstNum == 4)
                {
                    if (stackQueue.Count > 0)
                    {
                        Console.WriteLine(stackQueue.Min());
                    }      
                }
            }

            if (stackQueue.Count > 0)
            {
                Console.WriteLine(string.Join(", ", stackQueue));
            }           
        }
    }
}
