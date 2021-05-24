using System;

namespace _02.Bee
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            char[,] matrix = new char[n, n];
            int pollinatedFlowers = 0;
            int beeRow = -1;
            int beeCol = -1;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                string inputMatrix = Console.ReadLine();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = inputMatrix[col];

                    if (matrix[row, col] == 'B')
                    {
                        beeRow = row;
                        beeCol = col;
                    }
                }
            }

            string input = Console.ReadLine();
            while (input != "End")
            {
                matrix[beeRow, beeCol] = '.';

                MoveBee(ref beeRow, ref beeCol, input);

                bool isOutside = beeRow < 0 || beeRow >= matrix.GetLength(0) || beeCol < 0 || beeCol >= matrix.GetLength(1);

                if (isOutside)
                {
                    Console.WriteLine("The bee got lost!");
                    break;
                }

                if (matrix[beeRow, beeCol] == 'f')
                {
                    pollinatedFlowers++;
                }

                if (matrix[beeRow, beeCol] == 'O')
                {
                    matrix[beeRow, beeCol] = '.';

                    MoveBee(ref beeRow, ref beeCol, input);
                    
                    if (isOutside)
                    {
                        Console.WriteLine("The bee got lost!");
                        break;
                    }

                    if (matrix[beeRow, beeCol] == 'f')
                    {
                        pollinatedFlowers++;
                    }
                }

                matrix[beeRow, beeCol] = 'B';

                input = Console.ReadLine();
            }

            if (pollinatedFlowers < 5)
            {
                Console.WriteLine($"The bee couldn't pollinate the flowers, she needed {5 - pollinatedFlowers} flowers more");
            }
            else
            {
                Console.WriteLine($"Great job, the bee managed to pollinate {pollinatedFlowers} flowers!");
            }

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col]);
                }

                Console.WriteLine();
            }
        }

        private static void MoveBee(ref int beeRow, ref int beeCol, string input)
        {
            if (input == "up")
            {
                beeRow -= 1;
            }
            else if (input == "down")
            {
                beeRow += 1;
            }
            else if (input == "left")
            {
                beeCol -= 1;
            }
            else if (input == "right")
            {
                beeCol += 1;
            }
        }
    }
}