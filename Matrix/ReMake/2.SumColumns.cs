using System;
using System.Linq;

namespace _2.SumColumns
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] mSize = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            int mRow = mSize[0];
            int mCol = mSize[1];
            int[,] matrix = new int[mRow, mCol];

            for (int row = 0; row < mRow; row++)
            {
                int[] mInput = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

                for (int col = 0; col < mCol; col++)
                {
                    matrix[row, col] = mInput[col];
                }
            }

            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                int rowSum = 0;

                for (int row = 0; row < matrix.GetLength(0); row++)
                {
                    rowSum += matrix[row, col];
                }

                Console.WriteLine(rowSum);
            }

            //for (int row = 0; row < matrix.GetLength(0); row++)
            //{
            //    int rowSum = 0;
            //    for (int col = 0; col < matrix.GetLength(1); col++)
            //    {
            //        rowSum += matrix[row, col];
            //    }
            //    Console.WriteLine(rowSum);
            //}//Sum of rows:
        }
    }
}
