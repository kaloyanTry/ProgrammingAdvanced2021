using System;
using System.Linq;

namespace Ex01.DiagonalDifference
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int[,] matrix = new int[n, n];

            int firstSum = 0;
            int secondSum = 0;

            for (int row = 0; row < n; row++)
            {
                int[] data = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

                for (int col = 0; col < n; col++)
                {
                    matrix[row, col] = data[col];
                }
            }

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (row == col)
                    {
                        firstSum += matrix[row, col];                    
                    }

                    if (col == n - row - 1)
                    {
                        secondSum += matrix[row, col];
                    }
                }
            }

            Console.WriteLine(Math.Abs(firstSum - secondSum));
        }
    }
}
