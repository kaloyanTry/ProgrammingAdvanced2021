using System;
using System.Linq;
using System.Collections.Generic;

namespace SnakeMoves
{
    class SnakeMoves
    {
        static void Main(string[] args)
        {
            int[] sizes = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int rows = sizes[0];
            int cols = sizes[1];

            char[,] matrix = new char[rows, cols];
            string snakeName = Console.ReadLine();

            int counter = 0;
            Queue<char> snakeQueue = new Queue<char>();
            int capacity = rows * cols;

            for (int i = 0; i < snakeName.Length; i++)
            {
                snakeQueue.Enqueue(snakeName[i]);
                counter++;

                if (counter == capacity)
                {
                    break;
                }
                if (i == snakeName.Length - 1)
                {
                    i = -1;
                }
            }

            for (int row = 0; row < rows; row++)
            {
                if (row % 2 == 0)
                {
                    for (int col = 0; col < cols; col++)
                    {
                        matrix[row, col] = snakeQueue.Dequeue();
                    }
                }
                else if (row % 2 != 0)
                {
                    for (int col = cols - 1; col > -1; col--)
                    {
                        matrix[row, col] = snakeQueue.Dequeue();
                    }
                }
            }


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