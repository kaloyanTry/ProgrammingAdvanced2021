using System;
using System.Collections.Generic;
using System.Linq;

namespace Ex07.VLogger
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, SortedSet<string>>> vloggers = new Dictionary<string, Dictionary<string, SortedSet<string>>>();

            string commandInput = Console.ReadLine();
            while (commandInput != "Statistics")
            {
                string[] commandData = commandInput.Split(" ");
                string vlogerName = commandData[0];
                string command = commandData[1];

                if (command == "joined")
                {
                    if (!vloggers.ContainsKey(vlogerName))
                    {
                        vloggers.Add(vlogerName, new Dictionary<string, SortedSet<string>>());
                        vloggers[vlogerName].Add("following", new SortedSet<string>());
                        vloggers[vlogerName].Add("followers", new SortedSet<string>());
                    }
                }
                else if (command == "followed")
                {
                    string vloggerSecond = commandData[2];
                    if (vloggers.ContainsKey(vlogerName) && vloggers.ContainsKey(vloggerSecond) && vlogerName != vloggerSecond)
                    {
                        vloggers[vlogerName]["following"].Add(vloggerSecond);
                        vloggers[vloggerSecond]["followers"].Add(vlogerName);
                    }
                }
                commandInput = Console.ReadLine();
            }

            Dictionary<string, Dictionary<string, SortedSet<string>>> sortedVloggers = vloggers.OrderByDescending(k => k.Value["followers"].Count).ThenBy(f => f.Value["following"].Count).ToDictionary(k => k.Key, k => k.Value);

            int counter = 0;

            Console.WriteLine($"The V-Logger has a total of {vloggers.Count} vloggers in its logs.");

            foreach (var item in sortedVloggers)
            {
                int followersCount = item.Value["followers"].Count;
                int followingCount = item.Value["following"].Count;

                Console.WriteLine($"{++counter}. {item.Key} : {followersCount} followers, {followingCount} following");

                if (counter == 1)
                {
                    foreach (var follower in item.Value["followers"])
                    {
                        Console.WriteLine($"*  {follower}");
                    }
                }
            }
        }
    }
}
