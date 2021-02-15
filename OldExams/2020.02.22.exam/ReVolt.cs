using System;

namespace Revolt
{
    class ReVolt
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int c = int.Parse(Console.ReadLine());

            char[,] matrix = new char[n, n];

            int playerRow = -1;
            int playerCol = -1;            

            for (int row = 0; row < n; row++)
            {
                string inputRow = Console.ReadLine();
                for (int col = 0; col < n; col++)
                {
                    matrix[row, col] = inputRow[col];

                    if (matrix[row, col] == 'f')
                    {
                        playerRow = row;
                        playerCol = col;
                    }
                }
            }


            for (int i = 0; i < c; i++)
            {
                string command = Console.ReadLine();
                matrix[playerRow, playerCol] = '-';

                playerRow = MoveRow(playerRow, command);
                playerCol = MoveCol(playerCol, command);
                for (int row = 0; row < matrix.GetLength(0); row++)
                {
                    for (int col = 0; col < matrix.GetLength(1); col++)
                    {

                        if (playerRow == matrix.GetLength(0))
                        {
                            playerRow = 0;
                        }
                        if (playerRow < 0)
                        {
                            playerRow = matrix.GetLength(0) - 1;
                        }
                        if (playerCol == matrix.GetLength(1) - 1)
                        {
                            playerCol = 0;
                        }
                        if (playerCol < 0)
                        {
                            playerCol = matrix.GetLength(1) - 1;
                        }

                        if (matrix[playerRow, playerCol] == 'B')
                        {
                            playerRow = MoveRow(playerRow, command);
                            playerCol = MoveCol(playerCol, command);
                            matrix[playerRow, playerCol] = 'f';
                        }

                        if (matrix[playerRow, playerCol] == 'T')
                        {
                            playerRow = MoveBackRow(playerRow, command);
                            playerCol = MoveBackCol(playerCol, command);
                            matrix[playerRow, playerCol] = 'f';
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
        public static int MoveRow(int row, string movement)
        {
            if (movement == "up")
            {
                return row - 1;
            }
            if (movement == "down")
            {
                return row + 1;
            }

            return row;
        }

        public static int MoveCol(int col, string movement)
        {
            if (movement == "left")
            {
                return col - 1;
            }
            if (movement == "right")
            {
                return col + 1;
            }

            return col;
        }
        public static int MoveBackRow(int row, string movement)
        {
            if (movement == "up")
            {
                return row + 1;
            }
            if (movement == "down")
            {
                return row - 1;
            }

            return row;
        }

        public static int MoveBackCol(int col, string movement)
        {
            if (movement == "left")
            {
                return col + 1;
            }
            if (movement == "right")
            {
                return col - 1;
            }

            return col;
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
