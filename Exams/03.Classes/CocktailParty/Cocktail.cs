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
            Ingredient currIngredient = Ingredients.FirstOrDefault(i => i.Name == ingredient.Name);

            if (currIngredient == null && ingredient.Quantity < Capacity && ingredient.Alcohol < MaxAlcoholLevel)
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

            return true;
        }

        public Ingredient FindIngredient(string name)
        {
            Ingredient ingredient = Ingredients.FirstOrDefault(i => i.Name == name);
            if (ingredient == null)
            {
                return null;
            }

            return ingredient;
        }

        public Ingredient GetMostAlcoholicIngredient()
        {
            Ingredient mostAlcoholicIngredient = Ingredients.OrderByDescending(i => i.Alcohol).FirstOrDefault();

            return mostAlcoholicIngredient;
        }

        //public int CurrentAlcoholLevel()
        //{
        //    int amountAlcohol = 0;

        //    foreach (var coctail in Ingredients)
        //    {
        //        amountAlcohol += coctail.Alcohol;
        //    }

        //    return amountAlcohol;
        //}

        public int CurrentAlcoholLevel => Ingredients.Capacity;

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Cocktail: {Name} - Current Alcohol Level: {CurrentAlcoholLevel}");

            foreach (var ingredient in Ingredients)
            {
                Console.WriteLine(ingredient);
            }

            return sb.ToString().Trim();
        }
    }
}
