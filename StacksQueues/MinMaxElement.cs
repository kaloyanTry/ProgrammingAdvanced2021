using System;
using System.Linq;
using System.Collections.Generic;

namespace MinMaxElement
{
    class MinMaxElement
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Stack<int> stackInts = new Stack<int>();

            for (int i = 0; i < n; i++)
            {
                string query = Console.ReadLine();

                if (query.Contains("1"))
                {
                    int[] pushElements = query.Split().Select(int.Parse).ToArray();
                    stackInts.Push(pushElements[1]);
                }
                else if (query == "2")
                {
                    if (stackInts.Count != 0)
                    {
                        stackInts.Pop();
                    }
                }
                else if (query == "3")
                {
                    if (stackInts.Count > 0)
                    {
                        Console.WriteLine(stackInts.Max());
                    }
                }
                else if (query == "4")
                {
                    if (stackInts.Count > 0)
                    {
                        Console.WriteLine(stackInts.Min());
                    }
                }
            }

            Console.WriteLine(string.Join(", ", stackInts));
        }
    }
}