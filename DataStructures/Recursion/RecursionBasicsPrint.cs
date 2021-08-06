using System;

namespace ConsoleApp1
{
    class RecursionBasicsPrint
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Print(n);
        }

        private static void Print(int n)
        {
            //Bottom: when the recursion stops:
            if (n == 0)
            {
                return;
            }

            Console.WriteLine($"{n}: You are simple the best!");

            //The method itself:
            Print(n - 1);
        }
    }
}
