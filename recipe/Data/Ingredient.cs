using System;
namespace recipe.Data
{
	public class Ingredient
	{
		public int IngredientId { get; set; }
		public int RecipeId { get; set; } // foriegn key that makes the relationship automatically
		public string? Name { get; set; }
		public decimal Quantity { get; set; }
		public string? Unit { get; set; }
	}
}

