using System;

namespace _02.ProblemMatrix2
{
    class Program
    {
        static void Main(string[] args)
        {
            int beeRow = -1;
            int beeCol = -1;
            int flowers = 0;

            int n = int.Parse(Console.ReadLine());
            char[,] matrix = new char[n, n];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                string input = Console.ReadLine();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = input[col];

                    if (matrix[row, col] == 'B')
                    {
                        beeRow = row;
                        beeCol = col;
                    }
                }
            }

            string inputCommand = Console.ReadLine();
            while (inputCommand != "End")
            {
                matrix[beeRow, beeCol] = '.';

                MoveBee(ref beeRow, ref beeCol, inputCommand);

                if (IsOutside(ref matrix, ref beeRow, ref beeCol))
                {
                    Console.WriteLine("The bee got lost!");
                    break;
                }

                if (matrix[beeRow, beeCol] == 'f')
                {
                    flowers++;
                    matrix[beeRow, beeCol] = '.';
                }
                
                if (matrix[beeRow, beeCol] == 'O')
                {
                    matrix[beeRow, beeCol] = '.';
                    MoveBee(ref beeRow, ref beeCol, inputCommand);

                    if (IsOutside(ref matrix, ref beeRow, ref beeCol))
                    {
                        Console.WriteLine("The bee got lost!");
                        break;
                    }

                    if (matrix[beeRow, beeCol] == 'f')
                    {
                        flowers++;
                        matrix[beeRow, beeCol] = '.';
                    }
                }

                matrix[beeRow, beeCol] = 'B';
                inputCommand = Console.ReadLine();
            }

            if (flowers >= 5)
            {
                Console.WriteLine($"Great job, the bee managed to pollinate {flowers} flowers!");
            }
            else
            {
                Console.WriteLine($"The bee couldn't pollinate the flowers, she needed {5 - flowers} flowers more");
            }

            //Print the matrix:
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col]);
                }
                Console.WriteLine();
            }
        }

        private static void MoveBee(ref int beeRow, ref int beeCol, string inputCommand)
        {
            if (inputCommand == "up")
            {
                beeRow--;
            }
            else if (inputCommand == "down")
            {
                beeRow++;
            }
            else if (inputCommand == "right")
            {
                beeCol++;
            }
            else if (inputCommand == "left")
            {
                beeCol--;
            }
        }

        private static bool IsOutside(ref char[,] matrix, ref int beeRow, ref int beeCol)
        {
            if (beeRow < 0 || beeRow >= matrix.GetLength(0) || beeCol < 0 || beeCol >= matrix.GetLength(1))
            {
                return true;
            }

            return false;
        }
    }
}
