using System;
using System.Linq;

namespace _02.ProblemMatrix2
{
    class Program
    {
        static void Main(string[] args)
        {
            int livesMario = int.Parse(Console.ReadLine());
            int nRows = int.Parse(Console.ReadLine());

            char[][] maze = new char[nRows][];
            int marioRow = -1;
            int marioCol = -1;

            for (int row = 0; row < nRows; row++)
            {
                string input = Console.ReadLine();
                maze[row] = new char[input.Length];

                for (int col = 0; col < maze[row].Length; col++)
                {
                    maze[row][col] = input[col];

                    if (maze[row][col] == 'M')
                    {
                        marioRow = row;
                        marioCol = col;
                    }
                }
            }

            while (true)
            {
                string[] commands = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

                maze[marioRow][marioCol] = '-';

                char direction = char.Parse(commands[0]);
                int spawnRow = int.Parse(commands[1]);
                int spawnCol = int.Parse(commands[2]);

                maze[spawnRow][spawnCol] = 'B';

                if (direction == 'W')
                {
                    marioRow--;
                }
                else if (direction == 'S')
                {
                    marioRow++;
                }
                else if (direction == 'A')
                {
                    marioCol--;
                }
                else if (direction == 'D')
                {
                    marioCol++;
                }

                if (marioRow == -1)
                {
                    marioRow = 0;
                }
                else if (marioRow == nRows)
                {
                    marioRow = nRows - 1;
                }
                else if (marioCol == -1)
                {
                    marioCol = 0;
                }
                else if (marioCol == maze.Length)
                {
                    marioCol = maze.Length - 1;
                }

                livesMario--;

                if (maze[marioRow][marioCol] == maze[spawnRow][spawnCol])
                {
                    maze[marioRow][marioCol] = '-';
                    livesMario -= 2;
                }

                if (maze[marioRow][marioCol] == 'P')
                {
                    maze[marioRow][marioCol] = '-';
                    Console.WriteLine($"Mario has successfully saved the princess! Lives left: {livesMario}");
                    break;
                }

                if (livesMario <= 0)
                {
                    maze[marioRow][marioCol] = 'X';
                    Console.WriteLine($"Mario died at {marioRow};{marioCol}.");
                    break;
                }
            }

            foreach (var row in maze)
            {
                Console.WriteLine(row);
            }
        }
    }
}
