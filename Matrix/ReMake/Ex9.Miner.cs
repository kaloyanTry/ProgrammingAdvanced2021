using System;
using System.Collections.Generic;
using System.Linq;

namespace Ex9.Miner
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            char[,] matrix = new char[n, n];

            string[] commands = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
            Queue<string> movesQueue = new Queue<string>(commands);

            for (int row = 0; row < n; row++)
            {
                string[] data = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
                for (int col = 0; col < n; col++)
                {
                    matrix[row, col] = data[col][0];
                }
            }

            int minerRow = -1;
            int minerCol = -1;
            int totalCoals = 0;
            int collectedCoals = 0;
            int endRow = -1;
            int endCol = -1;

            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < n; col++)
                {
                    if (matrix[row, col] == 's')
                    {
                        minerRow = row;
                        minerCol = col;
                    }
                    else if (matrix[row, col] == 'c')
                    {
                        totalCoals++;
                    }
                    else if (matrix[row, col] == 'e')
                    {
                        endCol = col;
                        endRow = row;
                    }
                }
            }

            while (movesQueue.Any())
            {
                string move = movesQueue.Dequeue();
                if (move == "left" && IsValidPos(minerCol - 1, matrix))
                {
                    minerCol--;
                    if (matrix[minerRow, minerCol] == 'e')
                    {
                        break;
                    }
                    else if (matrix[minerRow, minerCol] == 'c')
                    {
                        collectedCoals++;
                        matrix[minerRow, minerCol] = '*';
                        if (collectedCoals == totalCoals)
                        {
                            break;
                        }
                    }
                }
                else if (move == "right" && IsValidPos(minerCol + 1, matrix))
                {
                    minerCol++;
                    if (matrix[minerRow, minerCol] == 'e')
                    {
                        break;
                    }
                    else if (matrix[minerRow, minerCol] == 'c')
                    {
                        collectedCoals++;
                        matrix[minerRow, minerCol] = '*';
                        if (collectedCoals == totalCoals)
                        {
                            break;
                        }
                    }
                }
                else if (move == "up" && IsValidPos(minerRow - 1, matrix))
                {
                    minerRow--;
                    if (matrix[minerRow, minerCol] == 'e')
                    {
                        break;
                    }
                    else if (matrix[minerRow, minerCol] == 'c')
                    {
                        collectedCoals++;
                        matrix[minerRow, minerCol] = '*';
                        if (collectedCoals == totalCoals)
                        {
                            break;
                        }
                    }
                }
                else if (move == "down" && IsValidPos(minerRow + 1, matrix))
                {
                    minerRow++;
                    if (matrix[minerRow, minerCol] == 'e')
                    {
                        break;
                    }
                    else if (matrix[minerRow, minerCol] == 'c')
                    {
                        collectedCoals++;
                        matrix[minerRow, minerCol] = '*';
                        if (collectedCoals == totalCoals)
                        {
                            break;
                        }
                    }
                }
            }

            if (collectedCoals == totalCoals)
            {
                Console.WriteLine($"You collected all coals! ({minerRow}, {minerCol})");
            }
            else if (minerRow == endRow && minerCol == endCol)
            {
                Console.WriteLine($"Game over! ({minerRow}, {minerCol})");
            }
            else
            {
                Console.WriteLine($"{totalCoals - collectedCoals} coals left. ({minerRow}, {minerCol})");
            }
        }

        private static bool IsValidPos(int possition, char[,] field)
        {
            if (possition >= 0 && possition < field.GetLength(1))
            {
                return true;
            }

            return false;
        }
    }
}
