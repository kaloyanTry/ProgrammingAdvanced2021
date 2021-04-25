using System;
using System.Linq;

namespace _6.JaggedArrayModification
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[,] matrix = new int[n, n];

            FillMatrix(n, matrix);

            string input = Console.ReadLine();
            while (input != "END")
            {
                string[] inputArray = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string command = inputArray[0];
                int rowCmd = int.Parse(inputArray[1]);
                int colCmd = int.Parse(inputArray[2]);
                int valueCmd = int.Parse(inputArray[3]);

                if (rowCmd >= 0 && rowCmd < matrix.GetLength(0) && colCmd >= 0 && colCmd < matrix.GetLength(1))
                {
                    if (command == "Add")
                    {
                        matrix[rowCmd, colCmd] += valueCmd;
                    }
                    else if (command == "Subtract")
                    {
                        matrix[rowCmd, colCmd] -= valueCmd;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid coordinates");
                }

                input = Console.ReadLine();
            }

            PrintMatrix(matrix);
        }

        private static void FillMatrix(int n, int[,] matrix)
        {
            for (int row = 0; row < n; row++)
            {
                int[] data = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                for (int col = 0; col < n; col++)
                {
                    matrix[row, col] = data[col];
                }
            }
        }

        private static void PrintMatrix(int[,] matrix)
        {
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
