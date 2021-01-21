using System;
using System.Linq;
using System.Collections.Generic;

namespace EvenTimes
{
    class EvenTimes
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Dictionary<int, int> numbers = new Dictionary<int, int>();

            for (int i = 0; i < n; i++)
            {
                int num = int.Parse(Console.ReadLine());
                
                if (!numbers.ContainsKey(num))
                {
                    numbers[num] = 0;
                }

                numbers[num]++;
            }

            foreach (var num in numbers)
            {
                if (num.Value % 2 == 0)
                {
                    Console.WriteLine(num.Key);
                    break;
                }
            }
        }
    }
}
