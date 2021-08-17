using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CocktailParty
{
    public class Cocktail
    {
        private List<Ingredient> Ingredients;

        public Cocktail(string name, int capacity, int maxAlcoholLevel)
        {
            Name = name;
            Capacity = capacity;
            MaxAlcoholLevel = maxAlcoholLevel;
            Ingredients = new List<Ingredient>();
        }

        public string Name { get; set; }
        public int Capacity { get; set; }
        public int MaxAlcoholLevel { get; set; }

        public void Add(Ingredient ingredient)
        {     
            if (!Ingredients.Contains(ingredient))
            {
                if (Ingredients.Sum(i => i.Alcohol) <= MaxAlcoholLevel || Ingredients.Sum(i => i.Quantity) <= Capacity)
                {
                    Ingredients.Add(ingredient);
                }
            }
        }

        public bool Remove(string name)
        {
            Ingredient ingredient = Ingredients.FirstOrDefault(i => i.Name == name);

            return Ingredients.Remove(ingredient);
        }


        public Ingredient FindIngredient(string name)
        {
            Ingredient ingredient = Ingredients.FirstOrDefault(i => i.Name == name);

            return ingredient;
        }

        public Ingredient GetMostAlcoholicIngredient()
        {
            Ingredient ingredient = Ingredients.OrderByDescending(i => i.Alcohol).FirstOrDefault();

            return ingredient;
        }

        public int CurrentAlcoholLevel => Ingredients.Sum(i => i.Alcohol);

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Cocktail: {Name} - Current Alcohol Level: {CurrentAlcoholLevel}");

            foreach (var ingradient in Ingredients)
            {
                sb.AppendLine(ingradient.ToString());
            }

            return sb.ToString().Trim();
        }
    }
}
