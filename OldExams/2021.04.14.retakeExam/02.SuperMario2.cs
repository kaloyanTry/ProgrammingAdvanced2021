using System;
using System.Linq;

namespace _02.ProblemMatrix2
{
    class Program
    {
        static void Main(string[] args)
        {
            int marioLives = int.Parse(Console.ReadLine());
            int nRows = int.Parse(Console.ReadLine());

            char[,] matrix = new char[nRows, nRows];
            int marioRow = -1;
            int marioCol = -1;
            int princesRow = -1;
            int princesCol = -1;

            for (int row = 0; row < nRows; row++)
            {
                string inputData = Console.ReadLine();
                int nCol = inputData.Length;
                for (int col = 0; col < nCol; col++)
                {
                    matrix[row, col] = inputData[col];

                    if (matrix[row, col] == 'M')
                    {
                        marioRow = row;
                        marioCol = col;
                    }

                    if (matrix[row, col] == 'P')
                    {
                        princesRow = row;
                        princesCol = col;
                    }
                }
            }

            while (true)
            {
                string[] inputCommands = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

                matrix[marioRow, marioCol] = '-';

                char command = char.Parse(inputCommands[0]);
                int spawnRow = int.Parse(inputCommands[1]);
                int spawnCol = int.Parse(inputCommands[2]);
                matrix[spawnRow, spawnCol] = 'B';

                if (command == 'W')
                {
                    marioRow--;
                    if (marioRow == -1)
                    {
                        marioRow = 0;
                    }
                }
                else if (command == 'S')
                {
                    marioRow++;
                    if (marioRow == matrix.GetLength(0))
                    {
                        marioRow = matrix.GetLength(0) - 1;
                    }
                }
                else if (command == 'A')
                {
                    marioCol--;
                    if (marioCol == -1)
                    {
                        marioCol = 0;
                    }
                }
                else if (command == 'D')
                {
                    marioCol++;
                    if (marioCol == matrix.GetLength(1))
                    {
                        marioCol = matrix.GetLength(1) - 1;
                    }
                }

                marioLives--;

                if (matrix[spawnRow, spawnCol] == matrix[marioRow, marioCol])
                {
                    marioLives -= 2;
                }

                if (marioLives <= 0)
                {
                    if (matrix[marioRow, marioCol] == matrix[princesRow, princesCol])
                    {
                        matrix[marioRow, marioCol] = '-';
                        Console.WriteLine($"Mario has successfully saved the princess! Lives left: {marioLives}");
                        break;
                    }
                    else
                    {
                        matrix[marioRow, marioCol] = 'X';
                        Console.WriteLine($"Mario died at {marioRow};{marioCol}.");
                        break;
                    }
                }

                if (matrix[marioRow, marioCol] == matrix[princesRow, princesCol])
                {
                    matrix[marioRow, marioCol] = '-';
                    Console.WriteLine($"Mario has successfully saved the princess! Lives left: {marioLives}");
                    break;
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