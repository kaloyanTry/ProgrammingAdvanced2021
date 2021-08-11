using System;
using System.Linq;
using System.Text;

namespace _02.SuperMario
{
    class Program
    {
        static void Main(string[] args)
        {
            int livesMario = int.Parse(Console.ReadLine());
            int nRows = int.Parse(Console.ReadLine());

            char[][] matrix = new char[nRows][];
            int rowMario = -1;
            int colMario = -1;

            for (int row = 0; row < nRows; row++)
            {
                string inputRow = Console.ReadLine();

                matrix[row] = new char[inputRow.Length];

                for (int col = 0; col < matrix[row].Length; col++)
                {
                    matrix[row][col] = inputRow[col];

                    if (matrix[row][col] == 'M')
                    {
                        rowMario = row;
                        colMario = col;
                    }
                }
            }

            while (true)
            {
                string[] inputData = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

                matrix[rowMario][colMario] = '-';

                char moveCommand = char.Parse(inputData[0]);
                int rowSpawn = int.Parse(inputData[1]);
                int colSpawn = int.Parse(inputData[2]);

                matrix[rowSpawn][colSpawn] = 'B';

                if (moveCommand == 'W')
                {
                    rowMario--;
                }
                else if (moveCommand == 'S')
                {
                    rowMario++;
                }
                else if (moveCommand == 'A')
                {
                    colMario--;
                }
                else if (moveCommand == 'D')
                {
                    colMario++;
                }

                if (rowMario == -1)
                {
                    rowMario = 0;
                }
                else if (rowMario == nRows)
                {
                    rowMario = nRows - 1;
                }
                else if (colMario == -1)
                {
                    colMario = 0;
                }
                else if (colMario == matrix.Length)
                {
                    colMario = matrix.Length - 1;
                }

                livesMario--;

                if (matrix[rowMario][colMario] == matrix[rowSpawn][colSpawn])
                {
                    livesMario -= 2;
                }

                if (matrix[rowMario][colMario] == 'P')
                {
                    matrix[rowMario][colMario] = '-';
                    Console.WriteLine($"Mario has successfully saved the princess! Lives left: {livesMario}");
                    break;
                }

                if (livesMario <= 0)
                {
                    matrix[rowMario][colMario] = 'X';
                    Console.WriteLine($"Mario died at {rowMario};{colMario}.");
                    break;
                }

                matrix[rowMario][colMario] = 'M';
            }

            foreach (var row in matrix)
            {
                Console.WriteLine(row);
            }
        }
    }
}
