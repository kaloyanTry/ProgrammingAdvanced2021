using System;
using System.Linq;
using System.Collections.Generic;

namespace MatrixShuffling
{
    class Shuffling
    {
        static void Main(string[] args)
        {
            int[] rc = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int rows = rc[0];
            int cols = rc[1];

            string[,] matrix = new string[rows, cols];

            CreateMatrix(matrix);

            while (true)
            {
                string[] commands = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string command = commands[0];

                if (command == "END")
                {
                    break;
                }

                if (command == "swap" && commands.Length == 5)
                {
                    int row1 = int.Parse(commands[1]);
                    int row2 = int.Parse(commands[3]);
                    int col1 = int.Parse(commands[2]);
                    int col2 = int.Parse(commands[4]);

                    bool IsValid = (row1 >= 0 && row2 < matrix.GetLength(0)) && (col1 >= 0 && col2 < matrix.GetLength(1));

                    if(IsValid)
                    {
                        string temp1 = matrix[row1, col1];
                        matrix[row1, col1] = matrix[row2, col2];
                        matrix[row2, col2] = temp1;

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

            }

        }

        private static void CreateMatrix(string[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                string[] data = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();
                
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = data[col];
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
    }
}
