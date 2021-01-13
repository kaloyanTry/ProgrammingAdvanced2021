using System;
using System.Collections.Generic;
using System.Linq;

namespace SuperMarket
{
    class SuperMarket
    {
        static void Main(string[] args)
        {

            Queue<string> namesQueue = new Queue<string>();
            string inputNames = Console.ReadLine();
            int countLeftInMarket = 0;

            while (inputNames != "End")
            {
                
                if (inputNames == "Paid")
                {
                    while (namesQueue.Any())
                    {
                        Console.WriteLine(namesQueue.Dequeue());
                    }         
                }
                else
                {
                    namesQueue.Enqueue(inputNames);
                }

                
                inputNames = Console.ReadLine();
            }

            Console.WriteLine($"{namesQueue.Count} people remaining.");
        }
    }
}
