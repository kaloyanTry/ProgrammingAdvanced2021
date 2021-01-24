using System;
using System.Collections.Generic;

namespace TrafficJam
{
    class TrafficJam
    {
        static void Main(string[] args)
        {
            int greenLightPassingCars = int.Parse(Console.ReadLine());

            Queue<string> cars = new Queue<string>();
            
            int carsCount = 0;
            string input = Console.ReadLine();

            while (input != "end")
            {
                if (input == "green")
                {
                    for (int i = 0; i < greenLightPassingCars; i++)
                    {
                        if (cars.Any())
                        {
                            carsCount++;
                            string passingCar = cars.Dequeue();
                            
                            Console.WriteLine($"{passingCar} passed!");
                        }
                    }
                }
                else
                {
                    cars.Enqueue(input);
                }

                input = Console.ReadLine();
            }

            Console.WriteLine($"{carsCount} cars passed the crossroads.");
        }
    }
}
