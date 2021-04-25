using System;
using System.Collections.Generic;

namespace Ex10.Crossroads
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<string> queueCars = new Queue<string>();

            int greenLightDuration = int.Parse(Console.ReadLine());
            int freeWindowDuration = int.Parse(Console.ReadLine());

            bool isCrashed = false;
            string crashedCarName = string.Empty;
            char crashedCarChar = '\0';
            int totalCars = 0;

            string input = Console.ReadLine();
            
            while (input != "END")
            {
                if (input != "green")
                {
                    queueCars.Enqueue(input);
                    input = Console.ReadLine();
                    continue;
                }

                int currentGreenLightDuration = greenLightDuration;
                
                while (currentGreenLightDuration > 0 && queueCars.Count > 0)
                {
                    string carName = queueCars.Dequeue();
                    int carNameLenght = carName.Length;

                    if (currentGreenLightDuration >= carNameLenght)
                    {
                        currentGreenLightDuration -= carNameLenght;
                        totalCars++;
                    }
                    else
                    {
                        currentGreenLightDuration += freeWindowDuration;

                        if (currentGreenLightDuration >= carNameLenght)
                        {
                            totalCars++;
                            break;
                        }
                        else
                        {
                            isCrashed = true;
                            crashedCarName = carName;
                            crashedCarChar = carName[currentGreenLightDuration];
                            break;
                        }
                    }
                }

                if (isCrashed)
                {
                    break;
                }

                input = Console.ReadLine();
            }

            if (isCrashed)
            {
                Console.WriteLine("A crash happened!");
                Console.WriteLine($"{crashedCarName} was hit at {crashedCarChar}.");
            }
            else
            {
                Console.WriteLine("Everyone is safe.");
                Console.WriteLine($"{totalCars} total cars passed the crossroads.");
            }
        }
    }
}
