using System;
using System.Collections.Generic;
using System.Linq;

namespace RawData
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            List<Car> cars = new List<Car>();
            int n = int.Parse(Console.ReadLine());
            
            for (int i = 0; i < n; i++)
            {
                string[] inputData = Console.ReadLine().Split();

                string model = inputData[0];
                int engineSpeed = int.Parse(inputData[1]);
                int enginePower = int.Parse(inputData[2]);
                int cargoWeight = int.Parse(inputData[3]);
                string cargoType = inputData[4];
                string[] tiresData = new string[8]
                {
                    inputData[5], inputData[6],
                    inputData[7], inputData[8],
                    inputData[9], inputData[10],
                    inputData[11], inputData[12],
                };

                Car car = new Car(model, engineSpeed, enginePower, cargoWeight, cargoType, tiresData);
                cars.Add(car);
            }

            string command = Console.ReadLine();

            if (command == "fragile")
            {
                Console.WriteLine(String.Join(Environment.NewLine, cars.Where(c => c.Cargo.Type == "fragile" && c.Tires.Any(t => t.TirePressure < 1))));
            }
            else if (command == "flamable")
            {
                Console.WriteLine(String.Join(Environment.NewLine, cars.Where(c => c.Cargo.Type == "flamable" && c.Engine.Power > 250)));
            }
        }
    }
}
