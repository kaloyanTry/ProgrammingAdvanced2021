using System;
using System.Linq;

namespace Ex5.SnakeMoves
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] size = Console.ReadLine().Split().Select(int.Parse).ToArray();
            string inputSnake = Console.ReadLine();

            int mRow = size[0];
            int mCol = size[1];
            char[,] matrix = new char[mRow, mCol];
            int currentChar = 0;

            for (int row = 0; row < mRow; row++)
            {
                if (row % 2 == 0)
                {
                    for (int col = 0; col < mCol; col++)
                    {
                        if (currentChar == inputSnake.Length)
                        {
                            currentChar = 0;
                        }
                        matrix[row, col] = inputSnake[currentChar];
                        currentChar++;
                    }
                }

                if (row % 2 != 0)
                {
                    for (int col = mCol - 1; col >= 0; col--)
                    {
                        if (currentChar == inputSnake.Length)
                        {
                            currentChar = 0;
                        }
                        matrix[row, col] = inputSnake[currentChar];
                        currentChar++;
                    }
                }

                //Print the matrix with chars:
                for (int col = 0; col < mCol; col++)
                {
                    Console.Write(string.Join("", matrix[row, col]));
                }
                Console.WriteLine();
            }         
        }
    }
}
