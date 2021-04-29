using System;
using System.Collections.Generic;
using System.Threading.Channels;

namespace _04.CitiesByContinent
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse((Console.ReadLine()));
            Dictionary<string, Dictionary<string, List<string>>> citiesDict =
                new Dictionary<string, Dictionary<string, List<string>>>();

            for (int i = 0; i < n; i++)
            {
                string[] data = Console.ReadLine().Split();
                string continentName = data[0];
                string countryName = data[1];
                string cityName = data[2];

                if (!citiesDict.ContainsKey(continentName))
                {
                    citiesDict.Add(continentName, new Dictionary<string, List<string>>());
                }

                if (!citiesDict[continentName].ContainsKey(countryName))
                {
                    citiesDict[continentName].Add(countryName, new List<string>());
                }

                citiesDict[continentName][countryName].Add(cityName);
            }

            foreach (var continent in citiesDict)
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
