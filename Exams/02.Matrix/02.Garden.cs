using System;
using System.Linq;

namespace _02.Problem
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] inputs = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int inputRow = inputs[0];
            int inputCol = inputs[1];

            int[,] garden = new int[inputRow, inputCol];

            for (int row = 0; row < garden.GetLength(0); row++)
            {
                for (int col = 0; col < garden.GetLength(1); col++)
                {
                    garden[row, col] = 0;
                }
            }

            string command = Console.ReadLine();
            while (command != "Bloom Bloom Plow")
            {
                string[] data = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                int dataRow = int.Parse(data[0]);
                int dataCol = int.Parse(data[1]);

                if (dataRow < 0 || dataRow >= garden.GetLength(0) || dataCol < 0 || dataCol >= garden.GetLength(1))
                {
                    Console.WriteLine("Invalid coordinates.");
                }

                for (int row = 0; row < garden.GetLength(0); row++)
                {
                    for (int col = 0; col < garden.GetLength(1); col++)
                    {
                        if (dataRow == row || dataCol == col)
                        {
                            garden[row, col]++;
                        }
                    }
                }
                
                command = Console.ReadLine();
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
