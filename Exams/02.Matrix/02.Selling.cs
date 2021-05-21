using System;

namespace _02.Selling
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            char[,] matrix = new char[n, n];
            int sellerRow = -1;
            int sellerCol = -1;
            int money = 0;

            //Fill the matrix and get the input:
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                string input = Console.ReadLine();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = input[col];

                    if (matrix[row, col] == 'S')
                    {
                        sellerRow = row;
                        sellerCol = col;
                    }
                }
            }

            //Move seller:
            while (true)
            {
                string input = Console.ReadLine();

                matrix[sellerRow, sellerCol] = '-';

                if (input == "up")
                {
                    sellerRow -= 1;
                }
                else if (input == "down")
                {
                    sellerRow += 1;
                }
                else if (input == "left")
                {
                    sellerCol -= 1;
                }
                else if (input == "right")
                {
                    sellerCol += 1;
                }

                bool isOutside = sellerRow < 0 
                                 || sellerRow >= matrix.GetLength(0) 
                                 || sellerCol < 0 
                                 || sellerCol >= matrix.GetLength(1);
                if (isOutside)
                {
                    Console.WriteLine("Bad news, you are out of the bakery.");
                    break;
                }

                if (char.IsDigit(matrix[sellerRow, sellerCol]))
                {
                    money += int.Parse(matrix[sellerRow, sellerCol].ToString());
                }

                if (money >= 50)
                {
                    Console.WriteLine("Good news! You succeeded in collecting enough money!");
                    matrix[sellerRow, sellerCol] = 'S';
                    break;
                }

                if (matrix[sellerRow, sellerCol] == 'O')
                {
                    matrix[sellerRow, sellerCol] = '-';

                    for (int row = 0; row < matrix.GetLength(0); row++)
                    {
                        for (int col = 0; col < matrix.GetLength(1); col++)
                        {
                            if (matrix[row, col] == 'O')
                            {
                                sellerRow = row;
                                sellerCol = col;
                            }
                        }
                    }
                }
            }

            Console.WriteLine($"Money: {money}");
            //Print the matrix:
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
