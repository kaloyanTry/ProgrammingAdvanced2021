using System;
using System.Collections.Generic;
using System.Linq;

namespace CarSalesman
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Engine> engines = new List<Engine>();
            List<Car> cars = new List<Car>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] inputData = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string model = inputData[0];
                string power = inputData[1];

                if (inputData.Length == 2)
                {
                    Engine engine = new Engine(model, power);
                    engines.Add(engine);
                }
                else if (inputData.Length == 3)
                {
                    if (Char.IsDigit(inputData[2][0]))
                    {
                        engines.Add(new Engine(model, power, inputData[2]));
                    }
                    else
                    {
                        engines.Add(new Engine(model, power, "n/a", inputData[2]));
                    }
                }

                if (inputData.Length == 4)
                {
                    engines.Add(new Engine(model, power, inputData[2], inputData[3]));
                }
            }

            int m = int.Parse(Console.ReadLine());
            for (int i = 0; i < m; i++)
            {
                string[] inputData = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string model = inputData[0];
                Engine engine = engines.FirstOrDefault(e => e.Model == inputData[1]);

                if (inputData.Length == 2)
                {
                    Car car = new Car(model, engine);
                    cars.Add(car);
                }
                else if (inputData.Length == 3)
                {
                    if (Char.IsDigit(inputData[2][0]))
                    {
                        cars.Add(new Car(model, engine, inputData[2]));
                    }
                    else
                    {
                        cars.Add(new Car(model, engine, "n/a", inputData[2]));
                    }
                }

                if (inputData.Length == 4)
                {
                    cars.Add(new Car(model, engine, inputData[2], inputData[3]));
                }
            }

            foreach (var car in cars)
            {
                Console.WriteLine(car);
            }
        }
    }
}
