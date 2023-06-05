using System;
using recipe.Data;
namespace recipe.Models
{
	public class CreateRecipeCommand : EditRecipeBase
	{
		public List<CreateIngredientCommand> Ingredients = new List<CreateIngredientCommand>();

		public Recipe ToRecipe()
		{
			return new Recipe
			{
				Name = Name,
				TimeToCock = new TimeSpan(TimeToCookHrs, TimeToCookMins, 0),
				Method = Method,
				IsVegan = IsVegan,
				IsVegetarian = IsVegetarian,
				Ingredients = Ingredients?.Select(x=>x.ToIngredient()).ToList()
			};
		}
	}
}

