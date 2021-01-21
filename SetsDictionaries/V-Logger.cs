using System;
using System.Linq;
using System.Collections.Generic;

namespace V_Logger
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, SortedSet<string>>> app = new Dictionary<string, Dictionary<string, SortedSet<string>>>();

            string commandInput = Console.ReadLine();
            while (commandInput != "Statistics")
            {
                string[] commandData = commandInput.Split(" ");
                string vlogerName = commandData[0];
                string command = commandData[1];

                if (command == "joined")
                {
                    if (!app.ContainsKey(vlogerName))
                    {
                        app.Add(vlogerName, new Dictionary<string, SortedSet<string>>());
                        app[vlogerName].Add("following", new SortedSet<string>());
                        app[vlogerName].Add("followers", new SortedSet<string>());
                    }
                }
                else if (command == "followed")
                {
                    string vloggerSecond = commandData[2];
                    if (app.ContainsKey(vlogerName) && app.ContainsKey(vloggerSecond) && vlogerName != vloggerSecond)
                    {
                        app[vlogerName]["following"].Add(vloggerSecond);
                        app[vloggerSecond]["followers"].Add(vlogerName);
                    }
                }
                commandInput = Console.ReadLine();
            }

            Dictionary<string, Dictionary<string, SortedSet<string>>> sortedApp = app.OrderByDescending(k => k.Value["followers"].Count).ThenBy(f => f.Value["following"].Count).ToDictionary(k => k.Key, k => k.Value);

            int counter = 0;
            Console.WriteLine($"The V-Logger has a total of {app.Count} vloggers in its logs.");
            foreach (var item in sortedApp)
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
