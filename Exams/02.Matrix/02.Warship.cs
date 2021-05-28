using System;
using System.Linq;

namespace _2._Warships
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int matrixSize = int.Parse(Console.ReadLine());

            string[] coordinates = Console.ReadLine()
                .Split(',', StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            int firstPlayerShipsCount = 0;
            int secondPlayerShipsCount = 0;
            int totalShipsDestroyed = 0;

            char[,] matrix = CreateMatrix(matrixSize, ref firstPlayerShipsCount, ref secondPlayerShipsCount);

            for (int i = 0; i < coordinates.Length; i++)
            {
                int[] coordinatesArgs = coordinates[i]
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                int row = coordinatesArgs[0];
                int col = coordinatesArgs[1];

                if (IsInTheMatrix(matrix, row, col))
                {
                    if (matrix[row, col] == '<')
                    {
                        firstPlayerShipsCount--;
                        totalShipsDestroyed++;
                        matrix[row, col] = 'X';
                    }
                    else if (matrix[row, col] == '>')
                    {
                        secondPlayerShipsCount--;
                        totalShipsDestroyed++;
                        matrix[row, col] = 'X';
                    }
                    else if (matrix[row, col] == '#')
                    {
                        matrix[row, col] = 'X';
                        if (IsInTheMatrix(matrix, row - 1, col))
                        {
                            if (matrix[row - 1, col] == '<')
                            {
                                firstPlayerShipsCount--;
                                totalShipsDestroyed++;
                            }
                            else if (matrix[row - 1, col] == '>')
                            {
                                secondPlayerShipsCount--;
                                totalShipsDestroyed++;
                            }

                            matrix[row - 1, col] = 'X';
                        }

                        if (IsInTheMatrix(matrix, row + 1, col))
                        {
                            if (matrix[row + 1, col] == '<')
                            {
                                firstPlayerShipsCount--;
                                totalShipsDestroyed++;
                            }
                            else if (matrix[row + 1, col] == '>')
                            {
                                secondPlayerShipsCount--;
                                totalShipsDestroyed++;
                            }

                            matrix[row + 1, col] = 'X';
                        }

                        if (IsInTheMatrix(matrix, row, col - 1))
                        {
                            if (matrix[row, col - 1] == '<')
                            {
                                firstPlayerShipsCount--;
                                totalShipsDestroyed++;
                            }
                            else if (matrix[row, col - 1] == '>')
                            {
                                secondPlayerShipsCount--;
                                totalShipsDestroyed++;
                            }

                            matrix[row, col - 1] = 'X';
                        }

                        if (IsInTheMatrix(matrix, row, col + 1))
                        {
                            if (matrix[row, col + 1] == '<')
                            {
                                firstPlayerShipsCount--;
                                totalShipsDestroyed++;
                            }
                            else if (matrix[row, col + 1] == '>')
                            {
                                secondPlayerShipsCount--;
                                totalShipsDestroyed++;
                            }

                            matrix[row, col + 1] = 'X';
                        }

                        if (IsInTheMatrix(matrix, row - 1, col - 1))
                        {
                            if (matrix[row - 1, col - 1] == '<')
                            {
                                firstPlayerShipsCount--;
                                totalShipsDestroyed++;
                            }
                            else if (matrix[row - 1, col - 1] == '>')
                            {
                                secondPlayerShipsCount--;
                                totalShipsDestroyed++;
                            }

                            matrix[row - 1, col - 1] = 'X';
                        }

                        if (IsInTheMatrix(matrix, row - 1, col + 1))
                        {
                            if (matrix[row - 1, col + 1] == '<')
                            {
                                firstPlayerShipsCount--;
                                totalShipsDestroyed++;
                            }
                            else if (matrix[row - 1, col + 1] == '>')
                            {
                                secondPlayerShipsCount--;
                                totalShipsDestroyed++;
                            }

                            matrix[row - 1, col + 1] = 'X';
                        }

                        if (IsInTheMatrix(matrix, row + 1, col + 1))
                        {
                            if (matrix[row + 1, col + 1] == '<')
                            {
                                firstPlayerShipsCount--;
                                totalShipsDestroyed++;
                            }
                            else if (matrix[row + 1, col + 1] == '>')
                            {
                                secondPlayerShipsCount--;
                                totalShipsDestroyed++;
                            }

                            matrix[row + 1, col + 1] = 'X';
                        }

                        if (IsInTheMatrix(matrix, row + 1, col - 1))
                        {
                            if (matrix[row + 1, col - 1] == '<')
                            {
                                firstPlayerShipsCount--;
                                totalShipsDestroyed++;
                            }
                            else if (matrix[row + 1, col - 1] == '>')
                            {
                                secondPlayerShipsCount--;
                                totalShipsDestroyed++;
                            }

                            matrix[row + 1, col - 1] = 'X';
                        }
                    }
                }

                if (secondPlayerShipsCount == 0)
                {
                    Console.WriteLine($"Player One has won the game! {totalShipsDestroyed} ships have been sunk in the battle.");
                    printMatrix(matrix);
                    return;
                }
                else if (firstPlayerShipsCount == 0)
                {
                    Console.WriteLine($"Player Two has won the game! {totalShipsDestroyed} ships have been sunk in the battle.");
                    printMatrix(matrix);
                    return;
                }
            }

            Console.WriteLine($"It's a draw! Player One has {firstPlayerShipsCount} left. Player Two has {secondPlayerShipsCount} left.");

            printMatrix(matrix);

        }

        private static char[,] CreateMatrix(int matrixSize, ref int firstPlayerShipsCount, ref int secondPlayerShipsCount)
        {
            char[,] matrix = new char[matrixSize, matrixSize];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                string input = Console.ReadLine();

                string trimmedInput = null;

                for (int i = 0; i < input.Length; i++)
                {
                    if (!char.IsWhiteSpace(input[i]))
                    {
                        trimmedInput += input[i];
                    }
                }

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = trimmedInput[col];

                    if (matrix[row, col] == '<')
                    {
                        firstPlayerShipsCount++;
                    }
                    else if (matrix[row, col] == '>')
                    {
                        secondPlayerShipsCount++;
                    }
                }
            }

            return matrix;
        }

        private static bool IsInTheMatrix(char[,] matrix, int flowerRow, int flowerCol)
        {
            return flowerRow >= 0 && flowerRow < matrix.GetLength(0) &&
                   flowerCol >= 0 && flowerCol < matrix.GetLength(1);
        }

        private static void printMatrix(char[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}