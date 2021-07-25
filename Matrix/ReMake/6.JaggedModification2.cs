using System;
using System.Linq;

namespace ConsoleMatrix2
{
    class JaggedModification
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[,] matrix = new int[n, n];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                int[] rawData = Console.ReadLine().Split().Select(int.Parse).ToArray();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = rawData[col];
                }
            }
         
            string inputCommand = Console.ReadLine();
            while (inputCommand != "END")
            {
                string[] inputData = inputCommand.Split();
                int inputRow = int.Parse(inputData[1]);
                int inputCol = int.Parse(inputData[2]);
                int inputValue = int.Parse(inputData[3]);

                bool isOutOfTheMatrix = inputRow < 0 || inputRow >= matrix.GetLength(0) || inputCol < 0 || inputCol >= matrix.GetLength(1);

                if (inputCommand.Contains("Add") && !isOutOfTheMatrix)
                {
                    matrix[inputRow, inputCol] += inputValue;
                }
                else if (inputCommand.Contains("Subtract") && !isOutOfTheMatrix)
                {
                    matrix[inputRow, inputCol] -= inputValue;
                }
                else
                {
                    Console.WriteLine("Invalid coordinates");
                }

                inputCommand = Console.ReadLine();
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
