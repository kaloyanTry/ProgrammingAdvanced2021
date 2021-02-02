using System;
using System.Collections.Generic;
using System.Linq;

namespace CarSalesman
{
    public class Program
    {
        public static void Main(string[] args)
        {
            List<Engine> engines = new List<Engine>();
            List<Car> cars = new List<Car>();

            int enginesCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < enginesCount; i++)
            {
                string[] engineInfo = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();

                string model = engineInfo[0];
                string power = engineInfo[1];

                if (engineInfo.Length == 2)
                {
                    engines.Add(new Engine(model, power));
                }
                else if (engineInfo.Length == 3)
                {
                    if (Char.IsDigit(engineInfo[2][0]))
                    {
                        engines.Add(new Engine(model, power, engineInfo[2]));
                    }
                    else
                    {
                        engines.Add(new Engine(model, power, "n/a", engineInfo[2]));
                    }
                }
                else if (engineInfo.Length == 4)
                {
                    engines.Add(new Engine(model, power, engineInfo[2], engineInfo[3]));
                }
            }

            int carsCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < carsCount; i++)
            {
                string[] carInfo = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();

                string model = carInfo[0];
                Engine engine = engines.FirstOrDefault(x => x.Model == carInfo[1]);

                if (carInfo.Length == 2)
                {
                    cars.Add(new Car(model, engine));
                }
                else if (carInfo.Length == 3)
                {
                    if (Char.IsDigit(carInfo[2][0]))
                    {
                        cars.Add(new Car(model, engine, carInfo[2]));
                    }
                    else
                    {
                        cars.Add(new Car(model, engine, "n/a", carInfo[2]));
                    }
                }
                else if (carInfo.Length == 4)
                {
                    cars.Add(new Car(model, engine, carInfo[2], carInfo[3]));
                }
            }

            foreach (var car in cars)
            {
                Console.WriteLine(car);
            }
        }
    }
}
