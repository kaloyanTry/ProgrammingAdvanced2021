using System;

namespace MatrixBee
{
    class MatrixBee
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            char[,] matrix = new char[n, n];
            int beeRow = -1;
            int beeCol = -1;
            int flowersCount = 0;

            for (int row = 0; row < n; row++)
            {
                string inputMatrix = Console.ReadLine();
                for (int col = 0; col < n; col++)
                {
                    matrix[row, col] = inputMatrix[col];

                    if (matrix[row, col] == 'B')
                    {
                        beeRow = row;
                        beeCol = col;
                    }
                }
            }

            string command = Console.ReadLine();
            while (command != "End")
            {
                matrix[beeRow, beeCol] = '.';

                MoveBee(ref beeRow, ref beeCol, command);

                if ((beeRow < 0 || beeRow >= matrix.GetLength(0)) || (beeCol < 0 || beeCol >= matrix.GetLength(1)))
                {
                    Console.WriteLine("The bee got lost!");
                    break;
                }

                if (matrix[beeRow, beeCol] == 'f')
                {
                    flowersCount++;
                }

                if (matrix[beeRow, beeCol] == 'O')
                {
                    matrix[beeRow, beeCol] = '.';
                    MoveBee(ref beeRow, ref beeCol, command);

                    if ((beeRow < 0 || beeRow >= matrix.GetLength(0)) || (beeCol < 0 || beeCol >= matrix.GetLength(1)))
                    {
                        Console.WriteLine("The bee got lost!");
                        break;
                    }
                    if (matrix[beeRow, beeCol] == 'f')
                    {
                        flowersCount++;
                    }
                }

                matrix[beeRow, beeCol] = 'B';

                command = Console.ReadLine();
            }

            if (flowersCount < 5)
            {
                Console.WriteLine($"The bee couldn't pollinate the flowers, she needed {5 - flowersCount} flowers more");
            }
            else
            {
                Console.WriteLine($"Great job, the bee managed to pollinate {flowersCount} flowers!");
            }

            PrintMatrix(matrix);
        }

        private static void PrintMatrix(char[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col]);
                }
                Console.WriteLine();
            }
        }

        private static void MoveBee(ref int beeRow, ref int beeCol, string command)
        {
            if (command == "up")
            {
                beeRow -= 1;
            }
            else if (command == "down")
            {
                beeRow += 1;
            }
            else if (command == "left")
            {
                beeCol -= 1;
            }
            else if (command == "right")
            {
                beeCol += 1;
            }
        }
    }
}
