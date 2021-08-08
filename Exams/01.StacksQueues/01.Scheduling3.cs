using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.Problem
{
    class Brackets2
    {
        static void Main(string[] args)
        {
            Stack<int> tasks = new Stack<int>(Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));
            Queue<int> threads = new Queue<int>(Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));
            int taskToKill = int.Parse(Console.ReadLine());

            while (tasks.Any() && threads.Any())
            {
                int task = tasks.Peek();
                int thread = threads.Peek();

                if (task == taskToKill)
                {
                    Console.WriteLine($"Thread with value {thread} killed task {taskToKill}");
                    break;
                }

                if (thread >= task)
                {
                    tasks.Pop();
                    threads.Dequeue();
                }
                else if (thread < task)
                {
                    threads.Dequeue();
                }
            }

            if (threads.Any())
            {
                Console.WriteLine(string.Join(' ', threads));
            }
        }
    }
}
