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
            List<Engine> engines = new List<Engine>();
            List<Car> cars = new List<Car>();
            List<Car> carsSpecial = new List<Car>();

            string input = Console.ReadLine();
            while (input != "No more tires")
            {
                List<Tire> tireList = new List<Tire>();
                string[] dataInput = input.Split();
                for (int i = 0; i < dataInput.Length; i+=2)
                {
                    int year = int.Parse(dataInput[i]);
                    double pressure = double.Parse(dataInput[i + 1]);

                    Tire tire = new Tire(year, pressure);
                    tireList.Add(tire);
                }

                tires.Add(tireList.ToArray());

                input = Console.ReadLine();
            }

            input = Console.ReadLine();
            while (input != "Engines done")
            {
                string[] dataInput = input.Split();

                int horsePower = int.Parse(dataInput[0]);
                double cubicCapacity = double.Parse(dataInput[1]);

                Engine engine = new Engine(horsePower, cubicCapacity);
                engines.Add(engine);

                input = Console.ReadLine();
            }

            input = Console.ReadLine();
            while (input != "Show special")
            {
                string[] dataInput = input.Split();
                string make = dataInput[0];
                string model = dataInput[1];
                int year = int.Parse(dataInput[2]);
                double fuelQuantity = double.Parse(dataInput[3]);
                double fuelConsumption = double.Parse(dataInput[4]);
                int engineIndex = int.Parse(dataInput[5]);
                int tiresIndex = int.Parse(dataInput[6]);

                Car car = new Car(make, model, year, fuelQuantity, fuelConsumption, engines[engineIndex], tires[tiresIndex]);
                cars.Add(car);

                input = Console.ReadLine();
            }

            Func<Car, bool> filterCars = c => c.Year >= 2017 && c.Engine.HorsePower >= 330 && c.Tires.Sum(t => t.Pressure) >= 9 && c.Tires.Sum(t => t.Pressure) <= 10;

            foreach (var car in cars.Where(filterCars))
            {
                car.Drive(20);
                carsSpecial.Add(car);
            }

            Console.WriteLine(string.Join("", carsSpecial));
        }
    }
}