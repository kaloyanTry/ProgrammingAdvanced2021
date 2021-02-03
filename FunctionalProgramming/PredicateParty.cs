using System;
using System.Collections.Generic;
using System.Linq;

namespace PredicateParty
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> names = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList();

            string command = Console.ReadLine();

            while (command != "Party!")
            {
                string[] inputData = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                Func<string, bool> filter = CteateFilter(inputData);

                if (inputData[0] == "Double")
                {
                    for (int i = 0; i < names.Count; i++)
                    {
                        if (filter(names[i]))
                        {
                            names.Insert(i + 1, names[i]);
                            i++;
                        }
                    }
                }
                else if (inputData[0] == "Remove")
                {
                    for (int i = 0; i < names.Count; i++)
                    {
                        if (filter(names[i]))
                        {
                            names.RemoveAt(i);
                            i--;
                        }

                    }
                }
                command = Console.ReadLine();
            }

            if (names.Count == 0)
            {
                Console.WriteLine("Nobody is going to the party!");
            }
            else
            {
                Console.WriteLine(string.Join(", ", names) + " are going to the party!");
            }
        }

        private static Func<string, bool> CteateFilter(string[] inputData)
        {
            if (inputData[1] == "StartsWith")
            {
                return x => x.StartsWith(inputData[2]);
            }
            if (inputData[1] == "EndsWith")
            {
                return x => x.EndsWith(inputData[2]);
            }

            return x => x.Length == int.Parse(inputData[2]);
        }
    }
}
