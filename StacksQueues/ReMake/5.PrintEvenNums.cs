using System;
using System.Collections.Generic;
using System.Linq;

namespace _5.PrintEvenNumbersQueue
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();

            Queue<int> queueEvens = new Queue<int>();

            for (int i = 0; i < input.Length; i++)
            {
                int curNum = input[i];
                if (curNum % 2 == 0)
                {
                    queueEvens.Enqueue(curNum);
                }
            }

            Console.WriteLine(string.Join(", ", queueEvens));
        }
    }
}
