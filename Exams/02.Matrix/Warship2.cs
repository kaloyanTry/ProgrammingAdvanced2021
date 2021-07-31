using System;
using System.Linq;

namespace _02.Warship2
{
    class Program
    {
        static void Main(string[] args)
        {
            int sizeField = int.Parse(Console.ReadLine());
            char[,] matrix = new char[sizeField, sizeField];
            int firstPlayerShipsCount = 0;
            int secondPlayerShipsCount = 0;
            int totalShipsDestroyed = 0;

            string inputCoordinatesString = Console.ReadLine();

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                string rowData = Console.ReadLine();
                string data = null;

                for (int i = 0; i < rowData.Length; i++)
                {
                    if (!char.IsWhiteSpace(rowData[i]))
                    {
                        data += rowData[i];
                    }
                }

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = data[col];

                    if (matrix[row, col] == '<')
                    {
                        firstPlayerShipsCount++;
                    }

                    if (matrix[row, col] == '>')
                    {
                        secondPlayerShipsCount++;
                    }
                }
            }

            string[] inputSets = inputCoordinatesString.Split(',');

            for (int i = 0; i < inputSets.Length; i++)
            {
                int[] setOfCoordinates = inputSets[i].Split(' ').Select(int.Parse).ToArray();
                int row = setOfCoordinates[0];
                int col = setOfCoordinates[1];

                if (IsInTheMatrix(matrix, row, col))
                {
                    if (matrix[row, col] == '<')
                    {
                        firstPlayerShipsCount--;
                        totalShipsDestroyed++;
                        matrix[row, col] = 'X';
                    }

                    if (matrix[row, col] == '>')
                    {
                        secondPlayerShipsCount--;
                        totalShipsDestroyed++;
                        matrix[row, col] = 'X';
                    }

                    if (matrix[row, col] == '#')
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

                if (firstPlayerShipsCount == 0)
                {
                    Console.WriteLine($"Player Two has won the game! {totalShipsDestroyed} ships have been sunk in the battle.");
                    break;
                }

                if (secondPlayerShipsCount == 0)
                {
                    Console.WriteLine($"Player One has won the game! {totalShipsDestroyed} ships have been sunk in the battle.");
                    break;
                }
            }

            if (firstPlayerShipsCount > 0 && secondPlayerShipsCount > 0)
            {
                Console.WriteLine($"It's a draw! Player One has {firstPlayerShipsCount} ships left. Player Two has {secondPlayerShipsCount} ships left.");
            }
           
        }

        private static bool IsInTheMatrix(char[,] matrix, int row, int col)
        {
            return row >= 0 && row < matrix.GetLength(0) && col >= 0 && col < matrix.GetLength(1);
        }
    }
}
