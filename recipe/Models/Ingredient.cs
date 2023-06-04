﻿using System;
namespace recipe.Models
{
	public class Ingredient
	{
		public int IngredientId { get; set; }
		public int RecipeId { get; set; }
		public string Name { get; set; }
		public decimal Quantity { get; set; }
		public string Unit { get; set; }
	}
}

