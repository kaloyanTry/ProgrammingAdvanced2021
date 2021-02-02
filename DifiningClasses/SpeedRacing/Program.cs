using System;
using System.Collections.Generic;
using System.Linq;

namespace SpeedRacing
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<Car> cars = new List<Car>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] carsData = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string model = carsData[0];
                double fuelAmont = double.Parse(carsData[1]);
                double fuelConsumptionPerKilometer = double.Parse(carsData[2]);

                Car car = new Car(model, fuelAmont, fuelConsumptionPerKilometer);

                cars.Add(car);
            }

            string input = Console.ReadLine();
            while (input != "End")
            {
                string[] commands = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                if (commands[0] == "Drive")
                {
                    string model = commands[1];
                    double amountOfKm = double.Parse(commands[2]);

                    Car carForDriving = cars.Where(c => c.Model == model).ToList().First();

                    carForDriving.Drive(model, amountOfKm);
                }

                input = Console.ReadLine();
            }

            foreach (Car car in cars)
            {
                Console.WriteLine($"{car.Model} {car.FuelAmount:f2} {car.TravelledDistance}");
            }
        }
    }
}
