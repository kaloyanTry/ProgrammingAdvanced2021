using System;

namespace SymbolInMatrix
{
    class SymbolInMatrix
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            char[,] matrix = new char[n, n];
            for (int row = 0; row < n; row++)
            {
                char[] rowChars = Console.ReadLine().ToCharArray();

                for (int col = 0; col < rowChars.Length; col++)
                {
                    matrix[row, col] = rowChars[col];
                }
            }

            char searchChar = char.Parse(Console.ReadLine());

            int charRow = -1;
            int charCol = -1;

            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < n; col++)
                {
                    if (matrix[row, col] == searchChar)
                    {
                        charRow = row;
                        charCol = col;
                        break;
                    }
                }

                if (charRow != -1)
                {
                    break;
                }
            }

            if (charRow != -1 && charCol != -1)
            {
                Console.WriteLine($"({charRow}, {charCol})");
            }
            else
            {
                Console.WriteLine($"{searchChar} does not occur in the matrix");
            }
        }
    }
}
