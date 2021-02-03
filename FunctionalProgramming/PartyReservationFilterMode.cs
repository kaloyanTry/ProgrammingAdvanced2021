using System;
using System.Collections.Generic;
using System.Linq;

namespace PartyReservationMode
{
    class PartyReservationFilterMode
    {
        static void Main(string[] args)
        {
            List<string> names = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList();

            List<string> filters = new List<string>();

            string input = Console.ReadLine();

            while (input != "Print")
            {
                string[] tokens = input.Split(";", StringSplitOptions.RemoveEmptyEntries);

                if (tokens[0] == "Add filter")
                {
                    filters.Add(tokens[1] + " " + tokens[2]);
                }
                else if (tokens[0] == "Remove filter")
                {
                    filters.Remove(tokens[1] + " " + tokens[2]);
                }

                input = Console.ReadLine();
            }

            foreach (var filter in filters)
            {
                string[] tokens = filter.Split().ToArray();

                if (tokens[0] == "Starts")
                {
                    names = names.Where(x => !x.StartsWith(tokens[2])).ToList();
                }
                else if (tokens[0] == "Ends")
                {
                    names = names.Where(x => !x.EndsWith(tokens[2])).ToList();
                }
                else if (tokens[0] == "Contains")
                {
                    names = names.Where(x => !x.Contains(tokens[1])).ToList();
                }
                else if (tokens[0] == "Length")
                {
                    names = names.Where(x => x.Length != int.Parse(tokens[1])).ToList();
                }
            }

            Console.WriteLine(string.Join(" ", names));
        }
    }
}
