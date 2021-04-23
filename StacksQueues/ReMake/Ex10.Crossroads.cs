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

            string input = Console.ReadLine();

            bool isHitted = false;
            string hittedCarName = string.Empty;
            char hittedChar = '\0';  //--Default char value:'\0';
            int totalCars = 0;

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
                    int carLength = carName.Length;

                    if (currentGreenLightDuration - carLength >= 0)
                    {
                        currentGreenLightDuration -= carLength;
                        totalCars++;
                    }
                    else
                    {
                        currentGreenLightDuration += freeWindowDuration;

                        if (currentGreenLightDuration - carLength >= 0)
                        {
                            totalCars++;
                            break;
                        }
                        else
                        {
                            isHitted = true;
                            hittedCarName = carName;
                            hittedChar = carName[currentGreenLightDuration];
                            break;
                        }
                    }
                }

                if (isHitted)
                {
                    break;
                }

                input = Console.ReadLine();
            }

            if (isHitted)
            {
                Console.WriteLine("A crash happened!");
                Console.WriteLine($"{hittedCarName} was hit at {hittedChar}.");
            }
            else
            {
                Console.WriteLine("Everyone is safe.");
                Console.WriteLine($"{totalCars} total cars passed the crossroads.");
            }
        }
    }
}
