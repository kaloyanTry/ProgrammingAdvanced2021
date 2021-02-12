using System;
using System.Collections.Generic;
using System.Linq;

namespace FlowerWreaths
{
    class FlowerWreaths
    {
        static void Main(string[] args)
        {
            int[] inputLilies = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int[] inputRoses = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            Queue<int> rosesQueue = new Queue<int>(inputRoses.Length);
            Stack<int> liliesStack = new Stack<int>(inputRoses.Length);

            for (int i = 0; i < inputRoses.Length; i++)
            {
                liliesStack.Push(inputLilies[i]);
            }

            for (int i = 0; i < inputRoses.Length; i++)
            {
                rosesQueue.Enqueue(inputRoses[i]);
            }

            int wreaths = 0;
            int flowers = 0;

            while (rosesQueue.Count > 0 && liliesStack.Count > 0)
            {

                int lili = liliesStack.Pop();
                int rose = rosesQueue.Dequeue();

                while (true)
                {
                    int sum = lili + rose;

                    if (sum == 15)
                    {
                        wreaths++;
                        break;
                    }
                    else if (sum < 15)
                    {
                        flowers += sum;
                        break;
                    }
                    else
                    {
                        lili -= 2;
                    }
                }
            }

            wreaths += flowers / 15;

            if (wreaths >= 5)
            {
                Console.WriteLine($"You made it, you are going to the competition with {wreaths} wreaths!");
            }
            else
            {
                Console.WriteLine($"You didn't make it, you need {5 - wreaths} wreaths more!");
            }
        }
    }
}
