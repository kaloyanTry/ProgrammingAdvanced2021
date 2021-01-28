using System;
using System.Collections.Generic;
using System.Linq;

namespace PredicateForName
{
    class PredicateForNames
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<string> names = Console.ReadLine().Split(' ').ToList();

            Func<string, bool> func = name => name.Length <= n;

            names = names.Where(func).ToList();

            Action<List<string>> print = names => Console.WriteLine(string.Join(Environment.NewLine, names));

            print(names);
        }

        static List<int> MyWhere(List<int> numbers, Predicate<int> predicate)
        {
            List<int> newNumbers = new List<int>();

            foreach (int currNum in numbers)
            {
                if (predicate(currNum))
                {
                    newNumbers.Add(currNum);
                }
            }
            return newNumbers;
        }
            
    }
}
