using System;
using System.Linq;
using System.Collections.Generic;

namespace CrossRoads
{
    class Crossroads
    {
        static void Main(string[] args)
        {
            int greenLightSeconds = int.Parse(Console.ReadLine());
            int freeWindowSeconds = int.Parse(Console.ReadLine());

            Queue<string> cars = new Queue<string>();
            string passingCar = string.Empty;
            int crashIndex = -1;
            int passedCars = 0;

            string command = Console.ReadLine();
            while (command != "END")
            {
                if (command == "green")
                {
                    int elapsedSeconds = 0;
                    while (elapsedSeconds < greenLightSeconds && cars.Any())
                    {
                        string car = cars.Peek();
                        if (elapsedSeconds + car.Length <= greenLightSeconds)
                        {
                            elapsedSeconds += car.Length;
                            cars.Dequeue();
                            passedCars++;
                        }
                        else
                        {
                            int remainingTime = car.Length + elapsedSeconds - greenLightSeconds;
                            if (remainingTime <= freeWindowSeconds)
                            {
                                cars.Dequeue();
                                passedCars++;
                                break;
                            }
                            else
                            {
                                passingCar = car;
                                crashIndex = car.Length - (remainingTime - freeWindowSeconds);
                                break;
                            }
                        }
                    }
                }
                else
                {
                    cars.Enqueue(command);
                }

                if (passingCar != string.Empty)
                {
                    Console.WriteLine("A crash happened!");
                    Console.WriteLine($"{passingCar} was hit at {passingCar[crashIndex]}.");
                    break;
                }

                command = Console.ReadLine();
            }

            if (passingCar == string.Empty)
            {
                Console.WriteLine("Everyone is safe.");
                Console.WriteLine($"{passedCars} total cars passed the crossroads.");
            }
        }
    }
}
