using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace recipe.Filters
{
    // inheriting the base class give the ability to skip the implementation
    // of the OnActionExecuted
	public class ValidateModelAttribute : ActionFilterAttribute
	{
        // overide the base implementation of the Action class
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                context.Result = new BadRequestObjectResult(context.ModelState);
            }
        }
    }
}

