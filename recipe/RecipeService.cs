using System;
using recipe.Data;
using recipe.Models;

namespace RecipeApp
{
	public class RecipeService
	{
		readonly AppDbContext _context;

		public RecipeService(AppDbContext context)
		{
			_context = context;
		}

		public int CreateRecipe(CreateRecipeCommand cmd)
		{
			var recipe = cmd.ToRecipe();
			_context.Add(recipe);
			_context.SaveChanges();
			return recipe.RecipeId;
		}

		public RecipeDetailViewModel GetRecipeDetail(int id)
		{
			return _context.Recipes
				.Where(x => x.RecipeId == id)
				.Select(x => new RecipeDetailViewModel
				{
					Id = x.RecipeId,
					Name = x.Name,
					Method = x.Method,
					Ingredients = x.Ingredients
					.Select(item => new RecipeDetailViewModel.Item
					{
						Name = item.Name,
						Quantity = $"{item.Quantity} {item.Unit}"
					})
				})
				.SingleOrDefault();
		}
	}
}

