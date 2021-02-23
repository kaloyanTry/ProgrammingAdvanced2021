using System;

namespace FactoialN
{
    class FactorialN
    {
        static void Main(string[] args)
        {
            Console.Write("Please write a number: ");
            int n = int.Parse(Console.ReadLine());

            Console.Write($"The factorial of the number {n}! = ");
            Console.WriteLine(Factorial(n));
        }

        private static long Factorial(int n)
        {
            if (n == 0)
            {
                return 1;
            }

            return n * Factorial(n - 1);
        }
    }
}