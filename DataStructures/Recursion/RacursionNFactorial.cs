using System;

namespace FactoriealN
{
    class RacursionNFactorial
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            //NFactorial(n);

            Console.WriteLine(NFactorial(n));
        }

        private static int NFactorial(int n)
        {
            if (n == 1)
            {
                return 1;
            }

            return n * NFactorial(n - 1);
        }
    }
}
