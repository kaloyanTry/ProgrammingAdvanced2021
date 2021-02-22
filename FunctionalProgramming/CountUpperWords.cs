using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleFunctional
{
    class ProgramFunctional
    {
        static void Main(string[] args)
        {
            //input:
            string text = Console.ReadLine();

            //Func:
            Func<string, bool> filter = text => Char.IsUpper(text[0]);

            string[] words = text.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            
            words = words.Where(filter).ToArray();

            //Print:
            foreach (var word in words)
            {
                Console.WriteLine(word);
            }
        }
    }
}
