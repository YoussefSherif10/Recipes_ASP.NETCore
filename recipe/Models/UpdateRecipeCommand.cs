using System;
using recipe.Data;
namespace recipe.Models
{
    public class UpdateRecipeCommand : EditRecipeBase
    {
        public int Id { get; set; }

        public void UpdateRecipe(Recipe recipe)
        {
            recipe.Name = Name;
            recipe.TimeToCock = new TimeSpan(TimeToCookHrs, TimeToCookMins, 0);
            recipe.Method = Method;
            recipe.IsVegetarian = IsVegetarian;
            recipe.IsVegan = IsVegan;
        }
    }
}

