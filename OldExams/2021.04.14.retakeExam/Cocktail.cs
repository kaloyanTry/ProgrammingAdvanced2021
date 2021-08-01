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

        public int CurrentAlcoholLevel => Ingredients.Sum(i => i.Alcohol);

        public void Add(Ingredient ingredient)
        {
            int amountOfAlcohol = 0;
            int amountOfQuantity = 0;

            foreach (var ingred in Ingredients.Where(i => i.Name != ingredient.Name))
            {
                if (ingred.Alcohol + amountOfAlcohol < MaxAlcoholLevel)
                {
                    amountOfAlcohol += ingred.Alcohol;
                }

                if (ingred.Quantity + amountOfQuantity < Capacity)
                {
                    amountOfQuantity += ingred.Quantity;
                }
            }

            if (!Ingredients.Contains(ingredient) && (MaxAlcoholLevel > amountOfAlcohol && Capacity > amountOfQuantity))
            {
                Ingredients.Add(ingredient);
            }
        }

        public bool Remove(string name)
        {
            Ingredient ingredient = Ingredients.FirstOrDefault(i => i.Name == name);

            if (ingredient == null)
            {
                return false;
            }

            Ingredients.Remove(ingredient);
            return true;
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

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Cocktail: {Name} - Current Alcohol Level: {CurrentAlcoholLevel}");

            foreach (var ingredient in Ingredients)
            {
                sb.AppendLine(ingredient.ToString());
            }

            return sb.ToString().Trim();
        }
    }
}
