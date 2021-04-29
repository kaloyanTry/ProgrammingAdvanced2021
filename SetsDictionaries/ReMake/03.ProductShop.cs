using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.ProductShop
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, double>> shopsDict =
                new Dictionary<string, Dictionary<string, double>>();

            string input = Console.ReadLine();
            while (input != "Revision")
            {
                string[] data = input.Split(", ", StringSplitOptions.RemoveEmptyEntries);
                string shopName = data[0];
                string productName = data[1];
                double productPrice = double.Parse(data[2]);

                if (!shopsDict.ContainsKey(shopName))
                {
                    shopsDict.Add(shopName, new Dictionary<string, double>());
                }

                if (!shopsDict[shopName].ContainsKey(productName))
                {
                    shopsDict[shopName].Add(productName, productPrice);
                }

                input = Console.ReadLine();
            }

            //shopsDict = shopsDict.OrderBy(s => s.Key).ToDictionary(k => k.Key, v => v.Value);
            var shopsSorted = shopsDict.OrderBy(s => s.Key);

            foreach (var shop in shopsSorted)
            {
                Console.WriteLine($"{shop.Key}->");

                foreach (var product in shop.Value)
                {
                    Console.WriteLine($"Product: {product.Key}, Price: {product.Value}");
                }
            }
        }
    }
}
