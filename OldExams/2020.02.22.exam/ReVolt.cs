using System;

namespace MatrixReVolt
{
    class MatrixRevolt
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int countCommands = int.Parse(Console.ReadLine());

            char[,] matrix = new char[n, n];
            int playerRow = -1;
            int playerCol = -1;

            for (int row = 0; row < n; row++)
            {
                string input = Console.ReadLine();
                for (int col = 0; col < n; col++)
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

                MoveMethod(ref playerRow, ref playerCol, command);

                for (int row = 0; row < matrix.GetLength(0); row++)
                {
                    for (int col = 0; col < matrix.GetLength(1); col++)
                    {
                        RevoltMethod(matrix, ref playerRow, ref playerCol);

                        if (matrix[playerRow, playerCol] == 'B')
                        {
                            MoveMethod(ref playerRow, ref playerCol, command);
                            RevoltMethod(matrix, ref playerRow, ref playerCol);
                        }
                        if (matrix[playerRow, playerCol] == 'T')
                        {
                            MoveBackMethod(ref playerRow, ref playerCol, command);
                            RevoltMethod(matrix, ref playerRow, ref playerCol);
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

        private static void RevoltMethod(char[,] matrix, ref int playerRow, ref int playerCol)
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
        private static void MoveMethod(ref int playerRow, ref int playerCol, string command)
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
        private static void MoveBackMethod(ref int playerRow, ref int playerCol, string command)
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
    }
}
