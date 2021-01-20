using System;
using System.Linq;
using System.Collections.Generic;

namespace SoftUniParty
{
    class SoftUniParty
    {
        static void Main(string[] args)
        {
            HashSet<string> vipGuests = new HashSet<string>();
            HashSet<string> regularGuests = new HashSet<string>();

            string input = Console.ReadLine();

            while (input != "PARTY")
            {
                if (input[0] >= '0' && input[0] <= '9')
                {
                    vipGuests.Add(input);
                }
                else
                {
                    regularGuests.Add(input);
                }
                input = Console.ReadLine();
            }

            int allGuests = vipGuests.Count + regularGuests.Count;
            input = Console.ReadLine();

            while (input != "END")
            {
                if (input[0] >= '0' && input[0] <= '9')
                {
                    if (vipGuests.Contains(input))
                    {
                        vipGuests.Remove(input);
                        allGuests--;
                    }
                }
                else
                {
                    if (regularGuests.Contains(input))
                    {
                        regularGuests.Remove(input);
                        allGuests--;
                    }
                }
                input = Console.ReadLine();
            }

            Console.WriteLine(allGuests);
            if (vipGuests.Any())
            {
                Console.WriteLine(string.Join('\n', vipGuests));
            }
            if (regularGuests.Any())
            {
                Console.WriteLine(string.Join('\n', regularGuests));
            }
        }
    }
}
