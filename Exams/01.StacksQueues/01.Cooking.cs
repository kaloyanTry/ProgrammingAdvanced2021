using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.Cooking
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<int> liquidsQueue = new Queue<int>(Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse));

            Stack<int> ingredientsStack = new Stack<int>(Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse));

            int bread = 0;
            int cake = 0;
            int pastry = 0;
            int fruitPie = 0;

            while (liquidsQueue.Any() && ingredientsStack.Any())
            {
                int liquid = liquidsQueue.Peek();
                int ingredient = ingredientsStack.Peek();
                bool isCook = false;

                if (liquid + ingredient == 25)
                {
                    bread += 1;
                    isCook = true;
                }
                else if (liquid + ingredient == 50)
                {
                    cake += 1;
                    isCook = true;
                }
                else if (liquid + ingredient == 75)
                {
                    pastry += 1;
                    isCook = true;
                }
                else if (liquid + ingredient == 100)
                {
                    fruitPie += 1;
                    isCook = true;
                }
                else
                {
                    liquidsQueue.Dequeue();

                    int ingredientsLeft = ingredient + 3;
                    ingredientsStack.Pop();
                    ingredientsStack.Push(ingredientsLeft);
                }

                if (isCook)
                {
                    liquidsQueue.Dequeue();
                    ingredientsStack.Pop();
                }
            }

            if (bread >= 1 && cake >= 1 && fruitPie >= 1 && pastry >= 1)
            {
                Console.WriteLine("Wohoo! You succeeded in cooking all the food!");
            }
            else
            {
                Console.WriteLine("Ugh, what a pity! You didn't have enough materials to cook everything.");
            }

            if (liquidsQueue.Count == 0)
            {
                Console.WriteLine($"Liquids left: none");
            }
            else
            {
                Console.WriteLine($"Liquids left: " + string.Join(", ", liquidsQueue));
            }

            if (ingredientsStack.Count == 0)
            {
                Console.WriteLine("Ingredients left: none");
            }
            else
            {
                Console.WriteLine($"Ingredients left: " + string.Join(", ", ingredientsStack));
            }

            Console.WriteLine($"Bread: {bread}");
            Console.WriteLine($"Cake: {cake}");
            Console.WriteLine($"Fruit Pie: {fruitPie}");
            Console.WriteLine($"Pastry: {pastry}");
        }
    }
}
