using System;
using System.Linq;
using System.Collections.Generic;

namespace Wardrobe
{
    class Wardrobe
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Dictionary<string, Dictionary<string, int>> wardrobe = new Dictionary<string, Dictionary<string, int>>();

            for (int i = 0; i < n; i++)
            {
                string[] splitted = Console.ReadLine().Split(new string[] { ",", " -> " }, StringSplitOptions.RemoveEmptyEntries).ToArray();

                string color = splitted[0];
                if (!wardrobe.ContainsKey(color))
                {
                    wardrobe[color] = new Dictionary<string, int>();
                }

                for (int j = 1; j < splitted.Length; j++)
                {
                    if (!wardrobe[color].ContainsKey(splitted[j]))
                    {
                        wardrobe[color][splitted[j]] = 0;
                    }

                    wardrobe[color][splitted[j]]++;
                }
            }

            string[] searchData = Console.ReadLine().Split().ToArray();

            foreach (var pair in wardrobe)
            {
                Console.WriteLine($"{pair.Key} clothes: ");

                foreach (var cloth in pair.Value)
                {
                    if (pair.Key == searchData[0] && cloth.Key == searchData[1])
                    {
                        Console.WriteLine($"* {cloth.Key} - {cloth.Value} (found!)");
                    }
                    else
                    {
                        Console.WriteLine($"* {cloth.Key} - {cloth.Value}");
                    }
                }
            }
        }
    }
}
