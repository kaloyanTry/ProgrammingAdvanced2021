using System;
using System.Collections.Generic;
using System.Linq;

namespace Continents
{
    class Continents
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, List<string>>> continents = new Dictionary<string, Dictionary< string, List<string>>>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] splitted = Console.ReadLine().Split();
                string continent = splitted[0];
                string country = splitted[1];
                string city = splitted[2];

                if (!continents.ContainsKey(continent))
                {
                    continents.Add(continent, new Dictionary<string, List<string>>());
                }

                if (!continents[continent].ContainsKey(country))
                {
                    continents[continent].Add(country, new List<string>());
                }

                continents[continent][country].Add(city);
            }

            foreach (var continent in continents)
            {
                Console.WriteLine($"{continent.Key}:");

                foreach (var country in continent.Value)
                {
                    Console.Write($"    {country.Key} -> ");

                    for (int i = 0; i < country.Value.Count; i++)
                    {
                        if (i != 0)
                        {
                            Console.Write(", ");
                        }

                        Console.Write($"{country.Value[i]}");
                    }

                    Console.WriteLine();
                }
            }
        }
    }
}
