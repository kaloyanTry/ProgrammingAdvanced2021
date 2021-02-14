using System;

namespace Snake
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            char[,] matrix = new char[n, n];
            int snakeRow = -1;
            int snakeCol = -1;
            int firstBurrowRow = -1;
            int firstBurrowCol = -1;
            int secondBurrowRow = -1;
            int secondBurrowCol = -1;

            for (int row = 0; row < n; row++)
            {
                string input = Console.ReadLine();

                for (int col = 0; col < input.Length; col++)
                {
                    matrix[row, col] = input[col];

                    if (matrix[row, col] == 'S')
                    {
                        snakeRow = row;
                        snakeCol = col;
                    }

                    if (matrix[row, col] == 'B')
                    {
                        if (firstBurrowRow == -1)
                        {
                            firstBurrowRow = row;
                            firstBurrowCol = col;
                        }
                        else
                        {
                            secondBurrowRow = row;
                            secondBurrowCol = col;
                        }
                    }
                }
            }

            matrix[snakeRow, snakeCol] = '.';
            int foodCount = 0;

            while (true)
            {
                if (foodCount >= 10)
                {
                    Console.WriteLine($"You won! You fed the snake.");
                    matrix[snakeRow, snakeCol] = 'S';
                    break;
                }

                string command = Console.ReadLine();

                snakeRow = MoveRow(snakeRow, command);
                snakeCol = MoveCol(snakeCol, command);

                if (!IsValidPossition(matrix, snakeRow, snakeCol))
                {
                    Console.WriteLine("Game over!");
                    break;
                }

                if (matrix[snakeRow, snakeCol] == '*')
                {
                    foodCount++;
                }
                if (matrix[snakeRow, snakeCol] == 'B')
                {
                    matrix[snakeRow, snakeCol] = '.';

                    if (firstBurrowRow == snakeRow && firstBurrowCol == snakeCol)
                    {
                        snakeRow = secondBurrowRow;
                        snakeCol = secondBurrowCol;
                    }
                    else
                    {
                        snakeRow = firstBurrowRow;
                        snakeCol = firstBurrowCol;
                    }
                }
                matrix[snakeRow, snakeCol] = '.';
            }

            Console.WriteLine($"Food eaten: {foodCount}");

            Print(matrix);
        }

        public static int MoveRow(int row, string movement)
        {
            if(movement == "up")
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

        public static bool IsValidPossition(char[,] matrix, int row, int col)
        {
            if (row < 0 || row >= matrix.GetLength(0))
            {
                return false;
            }
            if (col < 0 || col >= matrix.GetLength(1))
            {
                return false;
            }

            return true;
        }

        public static void Print(char[,] matrix)
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