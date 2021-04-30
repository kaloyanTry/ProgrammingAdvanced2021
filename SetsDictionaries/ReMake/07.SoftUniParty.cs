using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.SoftUniParty
{
    class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> vipTypes = new HashSet<string>();
            HashSet<string> regularTypes = new HashSet<string>();

            string input = Console.ReadLine();
            while (input != "PARTY")
            {
                if (input[0] >= '0' && input[0] <= '9')
                {
                    vipTypes.Add(input);
                }
                else
                {
                    regularTypes.Add(input);
                }

                input = Console.ReadLine();
            }

            int allTypes = vipTypes.Count + regularTypes.Count;

            input = Console.ReadLine();
            while (input != "END")
            {
                if (input[0] >= '0' && input[0] <= '9')
                {
                    vipTypes.Remove(input);
                    allTypes--;
                }
                else
                {
                    regularTypes.Remove(input);
                    allTypes--;
                }

                input = Console.ReadLine();
            }

            Console.WriteLine(allTypes);

            if (vipTypes.Any())
            {
                foreach (var vip in vipTypes)
                {
                    Console.WriteLine(vip);
                }
            }

            if (regularTypes.Any())
            {
                foreach (var regular in regularTypes)
                {
                    Console.WriteLine(regular);
                }
            }
        }
    }
}
