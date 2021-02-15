using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Guild
{
    public class Guild
    {
        private List<Player> roster;

        public Guild(string name, int capacity)
        {
            this.Name = name;
            this.Capacity = capacity;
            this.roster = new List<Player>();
        }

        public string Name { get; set; }

        public int Capacity { get; set; }

        public int Count => roster.Count;


        public void AddPlayer(Player player)
        {
            if (roster.Count < Capacity)
            {
                roster.Add(player);
            }
        }

        public bool RemovePlayer(string name)
        {
            Player player = roster.Where(p => p.Name == name).FirstOrDefault();
            if (player != null)
            {
                roster.Remove(player);
                return true;
            }
            else
            {
                return false;
            }
        }

        public void PromotePlayer(string name)
        {
            if (roster.Any(x => x.Name == name))
            {
                Player player = roster.Where(x => x.Name == name).FirstOrDefault();

                player.Rank = "Member";
            }
        }

        public void DemotePlayer(string name)
        {
            if (roster.Any(x => x.Name == name))
            {
                Player player = roster.Where(x => x.Name == name).FirstOrDefault();
                player.Rank = "Trial";
            }
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Players in the guild: {Name}");
            foreach (var player in roster)
            {
                sb.AppendLine(player.ToString());
            }
            return sb.ToString().TrimEnd();
        }

        public Player[] KickPlayersByClass(string classy)
        {

            List<Player> myListTemp = new List<Player>();
            foreach (var player in this.roster)
            {
                if (player.Class == classy)
                {
                    myListTemp.Add(player);
                }
            }
            Player[] myArrayToReturn = myListTemp.ToArray();

            this.roster = this.roster.Where(x => x.Class != classy).ToList();

            return myArrayToReturn;
        }
    }
}