using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace Ex8.Bombs
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[,] matrix = new int[n, n];
            Queue<Bomb> bombsQueue = new Queue<Bomb>();

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                int[] data = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse)
                    .ToArray();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = data[col];
                }
            }

            //Take the coordinates of the bombs:
            string[] bombsCoordinates = Console.ReadLine().Split().ToArray();

            for (int i = 0; i < bombsCoordinates.Length; i++)
            {
                int bombX = bombsCoordinates[i].Split(",").Select(int.Parse).ToArray()[0];
                int bombY = bombsCoordinates[i].Split(",").Select(int.Parse).ToArray()[1];

                Bomb bomb = new Bomb(bombX, bombY);
                bombsQueue.Enqueue(bomb);
            }

            while (bombsQueue.Any())
            {
                Bomb bomb = bombsQueue.Dequeue();
                if (matrix[bomb.X, bomb.Y] > 0)
                {
                    DamageCells(bomb, ref matrix);
                    matrix[bomb.X, bomb.Y] = 0;
                }
            }

            //Calculate aliveCells:
            int aliveCells = 0;
            int aliveCellsSum = 0;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] > 0)
                    {
                        aliveCells++;
                        aliveCellsSum += matrix[row, col];
                    }
                }
            }

            //Print the results and the matrix:
            Console.WriteLine("Alive cells: " + aliveCells);
            Console.WriteLine("Sum: " + aliveCellsSum);

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col] + " ");
                }

                Console.WriteLine();
            }
        }

        private static void DamageCells(Bomb bomb, ref int[,] matrix)
        {
            if (IsValidPos(bomb.X + 1, bomb.Y + 1, matrix) && matrix[bomb.X + 1, bomb.Y + 1] > 0)
            {
                matrix[bomb.X + 1, bomb.Y + 1] -= matrix[bomb.X, bomb.Y];
            }

            if (IsValidPos(bomb.X - 1, bomb.Y - 1, matrix) && matrix[bomb.X - 1, bomb.Y - 1] > 0)
            {
                matrix[bomb.X - 1, bomb.Y - 1] -= matrix[bomb.X, bomb.Y];
            }

            if (IsValidPos(bomb.X + 1, bomb.Y - 1, matrix) && matrix[bomb.X + 1, bomb.Y - 1] > 0)
            {
                matrix[bomb.X + 1, bomb.Y - 1] -= matrix[bomb.X, bomb.Y];
            }

            if (IsValidPos(bomb.X - 1, bomb.Y + 1, matrix) && matrix[bomb.X - 1, bomb.Y + 1] > 0)
            {
                matrix[bomb.X - 1, bomb.Y + 1] -= matrix[bomb.X, bomb.Y];
            }

            if (IsValidPos(bomb.X + 1, bomb.Y, matrix) && matrix[bomb.X + 1, bomb.Y] > 0)
            {
                matrix[bomb.X + 1, bomb.Y] -= matrix[bomb.X, bomb.Y];
            }

            if (IsValidPos(bomb.X - 1, bomb.Y, matrix) && matrix[bomb.X - 1, bomb.Y] > 0)
            {
                matrix[bomb.X - 1, bomb.Y] -= matrix[bomb.X, bomb.Y];
            }

            if (IsValidPos(bomb.X, bomb.Y + 1, matrix) && matrix[bomb.X, bomb.Y + 1] > 0)
            {
                matrix[bomb.X, bomb.Y + 1] -= matrix[bomb.X, bomb.Y];
            }

            if (IsValidPos(bomb.X, bomb.Y - 1, matrix) && matrix[bomb.X, bomb.Y - 1] > 0)
            {
                matrix[bomb.X, bomb.Y - 1] -= matrix[bomb.X, bomb.Y];
            }
        }

        private static bool IsValidPos(int row, int col, int[,] matrix)
        {
            if ((row >= 0 && row < matrix.GetLength(0)) && (col >= 0 && col < matrix.GetLength(1)))
            {
                return true;
            }

            return false;
        }
    }

    public class Bomb
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Bomb(int x, int y)
        {
            X = x;
            Y = y;
        }
    }
}
