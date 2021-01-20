using System;
using System.Linq;
using System.Collections.Generic;

namespace RadioActiveMutant
{
    class RadioactiveMutant
    {
        static void Main(string[] args)
        {
            int[] sizes = Console.ReadLine().Split().Select(int.Parse).ToArray();

            char[,] lair = new char[sizes[0], sizes[1]];

            List<Bunnie> bunnies = new List<Bunnie>();

            int playerRow = -1;
            int playerCol = -1;

            for (int row = 0; row < sizes[0]; row++)
            {
                string line = Console.ReadLine();
                for (int col = 0; col < sizes[1]; col++)
                {
                    lair[row, col] = line[col];
                    if (lair[row, col] == 'B')
                    {
                        bunnies.Add(new Bunnie(row, col));
                    }
                    else if (lair[row, col] == 'P')
                    {
                        playerCol = col;
                        playerRow = row;
                    }
                }
            }

            char[] commands = Console.ReadLine().ToCharArray();
            Queue<char> moves = new Queue<char>(commands);


            bool IsWinner = false;
            bool IsLoser = false;

            while (moves.Count > 0)
            {
                char move = moves.Dequeue();

                if (move == 'U')
                {
                    playerRow--;
                    if (playerRow < 0 || playerRow >= lair.GetLength(0))
                    {
                        IsWinner = true;
                        playerRow++;
                        lair[playerRow, playerCol] = '.';
                    }
                    else if (lair[playerRow, playerCol] == 'B')
                    {
                        IsLoser = true;
                    }

                    if (!IsWinner && !IsLoser)
                    {
                        lair[playerRow + 1, playerCol] = '.';
                        lair[playerRow, playerCol] = 'P';
                    }
                }
                else if (move == 'D')
                {
                    playerRow++;
                    if (playerRow < 0 || playerRow >= lair.GetLength(0))
                    {
                        IsWinner = true;
                        playerRow--;
                        lair[playerRow, playerCol] = '.';
                    }
                    else if (lair[playerRow, playerCol] == 'B')
                    {
                        IsLoser = true;
                    }

                    if (!IsWinner && !IsLoser)
                    {
                        lair[playerRow - 1, playerCol] = '.';
                        lair[playerRow, playerCol] = 'P';
                    }

                }
                else if (move == 'L')
                {
                    playerCol--;
                    if (playerCol < 0 || playerCol >= lair.GetLength(1))
                    {
                        IsWinner = true;
                        playerCol++;
                        lair[playerRow, playerCol] = '.';
                    }
                    else if (lair[playerRow, playerCol] == 'B')
                    {
                        IsLoser = true;
                    }

                    if (!IsWinner && !IsLoser)
                    {
                        lair[playerRow, playerCol + 1] = '.';
                        lair[playerRow, playerCol] = 'P';
                    }
                }
                else if (move == 'R')
                {
                    playerCol++;
                    if (playerCol < 0 || playerCol >= lair.GetLength(1))
                    {
                        IsWinner = true;
                        playerCol--;
                        lair[playerRow, playerCol] = '.';
                    }
                    else if (lair[playerRow, playerCol] == 'B')
                    {
                        IsLoser = true;
                    }

                    if (!IsWinner && !IsLoser)
                    {
                        lair[playerRow, playerCol - 1] = '.';
                        lair[playerRow, playerCol] = 'P';
                    }
                }

                //MultiplyBunnies
                int bunniesCount = bunnies.Count;
                for (int i = 0; i < bunniesCount; i++)
                {
                    if (IsValidPos(bunnies[i].X + 1, bunnies[i].Y, sizes) && lair[bunnies[i].X + 1, bunnies[i].Y] != 'B')
                    {
                        if (lair[bunnies[i].X + 1, bunnies[i].Y] == 'P')
                        {
                            IsLoser = true;
                        }

                        lair[bunnies[i].X + 1, bunnies[i].Y] = 'B';
                        bunnies.Add(new Bunnie(bunnies[i].X + 1, bunnies[i].Y));
                    }

                    if (IsValidPos(bunnies[i].X - 1, bunnies[i].Y, sizes) && lair[bunnies[i].X - 1, bunnies[i].Y] != 'B')
                    {
                        if (lair[bunnies[i].X - 1, bunnies[i].Y] == 'P')
                        {
                            IsLoser = true;
                        }

                        lair[bunnies[i].X - 1, bunnies[i].Y] = 'B';
                        bunnies.Add(new Bunnie(bunnies[i].X - 1, bunnies[i].Y));
                    }

                    if (IsValidPos(bunnies[i].X, bunnies[i].Y + 1, sizes) && lair[bunnies[i].X, bunnies[i].Y + 1] != 'B')
                    {
                        if (lair[bunnies[i].X, bunnies[i].Y + 1] == 'P')
                        {
                            IsLoser = true;
                        }

                        lair[bunnies[i].X, bunnies[i].Y + 1] = 'B';
                        bunnies.Add(new Bunnie(bunnies[i].X, bunnies[i].Y + 1));
                    }

                    if (IsValidPos(bunnies[i].X, bunnies[i].Y - 1, sizes) && lair[bunnies[i].X, bunnies[i].Y - 1] != 'B')
                    {
                        if (lair[bunnies[i].X, bunnies[i].Y - 1] == 'P')
                        {
                            IsLoser = true;
                        }

                        lair[bunnies[i].X, bunnies[i].Y - 1] = 'B';
                        bunnies.Add(new Bunnie(bunnies[i].X, bunnies[i].Y - 1));
                    }
                }

                if (IsWinner || IsLoser)
                {
                    break;
                }
            }

            for (int row = 0; row < sizes[0]; row++)
            {
                for (int col = 0; col < sizes[1]; col++)
                {
                    Console.Write(lair[row, col]);
                }

                Console.WriteLine();
            }

            if (IsWinner)
            {
                Console.WriteLine($"won: {playerRow} {playerCol}");
            }

            if (IsLoser)
            {
                Console.WriteLine($"dead: {playerRow} {playerCol}");
            }
        }

        private static bool IsValidPos(int row, int col, int[] sizes)
        {
            int rows = sizes[0];
            int cols = sizes[1];

            if ((row >= 0 && row < rows) && (col >= 0 && col < cols))
            {
                return true;
            }

            return false;
        }
    }
    public class Bunnie
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Bunnie()
        {
        }
        public Bunnie(int x, int y)
        {
            X = x;
            Y = y;
        }
    }

}
