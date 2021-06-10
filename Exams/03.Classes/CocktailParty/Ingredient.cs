using System;
using System.Text;

namespace CocktailParty
{
    public class Ingredient
    {
        public Ingredient(string name, int alcohol, int quantity)
        {
            Name = name;
            Alcohol = alcohol;
            Quantity = quantity;
        }

        public string Name { get; set; }
        public int Alcohol { get; set; }
        public int Quantity { get; set; }

        public override string ToString()
        {
            StringBuilder strBuild = new StringBuilder();
            strBuild.AppendLine($"Ingredient: {Name}");
            strBuild.AppendLine($"Quantity: {Quantity}");
            strBuild.AppendLine($"Alcohol: {Alcohol}");
            
            return strBuild.ToString().Trim();
        }
    }
}
