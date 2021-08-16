using System;

namespace _02.Warships
{
    class Warships02
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            char[,] matrix = new char[n, n];
            int firstRow = -1;
            int firstCol = -1;
            int secondRow = -1;
            int secondCol = -1;
            int firstShips = 0;
            int secondShips = 0;
            int totalShips = 0;
            bool endsBattle = false;

            string[] arrCommands = Console.ReadLine().Split(',', StringSplitOptions.RemoveEmptyEntries);

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                string input = Console.ReadLine();
                string editedInput = string.Empty;

                for (int i = 0; i < input.Length; i++)
                {
                    if (!char.IsWhiteSpace(input[i]))
                    {
                        editedInput += input[i];
                    }
                }

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = editedInput[col];

                    if (matrix[row, col] == '<')
                    {
                        firstShips++;
                    }
                    else if (matrix[row, col] == '>')
                    {
                        secondShips++;
                    }
                }
            }

            for (int i = 0; i < arrCommands.Length; i++)
            {
                string[] separatedCommands = arrCommands[i].Split(' ', StringSplitOptions.RemoveEmptyEntries);

                if (i % 2 == 0)
                {
                    firstRow = int.Parse(separatedCommands[0]);
                    firstCol = int.Parse(separatedCommands[1]);
                }
                else
                {
                    secondRow = int.Parse(separatedCommands[0]);
                    secondCol = int.Parse(separatedCommands[1]);
                }

                bool isFirstInside = firstRow >= 0 && firstRow < matrix.GetLength(0) && firstCol >= 0 && firstCol < matrix.GetLength(1);
                bool isSecondInside = secondRow >= 0 && secondRow < matrix.GetLength(0) && secondCol >= 0 && secondCol < matrix.GetLength(1);

                if (isFirstInside && matrix[firstRow, firstCol] == '>')
                {
                    secondShips--;
                    totalShips++;
                    matrix[firstRow, firstCol] = 'X';
                }

                if (isSecondInside && matrix[secondRow, secondCol] == '<')
                {
                    firstShips--;
                    totalShips++;
                    matrix[secondRow, secondCol] = 'X';
                }

                if (isFirstInside && matrix[firstRow, firstCol] == '#')
                {
                    if (firstRow + 1 < matrix.GetLength(0))
                    {
                        if (matrix[firstRow + 1, firstCol] == '>')
                        {
                            secondShips--;
                            totalShips++;
                            matrix[firstRow + 1, firstCol] = 'X';
                        }
                        else if (matrix[firstRow + 1, firstCol] == '<')
                        {
                            firstShips--;
                            totalShips++;
                            matrix[firstRow + 1, firstCol] = 'X';
                        }

                        if (firstCol + 1 < matrix.GetLength(1))
                        {
                            if (matrix[firstRow + 1, firstCol + 1] == '>')
                            {
                                secondShips--;
                                totalShips++;
                                matrix[firstRow + 1, firstCol + 1] = 'X';
                            }
                            else if (matrix[firstRow + 1, firstCol + 1] == '<')
                            {
                                firstShips--;
                                totalShips++;
                                matrix[firstRow + 1, firstCol + 1] = 'X';
                            }
                        }

                        if (firstCol - 1 >= 0)
                        {
                            if (matrix[firstRow + 1, firstCol - 1] == '>')
                            {
                                secondShips--;
                                totalShips++;
                                matrix[firstRow + 1, firstCol - 1] = 'X';
                            }
                            else if (matrix[firstRow + 1, firstCol - 1] == '<')
                            {
                                firstShips--;
                                totalShips++;
                                matrix[firstRow + 1, firstCol - 1] = 'X';
                            }
                        }
                    }

                    if (firstRow - 1 >= 0)
                    {
                        if (matrix[firstRow - 1, firstCol] == '>')
                        {
                            secondShips--;
                            totalShips++;
                            matrix[firstRow - 1, firstCol] = 'X';
                        }
                        else if (matrix[firstRow - 1, firstCol] == '<')
                        {
                            firstShips--;
                            totalShips++;
                            matrix[firstRow - 1, firstCol] = 'X';
                        }
                    }

                    if (firstCol + 1 < matrix.GetLength(1))
                    {
                        if (matrix[firstRow, firstCol + 1] == '>')
                        {
                            secondShips--;
                            totalShips++;
                            matrix[firstRow, firstCol + 1] = 'X';
                        }
                        else if (matrix[firstRow, firstCol + 1] == '<')
                        {
                            firstShips--;
                            totalShips++;
                            matrix[firstRow, firstCol + 1] = 'X';
                        }
                    }

                    if (firstCol - 1 >= 0)
                    {
                        if (matrix[firstRow, firstCol - 1] == '>')
                        {
                            secondShips--;
                            totalShips++;
                            matrix[firstRow, firstCol - 1] = 'X';
                        }
                        else if (matrix[firstRow, firstCol - 1] == '<')
                        {
                            firstShips--;
                            totalShips++;
                            matrix[firstRow, firstCol - 1] = 'X';
                        }
                    }

                    matrix[firstRow, firstCol] = 'X';
                }


                if (isSecondInside && matrix[secondRow, secondCol] == '#')
                {
                    if (secondRow + 1 < matrix.GetLength(0))
                    {
                        if (matrix[secondRow + 1, secondCol] == '<')
                        {
                            firstShips--;
                            totalShips++;
                            matrix[secondRow + 1, secondCol] = 'X';
                        }
                        else if (matrix[secondRow + 1, secondCol] == '>')
                        {
                            secondShips--;
                            totalShips++;
                            matrix[secondRow + 1, secondCol] = 'X';
                        }

                        if (secondCol + 1 < matrix.GetLength(1))
                        {
                            if (matrix[secondRow + 1, secondCol + 1] == '<')
                            {
                                firstShips--;
                                totalShips++;
                                matrix[secondRow + 1, secondCol + 1] = 'X';
                            }
                            else if (matrix[secondRow + 1, secondCol + 1] == '>')
                            {
                                secondShips--;
                                totalShips++;
                                matrix[secondRow + 1, secondCol + 1] = 'X';
                            }
                        }

                        if (secondCol - 1 >= 0)
                        {
                            if (matrix[secondRow + 1, secondCol - 1] == '<')
                            {
                                firstShips--;
                                totalShips++;
                                matrix[secondRow + 1, secondCol - 1] = 'X';
                            }
                            else if (matrix[secondRow + 1, secondCol - 1] == '>')
                            {
                                secondShips--;
                                totalShips++;
                                matrix[secondRow + 1, secondCol - 1] = 'X';
                            }
                        }
                    }

                    if (secondRow - 1 >= 0)
                    {
                        if (matrix[secondRow - 1, secondCol] == '<')
                        {
                            firstShips--;
                            totalShips++;
                            matrix[secondRow - 1, secondCol] = 'X';
                        }
                        else if (matrix[secondRow - 1, secondCol] == '>')
                        {
                            secondShips--;
                            totalShips++;
                            matrix[secondRow - 1, secondCol] = 'X';
                        }
                    }

                    if (secondCol + 1 < matrix.GetLength(1))
                    {
                        if (matrix[secondRow, secondCol + 1] == '<')
                        {
                            firstShips--;
                            totalShips++;
                            matrix[secondRow, secondCol + 1] = 'X';
                        }
                        else if (matrix[secondRow, secondCol + 1] == '>')
                        {
                            secondShips--;
                            totalShips++;
                            matrix[secondRow, secondCol + 1] = 'X';
                        }
                    }

                    if (secondCol - 1 >= 0)
                    {
                        if (matrix[secondRow, secondCol - 1] == '<')
                        {
                            firstShips--;
                            totalShips++;
                            matrix[secondRow, secondCol - 1] = 'X';
                        }
                        else if (matrix[secondRow, secondCol - 1] == '>')
                        {
                            secondShips--;
                            totalShips++;
                            matrix[secondRow, secondCol - 1] = 'X';
                        }
                    }

                    matrix[secondRow, secondCol] = 'X';
                }

                if (secondShips == 0)
                {
                    Console.WriteLine($"Player One has won the game! {totalShips} ships have been sunk in the battle.");
                    endsBattle = true;
                    break;
                }

                if (firstShips == 0)
                {
                    Console.WriteLine($"Player Two has won the game! {totalShips} ships have been sunk in the battle.");
                    endsBattle = true;
                    break;
                }
            }

            if (!endsBattle)
            {
                Console.WriteLine($"It's a draw! Player One has {firstShips} ships left. Player Two has {secondShips} ships left.");
            }

            //Print the matrix:
            //for (int row = 0; row < matrix.GetLength(0); row++)
            //{
            //    for (int col = 0; col < matrix.GetLength(1); col++)
            //    {
            //        Console.Write(matrix[row, col]);
            //    }
            //    Console.WriteLine();
            //}
        }
    }
}
