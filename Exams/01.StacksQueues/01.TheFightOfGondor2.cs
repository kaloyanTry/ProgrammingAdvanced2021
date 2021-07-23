using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.Problem
{
    class TheFightOfGondor
    {
        static void Main(string[] args)
        {
            int numOfWaves = int.Parse(Console.ReadLine());
            Queue<int> defencePlates = new Queue<int>(Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));
            Stack<int> wariorsOrcs = new Stack<int>();

            for (int i = 1; i <= numOfWaves; i++)
            {
                wariorsOrcs = new Stack<int>(Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));

                if (i % 3 == 0)
                {
                    int extraPlate = int.Parse(Console.ReadLine());
                    defencePlates.Enqueue(extraPlate);
                }

                while (defencePlates.Any() && wariorsOrcs.Any())
                {
                    int warior = wariorsOrcs.Peek();
                    int plate = defencePlates.Peek();
                    
                    if (warior > plate)
                    {
                        int leftWarior = warior - plate;
                        defencePlates.Dequeue();
                        wariorsOrcs.Pop();
                        wariorsOrcs.Push(leftWarior);

                        if (warior == 0)
                        {
                            break;
                        }
                    }
                    else if (plate > warior)
                    {
                        int leftPlate = plate - warior;
                        wariorsOrcs.Pop();
                        defencePlates.Dequeue();
                        
                        int[] arrayPlates = new int[defencePlates.Count];
                        defencePlates.CopyTo(arrayPlates, 0);
                        defencePlates.Clear();
                        defencePlates.Enqueue(leftPlate);
                        foreach (var plateArray in arrayPlates)
                        {
                            defencePlates.Enqueue(plateArray);
                        }
                    }
                    else if (plate == warior)
                    {
                        wariorsOrcs.Pop();
                        defencePlates.Dequeue();
                    }
                }

                if (defencePlates.Count == 0)
                {
                    break;
                }
            }

            if (wariorsOrcs.Any())
            {
                Console.WriteLine("The orcs successfully destroyed the Gondor's defense.");
                Console.WriteLine("Orcs left: " + string.Join(", ", wariorsOrcs));
            }
            else
            {
                Console.WriteLine("The people successfully repulsed the orc's attack.");
                Console.WriteLine("Plates left: " + string.Join(", ", defencePlates));
            }      
        }
    }
}
