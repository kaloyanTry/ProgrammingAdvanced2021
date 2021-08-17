using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.Problem
{
    class WarmWinter
    {
        static void Main(string[] args)
        {
            Stack<int> hats = new Stack<int>(Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));

            Queue<int> scarfs = new Queue<int>(Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));

            Queue<int> sets = new Queue<int>();

            while (hats.Any() && scarfs.Any())
            {
                int hat = hats.Peek();
                int scarf = scarfs.Peek();
                int set = 0;

                if (hat > scarf)
                {
                    set = hat + scarf;
                    hats.Pop();
                    scarfs.Dequeue();

                    sets.Enqueue(set);
                }
                else if (hat < scarf)
                {
                    hats.Pop();
                }
                else if (hat == scarf)
                {
                    int hatIncremented = hat + 1;
                    scarfs.Dequeue();
                    hats.Pop();
                    hats.Push(hatIncremented);
                }
            }

            Console.WriteLine($"The most expensive set is: {sets.Max()}");

            Console.WriteLine(string.Join(' ', sets));
        }
    }
}
