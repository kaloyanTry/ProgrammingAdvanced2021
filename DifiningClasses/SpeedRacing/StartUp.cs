using System;
using System.Collections.Generic;
using System.Linq;

namespace _6.SpeedRacing
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<Car> cars = new List<Car>();

            for (int i = 0; i < n; i++)
            {
                string[] infoCars = Console.ReadLine().Split();

                string infoModel = infoCars[0];
                double infoFuelAmount = double.Parse(infoCars[1]);
                double infoFuelConsumption = double.Parse(infoCars[2]);

                Car car = new Car(infoModel, infoFuelAmount, infoFuelConsumption);

                cars.Add(car);
            }

            string input = Console.ReadLine();
            while (input != "End")
            {
                string[] inputDrive = input.Split();

                string command = inputDrive[0];
                string inputModel = inputDrive[1];
                double inputAmountKm = double.Parse(inputDrive[2]);

                if (command == "Drive")
                {
                    Car drivedCar = cars.FirstOrDefault(c => c.Model == inputModel);
                    drivedCar.DriveCar(inputModel, inputAmountKm);
                }

                input = Console.ReadLine();
            }

            foreach (var car in cars)
            {
                Console.WriteLine(car.ToString());
            }
        }
    }
}
