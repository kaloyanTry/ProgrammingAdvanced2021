using System;
using System.Linq;
using System.Collections.Generic;

namespace KnightGame
{
    class KnightGame
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            char[,] chessBoard = new char[n, n];

            fillMatrix(chessBoard);

            int countReplaced = 0;
            int rowAttacker = 0;
            int colAttacker = 0;

            while (true)
            {
                int maxAttacks = 0;

                for (int row = 0; row < n; row++)
                {
                    for (int col = 0; col < n; col++)
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
                    chessBoard[rowAttacker, colAttacker] = '0';
                    countReplaced++;
                }

                else
                {
                    Console.WriteLine(countReplaced);
                    break;
                }
            }

            //print the matrix:
            //printMatrix(chessBoard);
        }

        private static int GetAttacks(char[,] chessBoard, int row, int col, int countAttacks)
        {
            if (isInside(chessBoard, row - 2, col + 1) && chessBoard[row - 2, col + 1] == 'K')
            {
                countAttacks++;
            }
            if (isInside(chessBoard, row - 2, col - 1) && chessBoard[row - 2, col - 1] == 'K')
            {
                countAttacks++;
            }
            if (isInside(chessBoard, row + 1, col + 2) && chessBoard[row + 1, col + 2] == 'K')
            {
                countAttacks++;
            }
            if (isInside(chessBoard, row + 1, col - 2) && chessBoard[row + 1, col - 2] == 'K')
            {
                countAttacks++;
            }
            if (isInside(chessBoard, row - 1, col + 2) && chessBoard[row - 1, col + 2] == 'K')
            {
                countAttacks++;
            }
            if (isInside(chessBoard, row - 1, col - 2) && chessBoard[row - 1, col - 2] == 'K')
            {
                countAttacks++;
            }
            if (isInside(chessBoard, row + 2, col - 1) && chessBoard[row + 2, col - 1] == 'K')
            {
                countAttacks++;
            }
            if (isInside(chessBoard, row + 2, col + 1) && chessBoard[row + 2, col + 1] == 'K')
            {
                countAttacks++;
            }

            return countAttacks;
        }

        private static void fillMatrix(char[,] chessBoard)
        {
            for (int row = 0; row < chessBoard.GetLength(0); row++)
            {
                char[] currentRow = Console.ReadLine().ToCharArray();
                for (int col = 0; col < chessBoard.GetLength(1); col++)
                {
                    chessBoard[row, col] = currentRow[col];
                }
            }
        }

        public static bool isInside(char[,] chessBoard, int targetRow, int targetCol)
        {
            return targetRow >= 0 && targetRow < chessBoard.GetLength(0) && targetCol >= 0 && targetCol < chessBoard.GetLength(1);
        }

        //private static void printMatrix(char[,] chessBoard)
        //{
        //    for (int row = 0; row < chessBoard.GetLength(0); row++)
        //    {
        //        for (int col = 0; col < chessBoard.GetLength(1); col++)
        //        {
        //            Console.Write(chessBoard[row, col]);
        //        }
        //        Console.WriteLine();
        //    }
        //}
    }
}
