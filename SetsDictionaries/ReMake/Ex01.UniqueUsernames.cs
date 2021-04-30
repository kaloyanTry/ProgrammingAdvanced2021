using System;
using System.Collections.Generic;

namespace Ex01.UniqueUsernames
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            HashSet<string> usernamesSet = new HashSet<string>();

            for (int i = 0; i < n; i++)
            {
                string name = Console.ReadLine();
                usernamesSet.Add(name);
            }

            foreach (var user in usernamesSet)
            {
                Console.WriteLine(user);
            }
        }
    }
}
