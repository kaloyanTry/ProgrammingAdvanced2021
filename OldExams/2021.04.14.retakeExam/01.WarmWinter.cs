using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleRetake
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<int> hatsStack = new Stack<int> (Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse));

            Queue<int> scarfsQueue = new Queue<int>(Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse));

            Queue<int> sets = new Queue<int>();
            int maxSet = 0;

            while (hatsStack.Any() && scarfsQueue.Any())
            {
                int hat = hatsStack.Peek();
                int scarf = scarfsQueue.Peek();
                int set = 0;

                if (hat > scarf)
                {
                    set = hat + scarf;

                    sets.Enqueue(set);

                    hatsStack.Pop();
                    scarfsQueue.Dequeue();

                    if (set > maxSet)
                    {
                        maxSet = set;
                    }
                }
                else if (hat < scarf)
                {
                    hatsStack.Pop();
                }
                else if (hat == scarf)
                {
                    scarfsQueue.Dequeue();
                    hatsStack.Pop();

                    hat += 1;
                    hatsStack.Push(hat);
                }
            }

            Console.WriteLine($"The most expensive set is: {maxSet}");
            Console.WriteLine(string.Join(' ', sets));
        }
    }
}
