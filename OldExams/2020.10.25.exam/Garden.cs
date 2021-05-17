using System;
using System.Linq;
using System.Collections.Generic;

namespace MatrixGarden
{
    class MatrixGarden
    {
        static void Main(string[] args)
        {
            int[] inputDimension = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int n = inputDimension[0];
            int m = inputDimension[1];

            int[,] matrix = new int[n, m];
            int flowerRow = 0;
            int flowerCol = 0;

            string input = Console.ReadLine();
            while (input != "Bloom Bloom Plow")
            {
                int[] inputPossition = input.Split().Select(int.Parse).ToArray();
                int currentRow = inputPossition[0];
                int currentCol = inputPossition[1];

                if (currentRow < 0 || currentRow >= matrix.GetLength(0) || currentCol < 0 || currentCol >= matrix.GetLength(1))
                {
                    Console.WriteLine("Invalid coordinates.");
                }

                flowerRow = currentRow;
                flowerCol = currentCol;

                for (int row = 0; row < matrix.GetLength(0); row++)
                {
                    for (int col = 0; col < matrix.GetLength(1); col++)
                    {
                        if (row == flowerRow || col == flowerCol)
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
