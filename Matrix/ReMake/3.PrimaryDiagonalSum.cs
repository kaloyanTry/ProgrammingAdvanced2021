using System;
using System.Linq;

namespace _3.PrimaryDiagonalSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int[,] matrix = new int[n, n];
            int sumDiagonal = 0;

            for (int row = 0; row < n; row++)
            {
                int[] data = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse).ToArray();

                for (int col = 0; col < n; col++)
                {
                    matrix[row, col] += data[col];

                    if (row == col)
                    {
                        sumDiagonal += matrix[row, col];
                    }
                }
            }

            Console.WriteLine(sumDiagonal);
        }
    }
}
