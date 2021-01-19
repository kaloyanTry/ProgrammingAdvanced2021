using System;
using System.Linq;
using System.Collections.Generic;

namespace JaggedArrayManipulationExercise
{
    class JaggedManipulator
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            double[][] jaggedMatrix = new double[n][];

            for (int row = 0; row < n; row++)
            {
                double[] rowData = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(double.Parse).ToArray();
                jaggedMatrix[row] = rowData;
            }

            for (int row = 0; row < n - 1; row++)
            {
                double[] firstArr = jaggedMatrix[row];
                double[] secondArr = jaggedMatrix[row + 1];

                if (firstArr.Length == secondArr.Length)
                {
                    jaggedMatrix[row] = firstArr.Select(e => e * 2).ToArray();
                    jaggedMatrix[row + 1] = secondArr.Select(e => e * 2).ToArray();
                }
                else
                {
                    jaggedMatrix[row] = firstArr.Select(e => e / 2).ToArray();
                    jaggedMatrix[row + 1] = secondArr.Select(e => e / 2).ToArray();
                }
            }

            string command = Console.ReadLine();
            while (command != "End")
            {
                string[] commandData = command.Split();
                int rowIndex = int.Parse(commandData[1]);
                int colIndex = int.Parse(commandData[2]);
                int value = int.Parse(commandData[3]);

                bool isValidCell = rowIndex >= 0 && rowIndex < n && colIndex >= 0 && colIndex < jaggedMatrix[rowIndex].Length;

                if (!isValidCell)
                {
                    command = Console.ReadLine();
                    continue;
                }

                if (commandData[0] == "Add")
                {
                    jaggedMatrix[rowIndex][colIndex] += value;
                }
                else if (commandData[0] == "Subtract")
                {
                    jaggedMatrix[rowIndex][colIndex] -= value;
                }

                command = Console.ReadLine();
            }

            for (int row = 0; row < n; row++)
            {
                Console.WriteLine(string.Join(" ", jaggedMatrix[row]));
            }
        }
    }
}
