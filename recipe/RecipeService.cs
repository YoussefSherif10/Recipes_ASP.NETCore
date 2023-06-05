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

        public ICollection<RecipeSummaryViewModel> GetRecipes()
        {
            return _context.Recipes
                .Where(x => !x.IsDelete)
                .Select(x => new RecipeSummaryViewModel
                {
                    Id = x.RecipeId,
                    Name = x.Name,
                    TimeToCook = $"{x.TimeToCock.Hours}hrs {x.TimeToCock.Minutes}mins",
                }).ToList();
        }

        public int CreateRecipe(CreateRecipeCommand cmd)
        {
            var recipe = cmd.ToRecipe();
            _context.Add(recipe);
            _context.SaveChanges();
            return recipe.RecipeId;
        }

        public RecipeDetailViewModel? GetRecipeDetail(int id)
        {
            return _context.Recipes
                .Where(x => x.RecipeId == id)
                .Where(x => !x.IsDelete)
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

        public void DeleteRecipe(int id)
        {
            var recipe = _context.Recipes.Find(id);
            if (recipe.IsDelete) { throw new Exception("Unable to delete a deleted recipe"); }
            recipe.IsDelete = true;
            _context.SaveChanges();
        }

        public UpdateRecipeCommand? GetRecipeForUpdate(int recipeId)
        {
            return _context.Recipes
                .Where(x => x.RecipeId == recipeId)
                .Where(x => !x.IsDelete)
                .Select(x => new UpdateRecipeCommand
                {
                    Name = x.Name,
                    Method = x.Method,
                    TimeToCookHrs = x.TimeToCock.Hours,
                    TimeToCookMins = x.TimeToCock.Minutes,
                    IsVegan = x.IsVegan,
                    IsVegetarian = x.IsVegetarian,
                })
                .SingleOrDefault();
        }

        public void UpdateRecipe(UpdateRecipeCommand cmd)
        {
            var recipe = _context.Recipes.Find(cmd.Id);
            if (recipe == null) { throw new Exception("Unable to find the recipe"); }
            if (recipe.IsDelete) { throw new Exception("Unable to update a deleted recipe"); }

            cmd.UpdateRecipe(recipe);
            _context.SaveChanges();
        }
    }
}

