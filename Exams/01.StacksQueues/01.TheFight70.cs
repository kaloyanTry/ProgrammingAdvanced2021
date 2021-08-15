using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.Problem
{
    class TheFight
    {
        static void Main(string[] args)
        {
            int nWaves = int.Parse(Console.ReadLine());

            Queue<int> plates = new Queue<int>(Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));

            Stack<int> orcsWariors = new Stack<int>();

            for (int i = 1; i <= nWaves; i++)
            {
                orcsWariors = new Stack<int>(Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse));

                if (i % 3 == 0)
                {
                    int extraPlate = int.Parse(Console.ReadLine());

                    int[] arrayPlates = new int[plates.Count];
                    plates.CopyTo(arrayPlates, 0);
                    plates.Clear();
                    plates.Enqueue(extraPlate);
                    foreach (var arrPlate in arrayPlates)
                    {
                        plates.Enqueue(arrPlate);
                    }
                }

                while (plates.Any() && orcsWariors.Any())
                {
                    int plate = plates.Peek();
                    int warrior = orcsWariors.Peek();

                    if (warrior > plate)
                    {
                        int decreasedWarior = warrior - plate;
                        plates.Dequeue();
                        orcsWariors.Pop();
                        orcsWariors.Push(decreasedWarior);
                    }
                    else if (plate > warrior)
                    {
                        int decreasedPlate = plate - warrior;

                        plates.Dequeue();
                        orcsWariors.Pop();
                        plates.Enqueue(decreasedPlate);
                    }
                    else if (plate == warrior)
                    {
                        plates.Dequeue();
                        orcsWariors.Pop();
                    }
                }

                if (plates.Count == 0)
                {
                    break;
                }
            }

            if (plates.Count == 0 && orcsWariors.Any())
            {
                Console.WriteLine("The orcs successfully destroyed the Gondor's defense.");
                Console.WriteLine("Orcs left: " + string.Join(", ", orcsWariors));
            }
            else
            {
                Console.WriteLine("The people successfully repulsed the orc's attack.");
                Console.WriteLine("Plates left: " + string.Join(", ", plates));
            }
        }
    }
}
