using System;
using System.Linq;

namespace ConsoleMatrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] mSize = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int mRows = mSize[0];
            int mCols = mSize[1];
            int[,] matrix = new int[mRows, mCols];

            int sumElements = 0;

            for (int row = 0; row < mRows; row++)
            {
                int[] rowData = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

                for (int col = 0; col < mCols; col++)
                {
                    matrix[row, col] = rowData[col];

                    sumElements += matrix[row, col];
                }
            }

            Console.WriteLine(matrix.GetLength(0));
            Console.WriteLine(matrix.GetLength(1));
            Console.WriteLine(sumElements);
        }
    }
}
