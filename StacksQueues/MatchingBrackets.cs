using System;
using System.Collections.Generic;

namespace MatchingBrackets
{
    class MatchingBrackets
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            Stack<int> bracetIndexes = new Stack<int>();

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == '(')
                {
                    bracetIndexes.Push(i);
                }

                if (input[i] == ')')
                {
                    int startIndex = bracetIndexes.Pop();
                    Console.WriteLine(input.Substring(startIndex, i - startIndex + 1));
                }
            }
        }
    }
}
