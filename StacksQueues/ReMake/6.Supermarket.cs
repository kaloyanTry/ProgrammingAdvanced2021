using System;
using System.Collections.Generic;

namespace _6.Supermarket
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Queue<string> queueNames = new Queue<string>();


            while (input != "End")
            {       
                if (input == "Paid")
                {
                    while (queueNames.Count > 0)
                    {
                        Console.WriteLine(queueNames.Dequeue());
                    }
                }
                else
                {
                    queueNames.Enqueue(input);
                }

                input = Console.ReadLine();
            }

            Console.WriteLine($"{queueNames.Count} people remaining.");
        }
    }
}
