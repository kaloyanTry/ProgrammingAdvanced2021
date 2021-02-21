using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleExam
{
    class TheFight
    {
        static void Main(string[] args)
        {
            int nWaves = int.Parse(Console.ReadLine());
            int[] inputPlates = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Stack<int> plates = new Stack<int>(inputPlates.Length);
            for (int i = 0; i < inputPlates.Length; i++)
            {
                plates.Push(inputPlates[i]);
            }

            Queue<int> warrionrs = new Queue<int>();
            int countWaves = 0;
            int newPlatePush = 0;

            for (int i = 0; i < (nWaves + countWaves); i++)
            {
                string input = Console.ReadLine();
                countWaves++;

                int[] inputWarriors = input.Split().Select(int.Parse).ToArray();
                for (int w = 0; w < inputWarriors.Length; w++)
                {
                    warrionrs.Enqueue(inputWarriors[i]);
                }

                if (countWaves % 3 == 0)
                {
                    nWaves += 1;
                    newPlatePush = int.Parse(Console.ReadLine());
                    plates.Push(newPlatePush);
                }

                int currentWarrior = warrionrs.Peek();
                int currentPlate = plates.Peek();

                if (currentWarrior > currentPlate)
                {
                    currentWarrior -= currentPlate;
                    plates.Pop();
                    while (currentWarrior > 0)
                    {
                        currentWarrior -= currentPlate;
                        plates.Pop();
                    }
                }
                if (currentPlate > currentWarrior)
                {
                    currentPlate -= currentWarrior;
                    warrionrs.Dequeue();
                }
                if (currentWarrior == currentPlate)
                {
                    warrionrs.Dequeue();
                    plates.Pop();
                }

            }

            if (warrionrs.Count > 0 && plates.Count == 0)
            {
                Console.WriteLine("The orcs successfully destroyed the Gondor's defense.");
                Console.WriteLine(string.Join(", ", warrionrs));
            }
            else
            {
                Console.WriteLine("The people successfully repulsed the orc's attack.");
            Console.WriteLine(string.Join(", ", plates));
            }
        }         
    }
}
