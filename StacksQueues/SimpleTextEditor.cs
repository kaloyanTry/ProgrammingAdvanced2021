using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleTextEditor
{
    class SimpleTextEditor
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            string text = string.Empty;
            Stack<string> historyStack = new Stack<string>();

            for (int i = 0; i < n; i++)
            {
                string[] command = Console.ReadLine().Split().ToArray();

                switch (command[0])
                {
                    case "1":
                        historyStack.Push(text);
                        StringBuilder sb = new StringBuilder(text);
                        sb.Append(command[1]);
                        text = sb.ToString();
                        break;
                    case "2":
                        historyStack.Push(text);
                        int toRemove = int.Parse(command[1]);
                        text = text.Remove(text.Length - toRemove);
                        break;
                    case "3":
                        int index = int.Parse(command[1]);
                        Console.WriteLine(text[index - 1]);
                        break;
                    case "4":
                        text = historyStack.Pop();
                        break;
                }
            }
        }
    }
}
