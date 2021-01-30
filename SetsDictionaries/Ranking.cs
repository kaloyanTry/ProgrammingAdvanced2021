using System;
using System.Linq;
using System.Collections.Generic;

namespace Ranking
{
    class Ranking
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> contests = new Dictionary<string, string>();
            Dictionary<string, Dictionary<string, int>> submissions = new Dictionary<string, Dictionary<string, int>>();

            string input = Console.ReadLine();
            while (input != "end of contests")
            {
                string[] inputData = input.Split(':');
                string contestTitle = inputData[0];
                string contestPass = inputData[1];

                contests[contestTitle] = contestPass;

                input = Console.ReadLine();
            }

            input = Console.ReadLine();

            while (input != "end of submissions")
            {
                string[] inputData = input.Split("=>");
                string contestTitle = inputData[0];
                string contestPass = inputData[1];
                string userName = inputData[2];
                int userPoints = int.Parse(inputData[3]);

                if (contests.ContainsKey(contestTitle) && contests[contestTitle] == contestPass)
                {
                    if (!submissions.ContainsKey(userName))
                    {
                        submissions[userName] = new Dictionary<string, int>();
                    }

                    if (!submissions[userName].ContainsKey(contestTitle))
                    {
                        submissions[userName][contestTitle] = 0;
                    }

                    if (submissions[userName][contestTitle] < userPoints)
                    {
                        submissions[userName][contestTitle] = userPoints;
                    }
                }

                input = Console.ReadLine();
            }

            int maxPointsUser = 0;
            string maxPointsUserName = string.Empty;

            foreach (var user in submissions)
            {
                int sumPoints = 0;
                foreach (var contest in user.Value)
                {
                    sumPoints += contest.Value;
                }

                if (sumPoints > maxPointsUser)
                {
                    maxPointsUser = sumPoints;
                    maxPointsUserName = user.Key;
                }
            }

            Console.WriteLine($"Best candidate is {maxPointsUserName} with total {maxPointsUser} points.");

            Console.WriteLine("Ranking:");

            foreach (var user in submissions.OrderBy(u => u.Key))
            {
                Console.WriteLine(user.Key);
                
                foreach (var contest in user.Value.OrderByDescending(u => u.Value))
                {
                    Console.WriteLine($"# {contest.Key} -> {contest.Value}");

                }
            }
        }
    }
}
