using System;
using System.Linq;

namespace _02.Garden
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] dimensions = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();
            
            int rowSize = dimensions[0];
            int colSize = dimensions[1];

            int[,] matrix = new int[rowSize, colSize];
            
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = 0;
                }
            }

            string input = Console.ReadLine();
            while (input != "Bloom Bloom Plow")
            {
                int[] inputLines = input
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse).ToArray();
                int positionRow = inputLines[0];
                int positionCol = inputLines[1];

                if (positionRow < 0 || positionRow >= matrix.GetLength(0) || positionCol < 0 || positionCol >= matrix.GetLength(1))
                {
                    Console.WriteLine("Invalid coordinates.");
                }

                for (int row = 0; row < matrix.GetLength(0); row++)
                {
                    for (int col = 0; col < matrix.GetLength(1); col++)
                    {
                        if (row == positionRow || col == positionCol)
                        {
                            matrix[row, col] += 1;
                        }
                    }
                }
                
                input = Console.ReadLine();
            }

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col] + " ");
                }

                Console.WriteLine();
            }
        }
    }
}
