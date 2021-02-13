using System;
using System.Collections.Generic;
using System.Linq;

namespace Scheduling
{
    class SchedulingCPU
    {
        static void Main(string[] args)
        {
            int[] tasks = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int[] threads = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            int taskValue = int.Parse(Console.ReadLine());

            Stack<int> stackTasks = new Stack<int>(tasks.Length);
            Queue<int> queueThreads = new Queue<int>(threads.Length);

            for (int s = 0; s < tasks.Length; s++)
            {
                stackTasks.Push(tasks[s]);
            }

            for (int q = 0; q < threads.Length; q++)
            {
                queueThreads.Enqueue(threads[q]);
            }

            int taskRemains = 0;
            int threadValue = 0;

            while (queueThreads.Count > 0 && stackTasks.Count > 0)
            {

                if (queueThreads.Peek() >= stackTasks.Peek())
                {
                    stackTasks.Pop();
                    queueThreads.Dequeue();
                }
                else
                {    
                    queueThreads.Dequeue();
                }

                threadValue = queueThreads.Peek();
                taskRemains = stackTasks.Peek();

                if (taskValue == taskRemains)
                {
                    break;
                }
            }

            Console.WriteLine($"Thread with value {threadValue} killed task {taskRemains}");

            Console.WriteLine(string.Join(" ", queueThreads));
        }
    }
}
