using System;
using System.Collections.Generic;
using System.Linq;

namespace CarManufacturer
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            List<Tire[]> tires = new List<Tire[]>();

            string command = Console.ReadLine();
            while (command != "No more tires")
            {
                string[] dataCommand = command.Split();
                List<Tire> tireList = new List<Tire>();

                for (int i = 0; i < dataCommand.Length; i+=2)
                {
                    int year = int.Parse(dataCommand[i]);
                    double pressure = double.Parse(dataCommand[i + 1]);

                    Tire tire = new Tire(year, pressure);
                    tireList.Add(tire);
                }

                tires.Add(tireList.ToArray());

                command = Console.ReadLine();
            }

            List<Engine> engines = new List<Engine>();

            command = Console.ReadLine();
            while (command != "Engines done")
            {
                string[] dataCommand = command.Split();
                int horsePower = int.Parse(dataCommand[0]);
                double cubicCapacity = double.Parse(dataCommand[1]);

                Engine engine = new Engine(horsePower, cubicCapacity);
                engines.Add(engine);

                command = Console.ReadLine();
            }

            List<Car> cars = new List<Car>();

            command = Console.ReadLine();
            while (command != "Show special")
            {
                string[] dataCommand = command.Split();
                string make = dataCommand[0];
                string model = dataCommand[1];
                int year = int.Parse(dataCommand[2]);
                double fuelQuantity = double.Parse(dataCommand[3]);
                double fuelConsumption = double.Parse(dataCommand[4]);
                int engineIndex = int.Parse(dataCommand[5]);
                int tiresIndex = int.Parse(dataCommand[6]);

                Car car = new Car(make, model, year, fuelQuantity, fuelConsumption, engines[engineIndex], tires[tiresIndex]);
                cars.Add(car);

                command = Console.ReadLine();
            }

            Func<Car, bool> filter = c => c.Year >= 2017 && c.Engine.HorsePower > 330 && c.Tires.Sum(t => t.Pressure) >= 9 && c.Tires.Sum(t => t.Pressure) <= 10;

            List<Car> specialCars = new List<Car>();

            foreach (var car in cars.Where(filter))
            {
                car.Drive(20);
                specialCars.Add(car);
            }

            Console.WriteLine(string.Join("", specialCars));
        }
    }
}
