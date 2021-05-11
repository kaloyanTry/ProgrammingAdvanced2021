using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.CountUppercaseWords
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] inputText = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();

            List<string> upperWordsList = new List<string>();

            foreach (var word in inputText)
            {
                char firstLetter = word[0];
                if (char.IsUpper(firstLetter))
                {
                    upperWordsList.Add(word);
                }
            }

            foreach (var word in upperWordsList)
            {
                Console.WriteLine(word);
            }
        }
    }
}
