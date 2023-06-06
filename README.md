## Recipes_ASP.NET Core MVC and API

This is a CRUD application Developed using the ASP.NET Core platform. I used Entity Framework Core as an ORM to handle data and manage migrations to the DB. I used SQLite as a simple database to store and retrieve the data. I used the DotNet CLI tools to make the migrations and update the database. 

I used Razor Template Engine for the front end. I also used Tag Helpers to facilitate posting data via Forms to the Binding Models. 

I Abstracted the entities with a service layer that the controller interacts with to make changes to the entities to maintain the MVC design pattern and ease maintainability by making code isolation. 
I registered this data service in the DI container using AddScoped lifetime to get an instance per request.

# API and FILTERS

I made a recipe api controller with its own attribute routing system. In order to simplify the action methods I used filters as attributes that are scoped for the controller as a whole and each action. I used Resource Filter to simplify the Enable feature which can short-circuit the pipeline according to a boolean value.
I used 2 Action Filters which are ValidateModel and EnsureExist which returns BadRequestResult if the ModelState is invalid or the required recipe doesn't exist in the database.
In the EnsureExist filter I pulled an instance of the data service from the DI container to beb able to search the database for a specific recipe using id.
