using System;
using System.Linq;
using System.Collections.Generic;

namespace FastFood
{
    class FastFood
    {
        static void Main(string[] args)
        {
            int quantityForDay = int.Parse(Console.ReadLine());


            Queue<int> ordersQueue = new Queue<int>(Console.ReadLine().Split().Select(int.Parse));

            Console.WriteLine(ordersQueue.Max());

            while (ordersQueue.Count > 0)
            {
                int order = ordersQueue.Peek();

                if (quantityForDay >= order)
                {
                    quantityForDay -= order;
                    ordersQueue.Dequeue();
                }
                else
                {
                    break;
                }
            }

            if (ordersQueue.Count == 0)
            {
                Console.WriteLine("Orders complete");
            }
            else
            {
                Console.WriteLine("Orders left: " + string.Join(" ", ordersQueue));
            }
        }
    }
}
