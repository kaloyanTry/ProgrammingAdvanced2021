using System;
using System.Collections.Generic;
using System.Linq;

namespace Ex01.ActionPoint
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> inputNames = Console.ReadLine().Split().ToList();

            Action<string> printNames = x => Console.WriteLine(x);

            inputNames.ForEach(printNames);
        }
    }
}
