using System;
using System.Linq;
using System.Collections.Generic;

namespace SnakeName
{
    class SnakeName2
    {
        static void Main(string[] args)
        {
                        int[] rc = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int rows = rc[0];
            int cols = rc[1];

            char[,] matrix = new char[rows, cols];

            string inputName = Console.ReadLine();
            int currentLetter = 0;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                if (row % 2 == 0)
                {
                    for (int col = 0; col < matrix.GetLength(1); col++)
                    {
                        matrix[row, col] = inputName[currentLetter];
                        currentLetter++;

                        if (currentLetter == inputName.Length)
                        {
                            currentLetter = 0;
                        }
                    }
                }
                else
                {
                    for (int col = matrix.GetLength(1) - 1; col >= 0; col--)
                    {
                        matrix[row, col] = inputName[currentLetter];
                        currentLetter++;

                        if (currentLetter == inputName.Length)
                        {
                            currentLetter = 0;
                        }
                    }
                }
            }

            PrintMatrix(matrix);
        }

        private static void PrintMatrix(char[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col]);
                }
                Console.WriteLine();
            }
        }
    }
}
