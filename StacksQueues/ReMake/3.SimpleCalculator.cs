using System;
using System.Collections.Generic;
using System.Linq;

namespace _3.SimpleCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split().ToArray();

            Stack<string> stackCalc = new Stack<string>();

            for (int i = input.Length - 1; i >= 0; i--)
            {
                stackCalc.Push(input[i]);
            }

            while (stackCalc.Count > 1)
            {
                int firstNum = int.Parse(stackCalc.Pop());
                char signCalc = char.Parse(stackCalc.Pop());
                int secondNum = int.Parse(stackCalc.Pop());

                if (signCalc == '+')
                {
                    stackCalc.Push((firstNum + secondNum).ToString());
                }

                if (signCalc == '-')
                {
                    stackCalc.Push((firstNum - secondNum).ToString());
                }
            }

            Console.WriteLine(stackCalc.Pop());
        }
    }
}
