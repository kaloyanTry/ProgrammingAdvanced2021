using System;
using System.Linq;
using System.Collections.Generic;

namespace Ranking
{
    class Ranking
    {
        static void Main(string[] args)
        {
            var contests = new Dictionary<string, string>();
            var users = new Dictionary<string, Dictionary<string, int>>();

            string line = Console.ReadLine();
            while (line != "end of contests")
            {
                string[] tokens = line.Split(":").ToArray();
                string contestName = tokens[0];
                string contestPass = tokens[1];

                contests[contestName] = contestPass;

                line = Console.ReadLine();
            }

            line = Console.ReadLine();
            while (line != "end of submissions")
            {
                string[] tokens = line.Split("=>").ToArray();
                string contest = tokens[0];
                string contestPass = tokens[1];
                string username = tokens[2];
                int points = int.Parse(tokens[3]);


                if (contests.ContainsKey(contest) && contests[contest] == contestPass)
                {
                    if (!users.ContainsKey(username))
                    {
                        users[username] = new Dictionary<string, int>();
                    }

                    if (!users[username].ContainsKey(contest))
                    {
                        users[username][contest] = 0;
                    }


                    if (users[username][contest] < points)
                    {
                        users[username][contest] = points;
                    }



                }

                line = Console.ReadLine();
            }

            int maxPoints = 0;
            string maxPointsUser = "";
            foreach (var user in users)
            {
                int sum = 0;
                foreach (var contest in user.Value)
                {
                    sum += contest.Value;
                }

                if (sum > maxPoints)
                {
                    maxPoints = sum;
                    maxPointsUser = user.Key;
                }
            }

            Console.WriteLine($"Best candidate is {maxPointsUser} with total {maxPoints} points.");
            Console.WriteLine("Ranking:");
            foreach (var user in users.OrderBy(x => x.Key))
            {
                Console.WriteLine(user.Key);
                foreach (var contest in user.Value.OrderByDescending(x => x.Value))
                {
                    Console.WriteLine($"#  {contest.Key} -> {contest.Value}");
                }
            }
        }
    }
}