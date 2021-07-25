using System;
using System.Linq;

namespace ConsoleMatrix2
{
    class MaxSumSquare2
    {
        static void Main(string[] args)
        {
            int maxSum = int.MinValue;
            int maxRow = -1;
            int maxCol = -1;

            int[] inputDemensions = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int matrixRows = inputDemensions[0];
            int matrixCols = inputDemensions[1];
            int[,] matrix = new int[matrixRows, matrixCols];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                 int[] rowData = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = rowData[col];
                }
            }

            for (int row = 0; row < matrix.GetLength(0) - 1; row++)
            {
                for (int col = 0; col < matrix.GetLength(1) - 1; col++)
                {
                    int currSum = matrix[row, col] + matrix[row, col + 1] + matrix[row + 1, col] + matrix[row + 1, col + 1];

                    if (currSum > maxSum)
                    {
                        maxSum = currSum;
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
