using System;
using System.Linq;
using System.Collections.Generic;

namespace ConsoleExams
{
    class FlowerWreathsSimple
    {
        static void Main(string[] args)
        {

            int[] firstInput = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int[] secondInput = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            Stack<int> lilies = new Stack<int>(firstInput.Length);
            Queue<int> roses = new Queue<int>(secondInput.Length);

            for (int i = 0; i < firstInput.Length; i++)
            {
                lilies.Push(firstInput[i]);
            }
            for (int i = 0; i < secondInput.Length; i++)
            {
                roses.Enqueue(secondInput[i]);
            }

            int flowerWreaths = 0;
            int flowersCount = 0;

            while (lilies.Count > 0 && roses.Count > 0)
            {

                if (lilies.Peek() + roses.Peek() < 15)
                {
                    flowersCount += (lilies.Peek() + roses.Peek());
                    lilies.Pop();
                    roses.Dequeue();
                }
                else if (lilies.Peek() + roses.Peek() == 15)
                {
                    flowerWreaths++;
                    lilies.Pop();
                    roses.Dequeue();
                }
                else
                {
                    int decreaseValue = lilies.Peek() - 2;
                    lilies.Pop();
                    lilies.Push(decreaseValue);
                }
            }

            flowerWreaths += flowersCount / 15;

            if (flowerWreaths >= 5)
            {
                Console.WriteLine($"You made it, you are going to the competition with {flowerWreaths} wreaths!");
            }
            else
            {
                Console.WriteLine($"You didn't make it, you need {5 - flowerWreaths} wreaths more!");
            }
        }
    }
}
