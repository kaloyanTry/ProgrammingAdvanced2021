using System;
using System.Linq;
using System.Collections.Generic;

namespace DiagonalDifference
{
    class DiagonalDifference
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[,] matrix = new int[n, n];

            for (int row = 0; row < n; row++)
            {
                int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();

                for (int col = 0; col < n; col++)
                {

                    matrix[row, col] += input[col];
                }
            }

            int firstDiagoanl = 0;
            int secondDiagoanl = 0;
            int sumDiagonals = 0;

            //second solution
            // for(row = rows.getLenght(1) - 1; row = 0; row--)

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (row == col)
                    {
                        firstDiagoanl += matrix[row, col];
                    }

                    //Thinnk Problem: relation col-row here: n = matrix.GetLength(1)

                    if (col == (n - row - 1))
                    {
                        secondDiagoanl += matrix[row, col];
                    }
                }
            }

            Console.WriteLine(Math.Abs(firstDiagoanl - secondDiagoanl));
        }
    }
}
