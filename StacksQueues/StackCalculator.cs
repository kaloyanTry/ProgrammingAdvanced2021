using System;
using System.Collections.Generic;

namespace SimpleCalculator
{
    class StackCalculator
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split();

            Stack<string> expression = new Stack<string>();

            for (int i = input.Length - 1;  i >= 0; i--)
            {
                expression.Push(input[i]);
            }

            while (expression.Count > 1)
            {
                int leftNumber = int.Parse(expression.Pop());
                string sign = expression.Pop();
                int rightNumber = int.Parse(expression.Pop());


                if (sign == "+")
                {
                    expression.Push((leftNumber + rightNumber).ToString());
                }
                else if (sign == "-")
                {
                    expression.Push((leftNumber - rightNumber).ToString());
                }
            }

            Console.WriteLine(expression.Pop());
        }
    }
}
