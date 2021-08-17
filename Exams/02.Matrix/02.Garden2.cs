using System;
using System.Linq;

namespace _02.ProblemMatrix2
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] dimensions = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int dimensionRow = dimensions[0];
            int dimensionCol = dimensions[1];

            int[,] garden = new int[dimensionRow, dimensionCol];

            for (int row = 0; row < garden.GetLength(0); row++)
            {
                for (int col = 0; col < garden.GetLength(1); col++)
                {
                    garden[row, col] = 0;
                }
            }

            string input = Console.ReadLine();
            while (input != "Bloom Bloom Plow")
            {
                int[] dimensionsInput = input.Split().Select(int.Parse).ToArray();
                int inputRow = dimensionsInput[0];
                int inputCol = dimensionsInput[1];

                if (inputRow < 0 || inputRow >= garden.GetLength(0) || inputCol < 0 || inputCol >= garden.GetLength(1))
                {
                    Console.WriteLine("Invalid coordinates.");
                }

                for (int row = 0; row < garden.GetLength(0); row++)
                {
                    for (int col = 0; col < garden.GetLength(1); col++)
                    {
                        if (inputRow == row || inputCol == col)
                        {
                            garden[row, col]++;
                        }
                    }
                }

                input = Console.ReadLine();
            }

            for (int row = 0; row < garden.GetLength(0); row++)
            {
                for (int col = 0; col < garden.GetLength(1); col++)
                {
                    Console.Write(garden[row, col] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
