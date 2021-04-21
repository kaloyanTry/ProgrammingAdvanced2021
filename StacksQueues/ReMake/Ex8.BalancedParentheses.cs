using System;
using System.Collections.Generic;
using System.Linq;

namespace Ex8.BalancedParentheses
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            Stack<char> bracketsStack = new Stack<char>();

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == '{')
                {
                    bracketsStack.Push(input[i]);
                }

                if (input[i] == '(')
                {
                    bracketsStack.Push(input[i]);
                }

                if (input[i] == '[')
                {
                    bracketsStack.Push(input[i]);
                }

                if (input[i] == '}')
                {
                    if (bracketsStack.Any() && bracketsStack.Peek() == '{')
                    {
                        bracketsStack.Pop();
                    }
                    else
                    {
                        Console.WriteLine("NO");
                        return;
                    }
                }

                if (input[i] == ')')
                {
                    if (bracketsStack.Any() && bracketsStack.Peek() == '(')
                    {
                        bracketsStack.Pop();
                    }
                    else
                    {
                        Console.WriteLine("NO");
                        return;
                    }
                }

                if (input[i] == ']')
                {
                    if (bracketsStack.Any() && bracketsStack.Peek() == '[')
                    {
                        bracketsStack.Pop();
                    }
                    else
                    {
                        Console.WriteLine("NO");
                        return;
                    }
                }
            }

            if (bracketsStack.Any())
            {
                Console.WriteLine("NO");
            }
            else
            {
                Console.WriteLine("YES");
            }
        }
    }
}
