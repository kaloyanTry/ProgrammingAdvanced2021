using System;
using System.Linq;

namespace Ex4.MatrixShuffling
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] size = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int mRow = size[0];
            int mCol = size[1];

            string[,] matrix = new string[mRow, mCol];

            for (int row = 0; row < mRow; row++)
            {
                string[] data = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();

                for (int col = 0; col < mCol; col++)
                {
                    matrix[row, col] = data[col];
                }
            }

            string input = Console.ReadLine();
            while (input != "END")
            {
                string[] data = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                
                string command = data[0].ToLower();

                if (command == "swap" && data.Length == 5)
                {
                    int swapRow1 = int.Parse(data[1]);
                    int swapCol1 = int.Parse(data[2]);
                    int swapRow2 = int.Parse(data[3]);
                    int swapCol2 = int.Parse(data[4]);

                    bool isValid = (swapRow1 >= 0 && swapRow2 < matrix.GetLength(0)) && (swapCol1 >= 0 && swapCol2 < matrix.GetLength(1));
                    if (isValid)
                    {
                        string temp = matrix[swapRow1, swapCol1];
                        
                        matrix[swapRow1, swapCol1] = matrix[swapRow2, swapCol2];
                        matrix[swapRow2, swapCol2] = temp;

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

                input = Console.ReadLine();
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
