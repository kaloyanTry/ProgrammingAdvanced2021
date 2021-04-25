using System;
using System.Linq;

namespace Ex2.SquaresInMatrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] size = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int mRow = size[0];
            int mCol = size[1];

            char[,] matrix = new char[mRow, mCol];
            int countEquals = 0;

            for (int row = 0; row < mRow; row++)
            {
                char[] data = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(char.Parse).ToArray();

                for (int col = 0; col < mCol; col++)
                {
                    matrix[row, col] = data[col];
                }
            }

            for (int row = 0; row < matrix.GetLength(0) - 1; row++)
            {
                for (int col = 0; col < matrix.GetLength(1) - 1; col++)
                {
                    bool isEqual = matrix[row, col] == matrix[row, col + 1] && matrix[row + 1, col] == matrix[row + 1, col + 1] && matrix[row, col] == matrix[row + 1, col];
                    if (isEqual)
                    {
                        countEquals++;
                    }
                }
            }
            Console.WriteLine(countEquals);
        }
    }
}
