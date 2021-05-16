using System;
using System.Collections.Generic;
using System.Linq;

namespace Exam01.FightForGondor
{
    class Program
    {
        static void Main(string[] args)
        {
            int wavesCount = int.Parse(Console.ReadLine());

            Queue<int> queuePlates = new Queue<int>(Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse));

            Stack<int> stackWarrior = new Stack<int>();

            for (int i = 0; i < wavesCount; i++)
            {
                stackWarrior = new Stack<int>(Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse));

                if ((i + 1) % 3 == 0)
                {
                    int newPlate = int.Parse(Console.ReadLine());
                    queuePlates.Enqueue(newPlate);
                }

                while (stackWarrior.Any() && queuePlates.Any())
                {
                    int currentWarrior = stackWarrior.Peek();
                    int currentPlate = queuePlates.Peek();

                    if (currentWarrior > currentPlate)
                    {
                        queuePlates.Dequeue();

                        int lowAmounthPlate = currentWarrior - currentPlate;

                        stackWarrior.Pop();
                        stackWarrior.Push(lowAmounthPlate);
                    }
                    else if (currentPlate > currentWarrior)
                    {
                        stackWarrior.Pop();

                        int lowAmounthWarrior = currentPlate - currentWarrior;

                        queuePlates.Dequeue();

                        var items = queuePlates.ToArray();
                        queuePlates.Clear();
                        queuePlates.Enqueue(lowAmounthWarrior);
                        
                        foreach (var item in items)
                        {
                            queuePlates.Enqueue(item);
                        }
                    }
                    else if (currentWarrior == currentPlate)
                    {
                        stackWarrior.Pop();
                        queuePlates.Dequeue();
                    }
                }

                if (queuePlates.Count == 0)
                {
                    break;
                }
            }

            if (queuePlates.Count == 0)
            {
                Console.WriteLine("The orcs successfully destroyed the Gondor's defense.");
                string leftOrcs = string.Join(", ", stackWarrior.ToArray());
                Console.WriteLine($"Orcs left: {leftOrcs}");
            }
            else
            {
                Console.WriteLine("The people successfully repulsed the orc's attack.");
                string leftPlates = string.Join(", ", queuePlates.ToArray());
                Console.WriteLine($"Plates left: {leftPlates}");
            }
        }
    }
}
