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
                string[] input = Console.ReadLine().Split(new string[] { ",", " -> " }, StringSplitOptions.RemoveEmptyEntries);
                string color = input[0];

                if (!wardrobe.ContainsKey(color))
                {
                    wardrobe.Add(color, new Dictionary<string, int>());
                }

                for (int j = 1; j < input.Length; j++)
                {
                    if (!wardrobe[color].ContainsKey(input[j]))
                    {
                        wardrobe[color][input[j]] = 0;
                    }
                    wardrobe[color][input[j]]++;
                }
            }

            string[] criteria = Console.ReadLine().Split();
            string colorCriteria = criteria[0];
            string clothCriteria = criteria[1];

            foreach (var color in wardrobe)
            {
                Console.WriteLine($"{color.Key} clothes: ");

                foreach (var cloth in color.Value)
                {
                    if (color.Key == colorCriteria && cloth.Key == clothCriteria)
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
