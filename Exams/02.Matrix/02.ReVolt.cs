using System;

namespace _02.ReVolt
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int countCommands = int.Parse(Console.ReadLine());

            char[,] matrix = new char[n, n];
            int playerRow = -1;
            int playerCol = -1;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                string input = Console.ReadLine();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = input[col];

                    if (matrix[row, col] == 'f')
                    {
                        playerRow = row;
                        playerCol = col;
                    }
                }
            }

            for (int i = 0; i < countCommands; i++)
            {
                string command = Console.ReadLine();
                matrix[playerRow, playerCol] = '-';

                MovePlayer(ref playerRow, ref playerCol, command);

                for (int row = 0; row < matrix.GetLength(0); row++)
                {
                    for (int col = 0; col < matrix.GetLength(1); col++)
                    {
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
                            Console.WriteLine("Player won!");
                            matrix[playerRow, playerCol] = 'f';
                            PrintMatrix(matrix);
                            return;
                        }
                        
                        matrix[playerRow, playerCol] = 'f';
                    }
                }
            }

            Console.WriteLine("Player lost!");
            PrintMatrix(matrix);
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

        private static void ReVolt(char[,] matrix, ref int playerRow, ref int playerCol)
        {
            if (playerRow == matrix.GetLength(0))
            {
                playerRow = 0;
            }
            else if (playerRow < 0)
            {
                playerRow = matrix.GetLength(0) - 1;
            }
            else if (playerCol == matrix.GetLength(1))
            {
                playerCol = 0;
            }
            else if (playerCol < 0)
            {
                playerCol = matrix.GetLength(1) - 1;
            }
        }

        private static void MovePlayer(ref int playerRow, ref int playerCol, string command)
        {
            if (command == "up")
            {
                playerRow -= 1;
            }
            else if (command == "down")
            {
                playerRow += 1;
            }
            else if (command == "left")
            {
                playerCol -= 1;
            }
            else if (command == "right")
            {
                playerCol += 1;
            }
        }

        private static void MoveBackPlayer(ref int playerRow, ref int playerCol, string command)
        {
            if (command == "up")
            {
                playerRow += 1;
            }
            else if (command == "down")
            {
                playerRow -= 1;
            }
            else if (command == "left")
            {
                playerCol += 1;
            }
            else if (command == "right")
            {
                playerCol -= 1;
            }
        }
    }
}
