using System;
using System.Linq;
using System.Collections.Generic;

namespace MatrixShuffling
{
    class Shuffling
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int rows = input[0];
            int cols = input[1];
            
            string[,] matrix = new string[rows, cols];

            fillMatrix(matrix);

            string command = Console.ReadLine();
            while (command != "END")
            {
                string[] arguments = command.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
                if (arguments[0] == "swap" && arguments.Length == 5)
                {
                    int row1 = int.Parse(arguments[1]);
                    int col1 = int.Parse(arguments[2]);
                    int row2 = int.Parse(arguments[3]);
                    int col2 = int.Parse(arguments[4]);

                    if (IsValidCommand(row1, col1, matrix) && IsValidCommand(row2, col2, matrix))
                    {
                        string temp = matrix[row1, col1];
                        matrix[row1, col1] = matrix[row2, col2];
                        matrix[row2, col2] = temp;

                        PrintMatrix(matrix);
                    }
                    else
                    {
                        Console.WriteLine("Invalid input!");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input!");
                }

                command = Console.ReadLine();
            }
        }

        private static void fillMatrix(string[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                string[] values = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = values[col];
                }
            }
        }
        private static void PrintMatrix(string[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col] + " ");
                }

                Console.WriteLine();
            }
        }
        private static bool IsValidCommand(int row, int col, string[,] matrix)
        {
            if ((row >= 0 && row < matrix.GetLength(0)) && (col >= 0 && col < matrix.GetLength(1)))
            {
                return true;
            }

            return false;
        }
    }
}