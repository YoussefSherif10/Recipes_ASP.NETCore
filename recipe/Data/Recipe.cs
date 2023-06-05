using System;
using System.ComponentModel.DataAnnotations;
namespace recipe.Data
{
	public class Recipe
	{
		public int RecipeId { get; set; }
		[StringLength(100)]
		public string Name { get; set; }
		public TimeSpan TimeToCock { get; set; }
		public bool IsVegan { get; set; }
		public bool IsVegetarian { get; set; }
		public string Method { get; set; }
		public ICollection<Ingredient>? Ingredients { get; set; } // contain list of ingredients
	}
}

