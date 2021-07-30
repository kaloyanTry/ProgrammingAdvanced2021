using System;
using System.Linq;

namespace _02.ProblemMatrix2
{
    class Program
    {
        static void Main(string[] args)
        {
           int[] inputDimensions = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int n1 = inputDimensions[0];
            int n2 = inputDimensions[1];
            int[,] matrix = new int[n1, n2];
            int emptyFlower = 0;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = emptyFlower;
                }
            }

            string command = Console.ReadLine();
            while (command != "Bloom Bloom Plow")
            {
                int[] inputCoordinates = command.Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                int inputRow = inputCoordinates[0];
                int inputCol = inputCoordinates[1];

                if (inputRow < 0 || inputRow >= matrix.GetLength(0) || inputCol < 0 || inputCol >= matrix.GetLength(1))
                {
                    Console.WriteLine("Invalid coordinates.");
                }

                for (int row = 0; row < matrix.GetLength(0); row++)
                {
                    for (int col = 0; col < matrix.GetLength(1); col++)
                    {
                        if (row == inputRow || col == inputCol)
                        {
                            matrix[row, col]++;
                        }
                    }
                }

                command = Console.ReadLine();
            }

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