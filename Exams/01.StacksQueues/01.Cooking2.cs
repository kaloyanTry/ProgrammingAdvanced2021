﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.Problem
{
    class Cooking
    {
        static void Main(string[] args)
        {
            int bread = 0;
            int cake = 0;
            int pastry = 0;
            int fruitPie = 0;

            Queue<int> liquids = new Queue<int>(Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));
            Stack<int> ingredients = new Stack<int>(Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));

            while (liquids.Any() && ingredients.Any())
            {
                int liquid = liquids.Peek();
                int ingredient = ingredients.Peek();

                if (liquid + ingredient == 25)
                {
                    bread++;
                    liquids.Dequeue();
                    ingredients.Pop();
                }
                else if (liquid + ingredient == 50)
                {
                    cake++;
                    liquids.Dequeue();
                    ingredients.Pop();
                }
                else if (liquid + ingredient == 75)
                {
                    pastry++;
                    liquids.Dequeue();
                    ingredients.Pop();
                }else if (liquid + ingredient == 100)
                {
                    fruitPie++;
                    liquids.Dequeue();
                    ingredients.Pop();
                }
                else
                {
                    int increasedIngradient = ingredient + 3;
                    liquids.Dequeue();
                    ingredients.Pop();
                    ingredients.Push(increasedIngradient);
                }
            }

            if (bread >= 1 && cake >= 1 && pastry >= 1 && fruitPie >= 1)
            {
                Console.WriteLine("Wohoo! You succeeded in cooking all the food!");
            }
            else
            {
                Console.WriteLine("Ugh, what a pity! You didn't have enough materials to cook everything.");
            }

            if (liquids.Any())
            {
                Console.WriteLine("Liquids left: " + string.Join(", ", liquids));
            }
            else
            {
                Console.WriteLine("Liquids left: none");
            }

            if (ingredients.Any())
            {
                Console.WriteLine("Ingredients left: " + string.Join(", ", ingredients));
            }
            else
            {
                Console.WriteLine("Ingredients left: none");
            }

            Console.WriteLine($"Bread: {bread}");
            Console.WriteLine($"Cake: {cake}");
            Console.WriteLine($"Fruit Pie: {fruitPie}");
            Console.WriteLine($"Pastry: {pastry}");
        }
    }
}
