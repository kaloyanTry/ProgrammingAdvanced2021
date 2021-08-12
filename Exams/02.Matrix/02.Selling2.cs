using System;
using System.Linq;

namespace _02.ProblemMatrix2
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            
            char[,] matrix = new char [n, n];
            int bakeryRow = -1;
            int bakeryCol = -1;
            int money = 0;
            bool isOutOfBakery = false;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                string data = Console.ReadLine();
                
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = data[col];

                    if (matrix[row, col] == 'S')
                    {
                        bakeryRow = row;
                        bakeryCol = col;
                    }
                }
            }
        
            while (true)
            {
                string command = Console.ReadLine();

                matrix[bakeryRow, bakeryCol] = '-';

                if (command == "up")
                {
                    bakeryRow--;
                }
                else if (command == "down")
                {
                    bakeryRow++;
                }
                else if (command == "left")
                {
                    bakeryCol--;
                }
                else if (command == "right")
                {
                    bakeryCol++;
                }

                if (bakeryRow < 0 || bakeryRow >= matrix.GetLength(0) || bakeryCol < 0 || bakeryCol >= matrix.GetLength(1))
                {
                    isOutOfBakery = true;
                    break;
                }

                if (char.IsDigit(matrix[bakeryRow, bakeryCol]))
                {
                    money += int.Parse(matrix[bakeryRow, bakeryCol].ToString());
                }
                
                if (money >= 50)
                {
                    Console.WriteLine("Good news! You succeeded in collecting enough money!");
                    matrix[bakeryRow, bakeryCol] = 'S';
                    break;
                }

                if (matrix[bakeryRow, bakeryCol] == 'O')
                {
                    matrix[bakeryRow, bakeryCol] = '-';
                    for (int row = 0; row < matrix.GetLength(0); row++)
                    {
                        for (int col = 0; col < matrix.GetLength(1); col++)
                        {
                            if (matrix[row, col] == 'O')
                            {
                                bakeryRow = row;
                                bakeryCol = col;
                            }
                        }
                    }
                }
            }

            if (isOutOfBakery)
            {
                Console.WriteLine("Bad news, you are out of the bakery.");
            }

            Console.WriteLine($"Money: {money}");
            
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col]);
                }
                Console.WriteLine();
            }
        }
    }
}
