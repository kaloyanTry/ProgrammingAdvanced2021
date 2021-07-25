using System;

namespace SpiralMatrixLab
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[,] matrix = new int[n, n];

            string direction = "right";
            int row = 0;
            int col = 0;

            for (int i = 0; i < n * n; i++)
            {
                matrix[row, col] = i + 1;

                if (direction == "right")
                {
                    col++;
                }
                else if (direction == "left")
                {
                    col--;
                }
                else if (direction == "up")
                {
                    row--;
                }
                else if (direction == "down")
                {
                    row++;
                }

                if ((col == n || isSpaceOccupied(matrix, row, col, n)) && direction == "right")
                {
                    col--;
                    row++;
                    direction = "down";
                }
                else if ((row == n || isSpaceOccupied(matrix, row, col, n)) && direction == "down")
                {
                    row--;
                    col--;
                    direction = "left";
                }
                else if ((col == -1 || isSpaceOccupied(matrix, row, col, n)) && direction == "left")
                {
                    col++;
                    row--;
                    direction = "up";
                }
                else if ((row == -1 || isSpaceOccupied(matrix, row, col, n)) && direction == "up")
                {
                    row++;
                    col++;
                    direction = "right";
                }
            }

            for (int rowPrint = 0; rowPrint < n; rowPrint++)
            {
                for (int colPrint = 0; colPrint < n; colPrint++)
                {
                    if (matrix[row, col] < 10)
                    {
                        Console.Write(" " + matrix[rowPrint, colPrint] + " ");
                    }
                    else
                    {
                        Console.Write(matrix[rowPrint, colPrint] + " ");
                    }
                }
                Console.WriteLine();
            }
        }

        static bool isSpaceOccupied(int[,] matrix, int row, int col, int n)
        {
            return row >= 0 && row < n && col >= 0 && col < n && matrix[row, col] != 0;
        }
    }
}
