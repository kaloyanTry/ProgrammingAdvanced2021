﻿using System;
using System.Linq;

namespace _5.SquareMaxSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] size = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int mRow = size[0];
            int mCol = size[1];

            int[,] matrix = new int[mRow, mCol];
            int maxRow = -1;
            int maxCol = -1;
            int maxSum = int.MinValue;

            for (int row = 0; row < mRow; row++)
            {
                int[] data = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

                for (int col = 0; col < mCol; col++)
                {
                    matrix[row, col] = data[col];
                }
            }

            for (int row = 0; row < matrix.GetLength(0) - 1; row++)
            {
                for (int col = 0; col < matrix.GetLength(1) - 1; col++)
                {
                    int currentSum = matrix[row, col] + matrix[row, col + 1] + matrix[row + 1, col] + matrix[row + 1, col + 1];
                    if (currentSum > maxSum)
                    {
                        maxSum = currentSum;
                        maxRow = row;
                        maxCol = col;
                    }
                }
            }

            for (int row = maxRow; row <= maxRow + 1; row++)
            {
                for (int col = maxCol; col <= maxCol + 1; col++)
                {
                    Console.Write(matrix[row, col] + " ");
                }
                Console.WriteLine();
            }

            Console.WriteLine(maxSum);
        }
    }
}
