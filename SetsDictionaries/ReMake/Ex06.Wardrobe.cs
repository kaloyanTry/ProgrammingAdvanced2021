using System;
using System.Collections.Generic;
using System.Runtime.Serialization.Json;

namespace Ex06.Wardrobe
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Dictionary<string, Dictionary<string, int>>
                wardrobeDict = new Dictionary<string, Dictionary<string, int>>();

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split(" -> ", StringSplitOptions.RemoveEmptyEntries);
                string color = input[0];
                string[] clothes = input[1].Split(',', StringSplitOptions.RemoveEmptyEntries);

                if (!wardrobeDict.ContainsKey(color))
                {
                    wardrobeDict.Add(color, new Dictionary<string, int>());
                }

                foreach (var clothe in clothes)
                {
                    if (!wardrobeDict[color].ContainsKey(clothe))
                    {
                        wardrobeDict[color].Add(clothe, 1);
                    }
                    else
                    {
                        wardrobeDict[color][clothe]++;
                    }
                }
            }

            string[] lookingForClothe = Console.ReadLine().Split();
            string lookingColor = lookingForClothe[0];
            string lookingClothe = lookingForClothe[1];

            foreach (var color in wardrobeDict)
            {
                Console.WriteLine($"{color.Key} clothes:");

                foreach (var clothe in color.Value)
                {
                    if (color.Key == lookingColor && clothe.Key == lookingClothe)
                    {
                        Console.WriteLine($"* {clothe.Key} - {clothe.Value} (found!)");
                    }
                    else
                    {
                        Console.WriteLine($"* {clothe.Key} - {clothe.Value}");
                    }
                }
            }
        }
    }
}
