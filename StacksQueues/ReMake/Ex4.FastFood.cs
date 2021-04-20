using System;
using System.Collections.Generic;
using System.Linq;

namespace Ex4.FastFood
{
    class Program
    {
        static void Main(string[] args)
        {
            int foodAll = int.Parse(Console.ReadLine());

            Queue<int> queueOrders = new Queue<int>(Console.ReadLine().Split().Select(int.Parse));

            Console.WriteLine(queueOrders.Max());

            while (queueOrders.Count > 0)
            {
                int order = queueOrders.Peek();
                if (foodAll >= order)
                {
                    foodAll -= order;
                    queueOrders.Dequeue();
                }
                else
                {
                    break;
                }
            }

            if (queueOrders.Count == 0)
            {
                Console.WriteLine("Orders complete");
            }
            else
            {
                Console.WriteLine("Orders left: " + string.Join(" ", queueOrders));
            }
        }
    }
}
