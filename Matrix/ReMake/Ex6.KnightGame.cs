using System;
using System.Linq;


namespace Ex6.KnightGame
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse((Console.ReadLine()));
            char[,] chessBoard = new char[n, n];

            for (int row = 0; row < chessBoard.GetLength(0); row++)
            {
                char[] currentRow = Console.ReadLine().ToCharArray();
                for (int col = 0; col < chessBoard.GetLength(1); col++)
                {
                    chessBoard[row, col] = currentRow[col];
                }
            }

            int countReplaced = 0;
            int rowAttacker = 0;
            int colAttacker = 0;

            while (true)
            {
                int maxAttacks = 0;

                for (int row = 0; row < chessBoard.GetLength(0); row++)
                {
                    for (int col = 0; col < chessBoard.GetLength(1); col++)
                    {
                        char currentSymbol = chessBoard[row, col];
                        int countAttacks = 0;

                        if (currentSymbol == 'K')
                        {
                            countAttacks = GetAttacks(chessBoard, row, col, countAttacks);

                            if (countAttacks > maxAttacks)
                            {
                                maxAttacks = countAttacks;
                                rowAttacker = row;
                                colAttacker = col;
                            }
                        }
                    }
                }

                if (maxAttacks > 0)
                {
                    chessBoard[rowAttacker, colAttacker] = 'O';
                    countReplaced++;
                }
                else
                {
                    Console.WriteLine(countReplaced);
                    break;
                }
            }
        }

        private static int GetAttacks(char[,] chessBoard, int row, int col, int countAttacks)
        {
            if (IsInside(chessBoard, row - 2, col + 1) && chessBoard[row - 2, col + 1] == 'K')
            {
                countAttacks++;
            }
            if (IsInside(chessBoard, row - 2, col - 1) && chessBoard[row - 2, col - 1] == 'K')
            {
                countAttacks++;
            }
            if (IsInside(chessBoard, row + 1, col + 2) && chessBoard[row + 1, col + 2] == 'K')
            {
                countAttacks++;
            }
            if (IsInside(chessBoard, row + 1, col - 2) && chessBoard[row + 1, col - 2] == 'K')
            {
                countAttacks++;
            }
            if (IsInside(chessBoard, row - 1, col + 2) && chessBoard[row - 1, col + 2] == 'K')
            {
                countAttacks++;
            }
            if (IsInside(chessBoard, row - 1, col - 2) && chessBoard[row - 1, col - 2] == 'K')
            {
                countAttacks++;
            }
            if (IsInside(chessBoard, row + 2, col - 1) && chessBoard[row + 2, col - 1] == 'K')
            {
                countAttacks++;
            }
            if (IsInside(chessBoard, row + 2, col + 1) && chessBoard[row + 2, col + 1] == 'K')
            {
                countAttacks++;
            }

            return countAttacks;
        }

        private static bool IsInside(char[,] chessBoard, int targetRow, int targetCol)
        {
            return targetRow >= 0 && targetRow < chessBoard.GetLength(0) && targetCol >= 0 && targetCol < chessBoard.GetLength(1);
        }
    }
}
