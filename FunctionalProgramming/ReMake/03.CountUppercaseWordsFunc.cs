using System;
using System.Linq;

namespace _03.CountUppercaseWords
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] text = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();

            Func<string, bool> filterWords = text => char.IsUpper(text[0]);

            text = text.Where(filterWords).ToArray();

            foreach (var word in text)
            {
                Console.WriteLine(word);
            }

            //List<string> upperWordsList = new List<string>();

            //foreach (var word in text)
            //{
            //    char firstLetter = word[0];
            //    if (char.IsUpper(firstLetter))
            //    {
            //        upperWordsList.Add(word);
            //    }
            //}

            //foreach (var word in upperWordsList)
            //{
            //    Console.WriteLine(word);
            //}
        }
    }
}
