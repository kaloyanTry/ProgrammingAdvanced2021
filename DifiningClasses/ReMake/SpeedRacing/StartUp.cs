using System;
using System.Collections.Generic;
using System.Linq;

namespace SpeedRacing
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Car> cars = new List<Car>();

            for (int i = 0; i < n; i++)
            {
                string[] inputData = Console.ReadLine().Split();
                string model = inputData[0];
                double fuelAmount = double.Parse(inputData[1]);
                double fuelConsumptionPerKilometer = double.Parse(inputData[2]);

                Car car = new Car(model, fuelAmount, fuelConsumptionPerKilometer);
                cars.Add(car);
            }

            string input = Console.ReadLine();
            while (input != "End")
            {
                string[] inputData = input.Split();
                string command = inputData[0];
                if (command == "Drive")
                {
                    string carModel = inputData[1];
                    double amountOfKilometers = double.Parse(inputData[2]);

                    Car drivingCar = cars.Where(c => c.Model == carModel).ToList().First();

                    drivingCar.DriveCar(carModel, amountOfKilometers);

                }
                

                input = Console.ReadLine();
            }

            foreach (var car in cars)
            {
                Console.WriteLine(car);
            }
        }
    }
}
