using System;
using System.Collections.Generic;
using System.Linq;

namespace _06.ParkingLot
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            HashSet<string> carsSet = new HashSet<string>();

            while (input != "END")
            {
                string[] data = input.Split(", ", StringSplitOptions.RemoveEmptyEntries);

                string cmd = data[0];
                string carNumber = data[1];

                if (cmd == "IN")
                {
                    carsSet.Add(carNumber);
                }

                if (cmd == "OUT")
                {
                    carsSet.Remove(carNumber);
                }


                input = Console.ReadLine();
            }

            if (carsSet.Any())
            {
                foreach (var car in carsSet)
                {
                    Console.WriteLine(car);
                }
            }
            else
            {
                Console.WriteLine("Parking Lot is Empty");
            }
        }
    }
}
