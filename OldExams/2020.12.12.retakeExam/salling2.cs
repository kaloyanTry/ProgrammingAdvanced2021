using System;

namespace ExamSelling
{
    class Selling
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            char[,] matrix = new char[n, n];
            int sellerRow = -1;
            int sellerCol = -1;
            int money = 0;

            int firstPillarRow = -1;
            int firstPillarCol = -1;            
            int secondPillarRow = -1;
            int secondPillarCol = -1;

            for (int row = 0; row < n; row++)
            {
                string inputMatrix = Console.ReadLine();
                for (int col = 0; col < n; col++)
                {
                    matrix[row, col] = inputMatrix[col];

                    if (matrix[row, col] == 'S')
                    {
                        sellerRow = row;
                        sellerCol = col;
                    }

                    if (matrix[row, col] == 'O')
                    {
                        if (firstPillarRow == -1)
                        {
                            firstPillarRow = row;
                            firstPillarCol = col;
                        }
                        else
                        {
                            secondPillarRow = row;
                            secondPillarCol = col;
                        }
                    }
                }
            }

            while (true)
            {
                string command = Console.ReadLine();
                matrix[sellerRow, sellerCol] = '-';

                MovingMethod(ref sellerRow, ref sellerCol, command);

                if((sellerRow < 0 || sellerRow >= matrix.GetLength(0)) || (sellerCol < 0 || sellerCol >= matrix.GetLength(1)))
                {
                    Console.WriteLine("Bad news, you are out of the bakery.");
                    break;
                }

                if (char.IsDigit(matrix[sellerRow, sellerCol]))
                {
                    money += int.Parse(matrix[sellerRow, sellerCol].ToString());
                }
                
                if (matrix[sellerRow, sellerCol] == 'O')
                {
                    matrix[sellerRow, sellerCol] = '-';

                    if (firstPillarRow == sellerRow && firstPillarCol == sellerCol)
                    {
                        sellerRow = firstPillarRow;
                        sellerCol = firstPillarCol;
                    }
                    else
                    {
                        sellerRow = secondPillarRow;
                        sellerCol = secondPillarCol;
                    }
                }

                if (money >= 50)
                {
                    Console.WriteLine("Good news! You succeeded in collecting enough money!");      
                    matrix[sellerRow, sellerCol] = 'S';
                    break;
                }
            }

            Console.WriteLine($"Money: {money}");
            PrintMatrix(matrix);
        }

        private static void MovingMethod(ref int sellerRow, ref int sellerCol, string command)
        {
            if (command == "up")
            {
                sellerRow -= 1;
            }
            else if (command == "down")
            {
                sellerRow += 1;
            }
            else if (command == "left")
            {
                sellerCol -= 1;
            }
            else if (command == "right")
            {
                sellerCol += 1;
            }
        }

        private static void PrintMatrix(char[,] matrix)
        {
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
