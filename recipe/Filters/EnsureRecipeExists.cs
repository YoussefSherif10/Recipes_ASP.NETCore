using System;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using RecipeApp;

namespace recipe.Filters
{
    public class EnsureRecipeExistsFilter : IActionFilter
    {
        private readonly RecipeService _service;
        public EnsureRecipeExistsFilter(RecipeService service)
        {
            _service = service;
        }

        public void OnActionExecuted(ActionExecutedContext context) {}

        public void OnActionExecuting(ActionExecutingContext context)
        {
            var RecipeId = (int)context.ActionArguments["id"];
            if (!_service.DoesRecipeExist(RecipeId))
            {
                context.Result = new NotFoundResult();
            }
        }
    }

    public class EnsureRecipeExistsAttribute : TypeFilterAttribute
    {
        public EnsureRecipeExistsAttribute() : base(typeof(EnsureRecipeExistsFilter))
        {}
    }
}

