﻿using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using recipe.Models;
using RecipeApp;

namespace recipe.Controllers;

public class RecipeController : Controller
{
    private readonly ILogger<RecipeController> _logger;
    public RecipeService _service;

    public RecipeController(ILogger<RecipeController> logger, RecipeService service)
    {
        _service = service;
        _logger = logger;
    }

    public IActionResult Index()
    {
        var models = _service.GetRecipes();
        return View(models);
    }

    public IActionResult View(int id)
    {
        var model = _service.GetRecipeDetail(id);
        if (model == null)
        {
            // If id is not for a valid Recipe, generate a 404 error page
            // TODO: Add status code pages middleware to show friendly 404 page
            return NotFound();
        }
        return View(model);
    }

    public IActionResult Create()
    {
        return View(new CreateRecipeCommand());
    }

    [HttpPost]
    public IActionResult Create(CreateRecipeCommand command)
    {
        try
        {
            if (ModelState.IsValid)
            {
                var id = _service.CreateRecipe(command);
                return RedirectToAction(nameof(View), new { id = id });
            }
        }
        catch (Exception)
        {
            ModelState.AddModelError(
                    string.Empty,
                    "An error occured saving the recipe"
                    );
        }

        return View(command);
    }

    [HttpPost]
    public IActionResult DeletePost(int id)
    {
        _service.DeleteRecipe(id);
        return RedirectToAction(nameof(Index));
    }

    public IActionResult Edit(int id)
    {
        var model = _service.GetRecipeForUpdate(id);
        if (model == null)
        {
            // If id is not for a valid Recipe, generate a 404 error page
            // TODO: Add status code pages middleware to show friendly 404 page
            return NotFound();
        }
        return View(model);
    }

    [HttpPost]
    public IActionResult Edit(UpdateRecipeCommand command)
    {
        try
        {
            if (ModelState.IsValid)
            {
                _service.UpdateRecipe(command);
                return RedirectToAction(nameof(View), new { id = command.Id });
            }
        }
        catch (Exception)
        {
            // TODO: Log error
            // Add a model-level error by using an empty string key
            ModelState.AddModelError(
                string.Empty,
                "An error occured saving the recipe"
                );
        }

        //If we got to here, something went wrong
        return View(command);
    }
}

