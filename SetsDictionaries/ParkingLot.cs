using System;
using System.Collections.Generic;
using System.Linq;

namespace ParkingLot
{
    class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> carNumbers = new HashSet<string>();
            string input = Console.ReadLine();

            while (input != "END")
            {
                string[] splitted = input.Split(", ", StringSplitOptions.RemoveEmptyEntries).ToArray();

                string command = splitted[0];
                string carNumber = splitted[1];

                if (command == "IN")
                {
                    if (!carNumbers.Contains(carNumber))
                    {
                        carNumbers.Add(carNumber);
                    }
                }

                if (command == "OUT")
                {
                    if (carNumbers.Contains(carNumber))
                    {
                        carNumbers.Remove(carNumber);
                    }
                }

                input = Console.ReadLine();
            }
            if (carNumbers.Count == 0)
            {
                Console.WriteLine("Parking Lot is Empty");
            }

            foreach (var car in carNumbers)
            {
                Console.WriteLine(car);
            }
        }
    }
}
