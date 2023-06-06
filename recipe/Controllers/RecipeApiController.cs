using System;
using Microsoft.AspNetCore.Mvc;
using RecipeApp;
using recipe.Models;
using recipe.Filters;

namespace recipe.Controllers
{
    [ApiController]
    [Route("api/recipe"), FeatureEnabled(IsEnabled = true)]
    public class RecipeApiController : ControllerBase
    {
        public RecipeService _service;
        public RecipeApiController(RecipeService service)
        {
            _service = service;
        }

        [HttpGet("{id:int}")]
        public IActionResult Get(int id)
        {
            try
            {
                if (!_service.DoesRecipeExist(id))
                {
                    return NotFound();
                }
                var result = _service.GetRecipeDetail(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }

        [HttpPost("{id:int}")]
        public IActionResult Edit(int id, [FromBody] UpdateRecipeCommand cmd)
        {
            try
            {
                if (!_service.DoesRecipeExist(id))
                {
                    return NotFound();
                }
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

