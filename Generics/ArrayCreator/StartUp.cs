using System;
using System.Collections.Generic;

namespace GenericArrayCreator
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            List<string>[] array = ArrayCreator.Create(10, new List<string>() { "dimi", "best" });

            foreach (var item in array)
            {
                foreach (var name in item)
                {
                    Console.WriteLine(name);
                }
            }       
        }
    }
}
