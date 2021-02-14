using System;
using System.Collections.Generic;
using System.Linq;

namespace Cooking
{
    class Cooking
    {
        static void Main(string[] args)
        {
            Queue<int> liquids = new Queue<int>();
            Stack<int> ingredients = new Stack<int>();

            int[] inputLiquid = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            int[] inputIngredient = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            for (int l = 0; l < inputLiquid.Length; l++)
            {
                liquids.Enqueue(inputLiquid[l]);
            }

            for (int i = 0; i < inputIngredient.Length; i++)
            {
                ingredients.Push(inputIngredient[i]);
            }

            int breadValue = 25;
            int cakeValue = 50;
            int pastryValue = 75;
            int fruitPieValue = 100;

            int breadCount = 0;
            int cakeCount = 0;
            int pastryCount = 0;
            int fruitPieCount = 0;        

            int sum = 0;

            while (liquids.Count > 0 && ingredients.Count > 0)
            {
                int currentLiquid = liquids.Peek();
                int currentIngradient = ingredients.Peek();
                bool isCooking = false;

                sum = currentLiquid + currentIngradient;

                if (sum == breadValue)
                {
                    breadCount++;
                    isCooking = true;
                }
                else if (sum == cakeValue)
                {
                    cakeCount++;
                    isCooking = true;
                }
                else if (sum == pastryValue)
                {
                    pastryCount++;
                    isCooking = true;
                }
                else if (sum == fruitPieValue)
                {
                    fruitPieCount++;
                    isCooking = true;
                }

                if (isCooking)
                {
                    ingredients.Pop();
                    liquids.Dequeue();
                }
                else
                {
                    liquids.Dequeue();
                    currentIngradient += 3;
                    ingredients.Pop();
                    ingredients.Push(currentIngradient);
                }
            }

            if (breadCount >= 1 && cakeCount >= 1 && pastryCount >= 1 && fruitPieCount >= 1)
            {
                Console.WriteLine("Wohoo! You succeeded in cooking all the food!");
            }
            else
            {
                Console.WriteLine("Ugh, what a pity! You didn't have enough materials to cook everything.");
            }

            if (liquids.Count == 0)
            {
                Console.WriteLine("Liquids left: none");
            }
            else
            {
                Console.Write("Liquids left: ");
                Console.WriteLine(string.Join(", ", liquids));
            }

            if (ingredients.Count == 0)
            {
                Console.WriteLine("Ingredients left: none");
            }
            else
            {
                Console.Write("Ingredients left: ");
                Console.WriteLine(string.Join(", ", ingredients));
            }

            Console.WriteLine($"Bread: {breadCount}");
            Console.WriteLine($"Cake: {cakeCount}");
            Console.WriteLine($"Fruit Pie: {fruitPieCount}");
            Console.WriteLine($"Pastry: {pastryCount}");
        }
    }
}
