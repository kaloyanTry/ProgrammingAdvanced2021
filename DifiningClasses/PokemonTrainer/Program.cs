using System;
using System.Linq;
using System.Collections.Generic;

namespace PokemonTrainer
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Trainer> trainers = new Dictionary<string, Trainer>();

            string line = Console.ReadLine();

            while (line != "Tournament")
            {
                string[] tokens = line.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();

                if (!trainers.ContainsKey(tokens[0]))
                {
                    trainers[tokens[0]] = new Trainer(tokens[0]);
                }

                trainers[tokens[0]].Pokemon.Add(new Pokemon(tokens[1], tokens[2], int.Parse(tokens[3])));

                line = Console.ReadLine();
            }

            line = Console.ReadLine();
            while (line != "End")
            {
                foreach (var trainer in trainers)
                {
                    trainer.Value.CheckPokemonToBeAnElement(line);
                }
                line = Console.ReadLine();
            }

            foreach (var kvp in trainers.OrderByDescending(x => x.Value.Badges))
            {
                Console.WriteLine(kvp.Value);
            }
        }
    }
}
