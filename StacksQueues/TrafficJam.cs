using System;
using System.Collections.Generic;

namespace TrafficJam
{
    class TrafficJam
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            string command = Console.ReadLine();

            Queue<string> cars = new Queue<string>();
            int countCars = 0;

            while (command != "end")
            {

                if (command == "green")
                {
                    for (int i = 0; i < n; i++)
                    {
                        if (cars.Count > 0)
                        {
                            Console.WriteLine(cars.Dequeue() + " passed!");
                            countCars++;
                        }
                    }
                }
                else
                {
                    cars.Enqueue(command);
                }
                command = Console.ReadLine();
            }
            Console.WriteLine($"{countCars} cars passed the crossroads.");
        }
    }
}
