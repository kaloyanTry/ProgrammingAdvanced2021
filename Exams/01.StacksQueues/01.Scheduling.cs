using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.Scheduling
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<int> tasksStack = new Stack <int>(Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse));
            Queue<int> threadsQueue = new Queue<int>(Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));
            int taskToKill = int.Parse(Console.ReadLine());


            while (tasksStack.Any() && threadsQueue.Any())
            {
                int task = tasksStack.Peek();
                int thread = threadsQueue.Peek();
                
                if (task == taskToKill)
                {
                    Console.WriteLine($"Thread with value {thread} killed task {task}");
                    break;
                }

                if (thread >= task)
                {
                    tasksStack.Pop();
                    threadsQueue.Dequeue();
                }
                else
                {
                    threadsQueue.Dequeue();
                }
            }

            Console.WriteLine(string.Join(" ", threadsQueue));
        }
    }
}
