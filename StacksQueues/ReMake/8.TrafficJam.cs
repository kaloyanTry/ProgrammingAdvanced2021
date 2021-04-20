using System;
using System.Collections.Generic;

namespace TrafficJam
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Queue<string> queueCars = new Queue<string>();

            int countCars = 0;

            string input = Console.ReadLine();
            while (input != "end")
            {
                if (input == "green")
                {
                    for (int i = 0; i < n; i++)
                    {
                        if (queueCars.Count > 0)
                        {
                            Console.WriteLine($"{queueCars.Dequeue()} passed!");
                            countCars++;
                        }
                    }
                }
                else
                {
                    queueCars.Enqueue(input);
                }

                input = Console.ReadLine();
            }

            Console.WriteLine($"{countCars} cars passed the crossroads.");
        }
    }
}
