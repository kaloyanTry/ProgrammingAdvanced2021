using System;
using System.Collections.Generic;
using System.Text;

namespace Ex9.SimpleTextEditor
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Stack<string> stackText = new Stack<string>();
            StringBuilder text = new StringBuilder();

            for (int i = 0; i < n; i++)
            {
                string[] cmdInput = Console.ReadLine().Split();
                string command = cmdInput[0];

                if (command == "1")
                {
                    stackText.Push(text.ToString());
                    text.Append(cmdInput[1]);
                }
                else if (command == "2")
                {
                    int index = int.Parse(cmdInput[1]);
                    stackText.Push(text.ToString());
                    text.Remove(text.Length - index, index);
                }
                else if (command == "3")
                {
                    int index = int.Parse(cmdInput[1]);
                    Console.WriteLine(text[index - 1]);
                }
                else if (command == "4")
                {
                    if (stackText.Count > 0)
                    {
                        text.Clear();
                        text.Append(stackText.Pop());
                    }
                    
                }
            }
        }
    }
}
