using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftUniParking
{
    public class Parking
    {
        private List<Car> cars;
        private int capacity;

        public Parking(int capacity)
        {
            cars = new List<Car>();
            this.capacity = capacity;
        }

        public int Count => cars.Count;

        public string AddCar(Car car)
        {
            if (cars.Any(c => c.RegistrationNumber == car.RegistrationNumber))
            {
                return "Car with that registration number, already exists!";
            }
            else if (cars.Count >= capacity)
            {
                return "Parking is full!";
            } else
            {
                cars.Add(car);
                return $"Successfully added new car {car.Make} {car.RegistrationNumber}";
            }
        }

        public string RemoveCar(string RegistrationNumber)
        {
            Car car = cars.FirstOrDefault(c => c.RegistrationNumber == RegistrationNumber);

            if (cars.Contains(car))
            {
                cars.Remove(car);
                return $"Successfully removed {RegistrationNumber}";
            }
            else
            {
                return "Car with that registration number, doesn't exist!";
            }
        }

        public Car GetCar(string RegistrationNumber)
        {
            Car car = cars.FirstOrDefault(c => c.RegistrationNumber == RegistrationNumber);

            return car;
        }

        public void RemoveSetOfRegistrationNumber(List<string> RegistrationNumbers)
        {
            foreach (var regNum in RegistrationNumbers)
            {
                cars.RemoveAll(c => c.RegistrationNumber == regNum);
            }
        }
    }
}
