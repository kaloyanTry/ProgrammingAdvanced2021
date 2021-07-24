using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.Problem
{
    class Cooking
    {
        static void Main(string[] args)
        {
            Stack<int> tasks = new Stack<int>(Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));
            Queue<int> threads = new Queue<int>(Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));

            int taskToKill = int.Parse(Console.ReadLine());
            int lastThread = 0;

            while (true)
            {
                int task = tasks.Peek();
                int thread = threads.Peek();

                if (thread >= task)
                {
                    tasks.Pop();
                    threads.Dequeue();
                }
                else
                {
                    threads.Dequeue();
                }

                if (task == taskToKill)
                {
                    lastThread = thread;
                    Console.WriteLine($"Thread with value {thread} killed task {taskToKill}");
                    break;
                }
            }

            Console.WriteLine($"{lastThread} " + string.Join(' ', threads));
        }
    }
}
