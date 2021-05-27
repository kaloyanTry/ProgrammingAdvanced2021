using System;
using System.Linq;
using System.Text;

namespace _02.SuperMario
{
    class Program
    {
        static void Main(string[] args)
        {
            int marioLives = int.Parse(Console.ReadLine());
            int n = int.Parse(Console.ReadLine());

            char[,] matrix = new char[n, n];
            int marioRow = -1;
            int marioCol = -1;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                string input = Console.ReadLine();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = input[col];

                    if (matrix[row, col] == 'M')
                    {
                        marioRow = row;
                        marioCol = col;
                    }
                }
            }

            matrix[marioRow, marioCol] = '-';

            while (true)
            {
                string[] inputCommand = Console.ReadLine().Split();
                char command = char.Parse(inputCommand[0]);
                int enemyRow = int.Parse(inputCommand[1]);
                int enemyCol = int.Parse(inputCommand[2]);

                matrix[enemyRow, enemyCol] = 'B';

                MarioMove(command, ref marioRow, ref marioCol, matrix, ref marioLives);

                if (matrix[marioRow, marioCol] == matrix[enemyRow, enemyCol])
                {
                    marioLives -= 2;

                    if (marioLives >= 0)
                    {
                        matrix[enemyRow, enemyCol] = '-';
                    }
                }

                if (marioLives < 0)
                {
                    Console.WriteLine($"Mario died at {marioRow};{marioCol}.");
                    matrix[marioRow, marioCol] = 'X';
                    PrintMatrix(matrix);
                    break;
                }

                if (matrix[marioRow, marioCol] == 'P')
                {
                    matrix[marioRow, marioCol] = '-';
                    Console.WriteLine($"Mario has successfully saved the princess! Lives left: {marioLives}");
                    PrintMatrix(matrix);
                    break;
                }
            }
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

        private static void MarioMove(char command, ref int marioRow, ref int marioCol, char[,] matrix, ref int marioLives)
        {
            if (command == 'W')
            {
                marioRow -= 1;

                if (marioRow < 0)
                {
                    marioRow = 0;
                }
            }
            else if (command == 'S')
            {
                marioRow += 1;

                if (marioRow >= matrix.GetLength(0))
                {
                    marioRow = matrix.GetLength(0) - 1;
                }
            }
            else if (command == 'A')
            {
                marioCol -= 1;

                if (marioCol < 0)
                {
                    marioCol = 0;
                }
            }
            else if (command == 'D')
            {
                marioCol += 1;

                if (marioCol >= matrix.GetLength(1))
                {
                    marioCol = matrix.GetLength(1) - 1;
                }
            }

            marioLives--;
        }
    }
}
