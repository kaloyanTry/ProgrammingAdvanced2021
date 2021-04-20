using System;
using System.Collections.Generic;
using System.Linq;

namespace _2.StackSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] inputNums = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int sum = 0;
            Stack<int> stackSum = new Stack<int>(inputNums);

            foreach (var num in inputNums)
            {
                stackSum.Push(num);
            }

            string cmd = Console.ReadLine().ToLower();
            while (cmd != "end")
            {
                string[] inputString = cmd.Split();

                string command = inputString[0];
                if (command == "add")
                {
                    int firstNum = int.Parse(inputString[1]);
                    int secondNum = int.Parse(inputString[2]);

                    stackSum.Push(firstNum);
                    stackSum.Push(secondNum);
                }

                if (command == "remove")
                {
                    int remNum = int.Parse(inputString[1]);

                    if (stackSum.Count >= remNum)
                    {
                        while(remNum > 0)
                        {
                            stackSum.Pop();
                            remNum--;
                        }
                    }
                }

                cmd = Console.ReadLine().ToLower();
            }

            sum = stackSum.Sum();
            Console.WriteLine($"Sum: {sum}");
        }
    }
}
