using System;
using Microsoft.AspNetCore.Mvc;
using RecipeApp;
using recipe.Models;
using recipe.Filters;

namespace recipe.Controllers
{
    [ApiController]
    [Route("api/recipe"), FeatureEnabled(IsEnabled = true), ValidateModel, HandleException]
    public class RecipeApiController : ControllerBase
    {
        public RecipeService _service;
        public RecipeApiController(RecipeService service)
        {
            _service = service;
        }

        [HttpGet("{id:int}"), EnsureRecipeExists]
        public IActionResult Get(int id)
        {
            try
            {
                var result = _service.GetRecipeDetail(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }

        [HttpPost("{id:int}"), EnsureRecipeExists]
        public IActionResult Edit(int id, [FromBody] UpdateRecipeCommand cmd)
        {
            try
            {
                _service.UpdateRecipe(cmd);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }
    }
}

