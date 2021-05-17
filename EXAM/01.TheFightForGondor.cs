using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.TheFightForGondor
{
    class Program
    {
        static void Main(string[] args)
        {
            int nWaves = int.Parse(Console.ReadLine());

            Queue<int> platesQueue = new Queue<int>(Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse));

            Stack<int> orcsStack = new Stack<int>();

            for (int i = 1; i <= nWaves; i++)
            {
                orcsStack = new Stack<int>(Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse));

                if (i % 3 == 0)
                {
                    int extraPlate = int.Parse(Console.ReadLine());
                    platesQueue.Enqueue(extraPlate);
                }

                while (orcsStack.Any() && platesQueue.Any())
                {
                    int plate = platesQueue.Peek();
                    int orc = orcsStack.Peek();

                    if (orc > plate)
                    {
                        int orcLeftPower = orc - plate;
                        
                        platesQueue.Dequeue();
                        orcsStack.Pop();
                        orcsStack.Push(orcLeftPower);
                    }
                    else if (plate > orc)
                    {
                        int plateLeftPower = plate - orc;
                        
                        orcsStack.Pop();
                        platesQueue.Dequeue();

                        int[] platesArray = new int[platesQueue.Count];
                        
                        platesQueue.CopyTo(platesArray, 0);
                        platesQueue.Clear();
                        
                        platesQueue.Enqueue(plateLeftPower);
                        foreach (var plateLeft in platesArray)
                        {
                            platesQueue.Enqueue(plateLeft);
                        }
                    }
                    else if (plate == orc)
                    {
                        orcsStack.Pop();
                        platesQueue.Dequeue();
                    }
                }

                if (platesQueue.Count == 0)
                {
                    break;
                }
            }

            if (platesQueue.Count == 0)
            {
                Console.WriteLine("The orcs successfully destroyed the Gondor's defense.");
                Console.WriteLine("Orcs left: " + string.Join(", ", orcsStack));
            }
            else
            {
                Console.WriteLine("The people successfully repulsed the orc's attack.");
                Console.WriteLine("Plates left: " + string.Join(", ", platesQueue));
            }
        }
    }
}
