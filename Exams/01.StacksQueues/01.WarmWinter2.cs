using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.Problem
{
    class WarmWinter2
    {
        static void Main(string[] args)
        {
            Queue<int> sets = new Queue<int>();
            int mostExpensiveSet = 0;

            Stack<int> hats = new Stack<int>(Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));
            Queue<int> scarfs = new Queue<int>(Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));

            while (hats.Any() && scarfs.Any())
            {
                int set = 0;

                int hat = hats.Peek();
                int scarf = scarfs.Peek();

                if (hat > scarf)
                {
                    set = hat + scarf;
                    sets.Enqueue(set);

                    hats.Pop();
                    scarfs.Dequeue();
                }
                else if (hat < scarf)
                {
                    hats.Pop();
                    continue;
                }
                else if (hat == scarf)
                {
                    int incrementedHat = hat + 1;

                    scarfs.Dequeue();
                    hats.Pop();
                    hats.Push(incrementedHat);
                }

                if (set > mostExpensiveSet)
                {
                    mostExpensiveSet = set;
                }
            }

            Console.WriteLine($"The most expensive set is: {mostExpensiveSet}");
            Console.WriteLine(string.Join(' ', sets));
        }
    }
}
