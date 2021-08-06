using System;

namespace RacursionFIbonacci
{
    class RacursionFibonacci
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Console.WriteLine(Fibonacci(n));
        }

        private static int Fibonacci(int n)
        {
            if (n == 0)
            {
                return 0;
            }

            if (n == 1 || n == 2)
            {
                return 1;
            }

            return Fibonacci(n - 1) + Fibonacci(n - 2);
        }
    }
}
