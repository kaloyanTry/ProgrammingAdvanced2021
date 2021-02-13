using System;
using System.Linq;

namespace Garden
{
    class Garden
    {
        static void Main(string[] args)
        {
            int[] inputDimension = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int n = inputDimension[0];
            int m = inputDimension[1];

            int[,] matrix = new int[n, m];
            int flowerRow = 0;
            int flowerCol = 0;

            string input = Console.ReadLine();
            while (input != "Bloom Bloom Plow")
            {
                int[] inputPossition = input.Split().Select(int.Parse).ToArray();
                int currentRow = inputPossition[0];
                int currentCol = inputPossition[1];

                if (!IsValidPosition(currentRow, currentCol, n, m))
                {
                    Console.WriteLine("Invalid coordinates.");
                }

                flowerRow = currentRow;
                flowerCol = currentCol;
                
                for (int r1 = 0; r1 < matrix.GetLength(0); r1++)
                {
                    for (int c1 = 0; c1 < matrix.GetLength(1); c1++)
                    {
                        if (r1 == flowerRow || c1 == flowerCol)
                        {
                            matrix[r1, c1] += 1;
                        }
                    }
                }

                input = Console.ReadLine();
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

        public static bool IsValidPosition(int row, int col, int rows, int cols)
        {
            if (row < 0 || row >= rows)
            {
                return false;
            }
            if (col < 0 || col >= cols)
            {
                return false;
            }
            return true;
        }
    }
}
