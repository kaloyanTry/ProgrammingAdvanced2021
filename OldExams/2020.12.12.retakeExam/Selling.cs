using System;
using System.Collections.Generic;
using System.Linq;

namespace Selling
{
    class Selling
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            char[,] matrix = new char[n, n];

            int rowSeller = 0;
            int colSeller = 0;
            int money = 0;

            for (int row = 0; row < n; row++)
            {
                string input = Console.ReadLine();
                for (int col = 0; col < n; col++)
                {
                    matrix[row, col] = input[col];
                    if (matrix[row, col] == 'S')
                    {
                        rowSeller = row;
                        colSeller = col;
                    }
                }
            }

            while (true)
            {
                string command = Console.ReadLine();
                if (command == "up")
                {
                    matrix[rowSeller, colSeller] = '-'; 
                    rowSeller -= 1; 
                    if (rowSeller >= 0) 
                    {
                        SnakeMoves(n, matrix, ref rowSeller, ref colSeller, ref money);
                    }
                    else 
                    {
                        Console.WriteLine("Bad news, you are out of the bakery.");
                        Console.WriteLine($"Money: {money}");
                        break;
                    }
                }
                else if (command == "down")
                {
                    matrix[rowSeller, colSeller] = '-'; 
                    rowSeller += 1;
                    if (rowSeller < n) 
                    {
                        SnakeMoves(n, matrix, ref rowSeller, ref colSeller, ref money);
                    }
                    else 
                    {
                        Console.WriteLine("Bad news, you are out of the bakery.");
                        Console.WriteLine($"Money: {money}");
                        break;
                    }
                }
                else if (command == "left")
                {
                    matrix[rowSeller, colSeller] = '-'; 
                    colSeller = colSeller - 1; 
                    if (colSeller >= 0) 
                    {
                        SnakeMoves(n, matrix, ref rowSeller, ref colSeller, ref money);
                    }
                    else 
                    {
                        Console.WriteLine("Bad news, you are out of the bakery.");
                        Console.WriteLine($"Money: {money}");
                        break;
                    }
                }
                else if (command == "right")
                {
                    matrix[rowSeller, colSeller] = '-'; 
                    colSeller = colSeller + 1; 
                    if (colSeller < n) 
                    {
                        SnakeMoves(n, matrix, ref rowSeller, ref colSeller, ref money);
                    }
                    else
                    {
                        Console.WriteLine("Bad news, you are out of the bakery.");
                        Console.WriteLine($"Money: {money}");
                        break;
                    }
                }

                if (money >= 50)
                {
                    Console.WriteLine("Good news! You succeeded in collecting enough money!");
                    Console.WriteLine($"Money: {money}");
                    matrix[rowSeller, colSeller] = 'S';
                    break;
                }

            }
            PrintMatrix(n, matrix);
        }

        private static void SnakeMoves(int n, char[,] matrix, ref int row, ref int col, ref int money)
        {
            if (char.IsDigit(matrix[row, col]))
            {
                money += int.Parse(matrix[row, col].ToString());
            }
            else if (matrix[row, col] == 'O')
            {
                matrix[row, col] = '-';
                for (int rows = 0; rows < n; rows++)
                {
                    for (int cols = 0; cols < n; cols++)
                    {
                        if (matrix[rows, cols] == 'O')
                        {
                            matrix[rows, cols] = '-';
                            row = rows;
                            col = cols;
                        }
                    }
                }
            }
        }

        public static void PrintMatrix(int n, char[,] matrix)
        {
            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < n; col++)
                {
                    Console.Write(matrix[row, col]);
                }
                Console.WriteLine();
            }
        }
    }
}