using System;
using System.Linq;

namespace ConsoleMatrix2
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            char[,] matrix = new char[n, n];
            bool isChar = false;
            int chRow = -1;
            int chCol = - 1;

            for (int row = 0; row < n; row++)
            {
                 string rowData = Console.ReadLine();

                for (int col = 0; col < n; col++)
                {
                    matrix[row, col] = rowData[col];
                }
            }
            char ch = char.Parse(Console.ReadLine());

            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < n; col++)
                {
                    if (matrix[row, col] == ch)
                    {
                        isChar = true;
                        chRow = row;
                        chCol = col;
                        break;
                    }
                }

                if (isChar)
                {
                    break;
                }
            }

            if (isChar)
            {
                Console.WriteLine($"({chRow}, {chCol})");
            }
            else
            {
                Console.WriteLine($"{ch} does not occur in the matrix");
            }

            //Print the matrix:
            //for (int row = 0; row < matrix.GetLength(0); row++)
            //{
            //    for (int col = 0; col < matrix.GetLength(1); col++)
            //    {
            //        Console.Write(matrix[row, col] + " ");
            //    }
            //    Console.WriteLine();
            //}
        }
    }
}
