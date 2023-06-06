using System;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using RecipeApp;

namespace recipe.Filters
{
    public class EnsureRecipeExists : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            // fetch instance of the service from the DI container
            var service = (RecipeService) context.HttpContext
                .RequestServices.GetService(typeof(RecipeService));

            var RecipeId = (int) context.ActionArguments["id"];
            if (!service.DoesRecipeExist(RecipeId))
            {
                context.Result = new NotFoundResult();
            }
        }
    }
}

