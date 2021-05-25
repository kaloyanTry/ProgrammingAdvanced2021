using System;

namespace _02.Snake
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            char[,] matrix = new char[n, n];
            int snakeRow = -1;
            int snakeCol = -1;
            int food = 0;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                string input = Console.ReadLine();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = input[col];

                    if (matrix[row, col] == 'S')
                    {
                        snakeRow = row;
                        snakeCol = col;
                    }
                }
            }

            matrix[snakeRow, snakeCol] = '.';

            string command = Console.ReadLine();
            while (true)
            {
                MoveSnake(ref snakeRow, ref snakeCol, command);

                bool isOutside = snakeRow < 0 || snakeRow >= matrix.GetLength(0) || snakeCol < 0 || snakeCol >= matrix.GetLength(1);

                if (isOutside)
                {
                    Console.WriteLine("Game over!");
                    break;
                }

                if (matrix[snakeRow, snakeCol] == '*')
                {
                    food++;
                }

                if (matrix[snakeRow, snakeCol] == 'B')
                {
                    for (int row = 0; row < matrix.GetLength(0); row++)
                    {
                        for (int col = 0; col < matrix.GetLength(1); col++)
                        {
                            if (matrix[row, col] == 'B')
                            {
                                snakeRow = row;
                                snakeCol = col;

                                matrix[snakeRow, snakeCol] = '.';
                            }
                        }
                    }
                }

                if (food >= 10)
                {
                    matrix[snakeRow, snakeCol] = 'S';
                    Console.WriteLine("You won! You fed the snake.");
                    break;
                }

                matrix[snakeRow, snakeCol] = '.';
                command = Console.ReadLine();
            }

            Console.WriteLine($"Food eaten: {food}");

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col]);
                }

                Console.WriteLine();
            }
        }

        private static void MoveSnake(ref int snakeRow, ref int snakeCol, string command)
        {
            if (command == "up")
            {
                snakeRow -= 1;
            }
            else if (command == "down")
            {
                snakeRow += 1;
            }
            else if (command == "left")
            {
                snakeCol -= 1;
            }
            else if (command == "right")
            {
                snakeCol += 1;
            }
        }
    }
}
