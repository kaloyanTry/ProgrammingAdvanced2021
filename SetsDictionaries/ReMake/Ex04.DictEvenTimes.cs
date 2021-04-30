using System;
using System.Collections.Generic;

namespace _04.DictEvenTimes
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Dictionary<int, int> numsDict = new Dictionary<int, int>();

            for (int i = 0; i < n; i++)
            {
                int num = int.Parse(Console.ReadLine());

                if (!numsDict.ContainsKey(num))
                {
                    numsDict[num] = 0;
                }

                numsDict[num]++;
            }

            foreach (var num in numsDict)
            {
                if (num.Value % 2 == 0)
                {
                    Console.WriteLine(num.Key);
                }
            }
        }
    }
}
