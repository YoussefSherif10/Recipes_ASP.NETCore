using System;
namespace recipe.Models
{
	public class Recipe
	{
		public int RecipeId { get; set; }
		public string Name { get; set; }
		public TimeSpan TimeToCock { get; set; }
		public bool IsDeleted { get; set; }
		public string Method { get; set; }
		public ICollection<Ingredient> Ingredients { get; set; } // contain list of ingredients
	}
}

