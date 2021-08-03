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

            //int mostExpensiveSet = 0;
            Queue<int> sets = new Queue<int>();

            while (hats.Any() && scarfs.Any())
            {
                int hat = hats.Peek();
                int scarf = scarfs.Peek();
                int set = 0;

                if (hat > scarf)
                {
                    set = hat + scarf;
                    sets.Enqueue(set);

                    hats.Pop();
                    scarfs.Dequeue();
                }
                else if (scarf > hat)
                {
                    hats.Pop();
                }
                else if (scarf == hat)
                {
                    scarfs.Dequeue();
                    int lastHat = hat + 1;
                    hats.Pop();
                    hats.Push(lastHat);
                }
            }

            int mostExpensiveSet = sets.Max();

            Console.WriteLine($"The most expensive set is: {mostExpensiveSet}");

            Console.WriteLine(string.Join(' ', sets));
        }
    }
}
