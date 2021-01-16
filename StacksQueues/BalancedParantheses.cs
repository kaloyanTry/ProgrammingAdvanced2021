using System;
using System.Linq;
using System.Collections.Generic;

namespace BalancedParantheses
{
    class BalancedParantheses
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            Stack<char> brackets = new Stack<char>();

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == '{')
                {
                    brackets.Push(input[i]);
                }

                if (input[i] == '[')
                {
                    brackets.Push(input[i]);
                }

                if (input[i] == '(')
                {
                    brackets.Push(input[i]);
                }

                if (input[i] == '}')
                {
                    if (brackets.Any() && brackets.Peek() == '{')
                    {
                        brackets.Pop();
                    }
                    else
                    {
                        Console.WriteLine("NO");
                        return;
                    }
                }

                if (input[i] == ']')
                {
                    if (brackets.Any() && brackets.Peek() == '[')
                    {
                        brackets.Pop();
                    }
                    else
                    {
                        Console.WriteLine("NO");
                        return;
                    }
                }

                if (input[i] == ')')
                {
                    if (brackets.Any() && brackets.Peek() == '(')
                    {
                        brackets.Pop();
                    }
                    else
                    {
                        Console.WriteLine("NO");
                        return;
                    }
                }
            }

            if (brackets.Any())
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
