using System;
using System.Linq;


namespace SquareSum
{
    class SquareSum
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int rows = input[0];
            int cols = input[1];

            int[,] matrix = new int[rows, cols];

            FillMatrix(rows, cols, matrix);

            int maxSum = int.MinValue;
            int maxRow = -1;
            int maxCol = -1;

            CalculateSquare(rows, cols, matrix, ref maxSum, ref maxRow, ref maxCol);

            PrintMatrix(matrix, maxRow, maxCol);

            Console.WriteLine(maxSum);
        }

        private static void CalculateSquare(int rows, int cols, int[,] matrix, ref int maxSum, ref int maxRow, ref int maxCol)
        {
            for (int row = 0; row < rows - 1; row++)
            {
                for (int col = 0; col < cols - 1; col++)
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
        }

        private static void PrintMatrix(int[,] matrix, int maxRow, int maxCol)
        {
            for (int row = maxRow; row <= maxRow + 1; row++)
            {
                for (int col = maxCol; col <= maxCol + 1; col++)
                {
                    Console.Write(matrix[row, col] + " ");
                }
                Console.WriteLine();
            }
        }

        private static void FillMatrix(int rows, int cols, int[,] matrix)
        {
            for (int row = 0; row < rows; row++)
            {
                int[] rowData = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = rowData[col];
                }
            }
        }
    }
}
