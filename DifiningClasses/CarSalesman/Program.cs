using System;
using System.Collections.Generic;
using System.Linq;

namespace CarSalesmanExercise
{
    public class Program
    {
        public static void Main(string[] args)
        {
            List<Engine> engines = new List<Engine>();
            List<Car> cars = new List<Car>();

            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] engineData = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string model = engineData[0];
                string power = engineData[1];

                if (engineData.Length == 2)
                {
                    engines.Add(new Engine(model, power));
                }
                else if (engineData.Length == 3)
                {
                    if (Char.IsDigit(engineData[2][0]))
                    {
                        engines.Add(new Engine(model, power, engineData[2]));
                    }
                    else
                    {
                        engines.Add(new Engine(model, power, "n/a", engineData[2]));
                    }
                }
                else if (engineData.Length == 4)
                {
                    engines.Add(new Engine(model, power, engineData[2], engineData[3]));
                }
            }

            int m = int.Parse(Console.ReadLine());
            for (int i = 0; i < m; i++)
            {
                string[] carData = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string model = carData[0];
                Engine engine = engines.FirstOrDefault(e => e.Model == carData[1]);

                if (carData.Length == 2)
                {
                    cars.Add(new Car(model, engine));
                }
                else if (carData.Length == 3)
                {
                    if (Char.IsDigit(carData[2][0]))
                    {
                        cars.Add(new Car(model, engine, carData[2]));
                    }
                    else
                    {
                        cars.Add(new Car(model, engine, "n/a", carData[2]));
                    }
                }
                else if (carData.Length == 4)
                {
                    cars.Add(new Car(model, engine, carData[2], carData[3]));
                }
            }

            foreach (var car in cars)
            {
                Console.WriteLine(car);
            }
        }
    }
}
