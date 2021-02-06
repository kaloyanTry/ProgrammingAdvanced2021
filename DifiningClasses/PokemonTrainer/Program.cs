using System;
using System.Collections.Generic;
using System.Linq;

namespace PokemonTrainerExercise
{
    public class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Trainer> trainers = new Dictionary<string, Trainer>();

            string input = Console.ReadLine();
            while (input != "Tournament")
            {
                string[] data = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string trainerName = data[0];
                string pokemonName = data[1];
                string pokemonElement = data[2];
                int pokemonHealth = int.Parse(data[3]);

                if (!trainers.ContainsKey(trainerName))
                {
                    trainers[trainerName] = new Trainer(trainerName);
                }

                trainers[trainerName].Pokemon.Add(new Pokemon(pokemonName, pokemonElement, pokemonHealth));

                input = Console.ReadLine();
            }

            input = Console.ReadLine();
            while (input != "End")
            {
                foreach (var trainer in trainers)
                {
                    trainer.Value.CheckPokemonToBeAnElement(input);
                }

                input = Console.ReadLine();
            }

            foreach (var trainer in trainers.OrderByDescending(t => t.Value.Badges))
            {
                Console.WriteLine(trainer.Value);
            }
        }
    }
}
