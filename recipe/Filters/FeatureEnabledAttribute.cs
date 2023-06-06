using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace recipe.Filters
{
	public class FeatureEnabledAttribute : Attribute, IResourceFilter
	{
		public bool IsEnabled { get; set; }

		public void OnResourceExecuting(ResourceExecutingContext context)
		{
			if (!IsEnabled)
			{
				// short circuit the pipeline 
				context.Result = new BadRequestResult();
			}
		}

		public void OnResourceExecuted(ResourceExecutedContext context) { }
	}
}

