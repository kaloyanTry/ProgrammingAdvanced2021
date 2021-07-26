using System;

namespace _02.ProblemMatrix2
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            char[,] matrix = new char[n, n];

            int food = 0;
            int snakeRow = -1;
            int snakeCol = -1;

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

            string command = Console.ReadLine();
            while (true)
            {
                matrix[snakeRow, snakeCol] = '.';

                if (command == "right")
                {
                    snakeCol++;
                }
                else if (command == "left")
                {
                    snakeCol--;
                }
                else if (command == "down")
                {
                    snakeRow++;
                }
                else if (command == "up")
                {
                    snakeRow--;
                }

                bool isOutside = snakeRow < 0 || snakeRow >= matrix.GetLength(0) || snakeCol < 0 || snakeCol>= matrix.GetLength(1);
                if (isOutside)
                {
                    break;
                }

                if (matrix[snakeRow, snakeCol] == '*')
                {
                    food++;
                    if (food >= 10)
                    {
                        matrix[snakeRow, snakeCol] = 'S';
                        break;
                    }
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

                command = Console.ReadLine();
            }

            if (food >= 10)
            {
                Console.WriteLine("You won! You fed the snake.");
            }
            else
            {
                Console.WriteLine("Game over!");
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
    }
}