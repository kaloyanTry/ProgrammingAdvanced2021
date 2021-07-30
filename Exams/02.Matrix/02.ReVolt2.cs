using System;

namespace _02.ReVolt2
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int countOfCommands = int.Parse(Console.ReadLine());

            char[,] matrix = new char[n, n];
            int playerRow = -1;
            int playerCol = -1;
            bool isWinning = false;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                string inputData = Console.ReadLine();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = inputData[col];

                    if (matrix[row, col] == 'f')
                    {
                        playerRow = row;
                        playerCol = col;
                    }
                }
            }

            for (int i = 0; i < countOfCommands; i++)
            {
                string command = Console.ReadLine();
                matrix[playerRow, playerCol] = '-';

                MovePlayer(ref playerRow, ref playerCol, command);

                ReVolt(matrix, ref playerRow, ref playerCol);

                if (matrix[playerRow, playerCol] == 'B')
                {
                    MovePlayer(ref playerRow, ref playerCol, command);
                    ReVolt(matrix, ref playerRow, ref playerCol);
                }

                if (matrix[playerRow, playerCol] == 'T')
                {
                    MoveBackPlayer(ref playerRow, ref playerCol, command);
                    ReVolt(matrix, ref playerRow, ref playerCol);
                }

                if (matrix[playerRow, playerCol] == 'F')
                {
                    isWinning = true;
                    matrix[playerRow, playerCol] = 'f';
                    break;
                }

                matrix[playerRow, playerCol] = 'f';
            }

            if (isWinning)
            {
                Console.WriteLine("Player won!");
            }
            else
            {
                Console.WriteLine("Player lost!");
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

        private static void ReVolt(char[,] matrix, ref int playerRow, ref int playerCol)
        {
            if (playerRow == -1)
            {
                playerRow = matrix.GetLength(0) - 1;
            }
            else if (playerRow == matrix.GetLength(0))
            {
                playerRow = 0;
            }
            else if (playerCol == -1)
            {
                playerCol = matrix.GetLength(1) - 1;
            }
            else if (playerCol == matrix.GetLength(1))
            {
                playerCol = 0;
            }
        }

        private static void MovePlayer(ref int playerRow, ref int playerCol, string command)
        {
            if (command == "up")
            {
                playerRow--;
            }
            else if (command == "down")
            {
                playerRow++;
            }
            else if (command == "left")
            {
                playerCol--;
            }
            else if (command == "right")
            {
                playerCol++;
            }
        }

        private static void MoveBackPlayer(ref int playerRow, ref int playerCol, string command)
        {
            if (command == "up")
            {
                playerRow++;
            }
            else if (command == "down")
            {
                playerRow--;
            }
            else if (command == "left")
            {
                playerCol++;
            }
            else if (command == "right")
            {
                playerCol--;
            }
        }
    }
}
