using System;
using System.Linq;
using System.Collections.Generic;

namespace MatrixMiner
{
    class Miner
    {
        static void Main(string[] args)
        {
            int fieldSize = int.Parse(Console.ReadLine());

            char[,] field = new char[fieldSize, fieldSize];

            string[] commands = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
            Queue<string> moves = new Queue<string>(commands);

            for (int row = 0; row < fieldSize; row++)
            {
                string[] values = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
                for (int col = 0; col < fieldSize; col++)
                {
                    field[row, col] = values[col][0];
                }
            }

            int minerRow = -1;
            int minerCol = -1;
            int totalCoals = 0;
            int collectedCoals = 0;
            int endRow = -1;
            int endCol = -1;

            for (int row = 0; row < fieldSize; row++)
            {
                for (int col = 0; col < fieldSize; col++)
                {
                    if (field[row, col] == 's')
                    {
                        minerRow = row;
                        minerCol = col;
                    }
                    else if (field[row, col] == 'c')
                    {
                        totalCoals++;
                    }
                    else if (field[row, col] == 'e')
                    {
                        endCol = col;
                        endRow = row;
                    }
                }
            }

            while (moves.Count > 0)
            {
                string move = moves.Dequeue();
                if (move == "left" && IsValidPos(minerCol - 1, field))
                {
                    minerCol--;
                    if (field[minerRow, minerCol] == 'e')
                    {
                        break;
                    }
                    else if (field[minerRow, minerCol] == 'c')
                    {
                        collectedCoals++;
                        field[minerRow, minerCol] = '*';
                        if (collectedCoals == totalCoals)
                        {
                            break;
                        }
                    }
                }
                else if (move == "right" && IsValidPos(minerCol + 1, field))
                {
                    minerCol++;
                    if (field[minerRow, minerCol] == 'e')
                    {
                        break;
                    }
                    else if (field[minerRow, minerCol] == 'c')
                    {
                        field[minerRow, minerCol] = '*';
                        collectedCoals++;
                        if (collectedCoals == totalCoals)
                        {
                            break;
                        }
                    }
                }
                else if (move == "up" && IsValidPos(minerRow - 1, field))
                {
                    minerRow--;
                    if (field[minerRow, minerCol] == 'e')
                    {
                        break;
                    }
                    else if (field[minerRow, minerCol] == 'c')
                    {
                        collectedCoals++;
                        field[minerRow, minerCol] = '*';
                        if (collectedCoals == totalCoals)
                        {
                            break;
                        }
                    }
                }
                else if (move == "down" && IsValidPos(minerRow + 1, field))
                {
                    minerRow++;
                    if (field[minerRow, minerCol] == 'e')
                    {
                        break;
                    }
                    else if (field[minerRow, minerCol] == 'c')
                    {
                        collectedCoals++;
                        field[minerRow, minerCol] = '*';
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

        private static bool IsValidPos(int pos, char[,] field)
        {
            if (pos >= 0 && pos < field.GetLength(1))
            {
                return true;
            }

            return false;
        }
    }
}