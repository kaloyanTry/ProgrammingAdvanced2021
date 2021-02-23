using System;
using System.Linq;
using System.Collections.Generic;

namespace CoinsSum
{
    class CoinsCountSum
    {
        static void Main(string[] args)
        {
            int[] coins = new int[] { 1, 2, 5, 10, 20, 50 };

            List<int> coinsReturned = new List<int>();

            Console.Write("Write a number and the programm will count how many coints represents the number: ");
            int n = int.Parse(Console.ReadLine());

            int change = 0;
            coins = coins.OrderByDescending(c => c).ToArray();

            while (change < n)
            {
                for (int i = 0; i < coins.Length; i++)
                {
                    if (change + coins[i] <= n)
                    {
                        change += coins[i];
                        coinsReturned.Add(coins[i]);
                        break;
                    }
                }
            }

            Console.WriteLine(string.Join(", ", coinsReturned));
        }
    }
}
