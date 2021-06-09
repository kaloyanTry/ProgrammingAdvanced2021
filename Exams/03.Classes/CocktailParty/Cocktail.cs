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
            Ingredient currentIngregient = Ingredients.FirstOrDefault(i => i.Name == ingredient.Name);
            int amountAlcohol = 0;
            int amountQuantity = 0;
            foreach (var alc in Ingredients.Where(i => i.Name != ingredient.Name))
            {
                if (alc.Alcohol < MaxAlcoholLevel)
                {
                    amountAlcohol += alc.Alcohol;
                }

                if (alc.Quantity < Capacity)
                {
                    amountQuantity += alc.Quantity;
                }
            }

            if (currentIngregient == null && (MaxAlcoholLevel > amountAlcohol && Capacity >  amountQuantity))
            {
                if (MaxAlcoholLevel > amountAlcohol && Capacity >  amountQuantity)
                {
                    Ingredients.Add(ingredient);
                }         
            }
        }

        public bool Remove(string name)
        {
            Ingredient ingredient = Ingredients.FirstOrDefault(i => i.Name == name);
            if ( Ingredients.Remove(ingredient))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public Ingredient FindIngredient(string name)
        {
            Ingredient ingredient = Ingredients.Find(i => i.Name == name);

            if (ingredient == null)
            {
                return null;
            }

            return ingredient;
            //return Ingredients.Contains(ingredient) ? ingredient : null;
        }

        public Ingredient GetMostAlcoholicIngredient()
        {
            Ingredient mostAlcoholicIngredient = Ingredients.OrderByDescending(i => i.Alcohol).FirstOrDefault();

            return mostAlcoholicIngredient;
        }

        public int CurrentAlcoholLevel()
        {
            int amountAlc = 0;
            foreach (var itemAlc  in Ingredients)
            {
                amountAlc += itemAlc.Alcohol;
            }
            return amountAlc;
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Cocktail: {Name} - Current Alcohol Level: {CurrentAlcoholLevel()}");

            foreach (var ingredient in Ingredients)
            {
                sb.AppendLine(ingredient.ToString());
            }

            return sb.ToString().Trim();
        }
    }
}
