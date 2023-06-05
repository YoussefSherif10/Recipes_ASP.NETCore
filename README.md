## Recipes_ASP.NET Core MVC

This is a CRUD application Developed using the ASP.NET Core platform. I used Entity Framework Core as an ORM to handle data and manage migrations to the DB. I used SQLite as a simple database to store and retrieve the data. I used the DotNet CLI tools to make the migrations and update the database. 

I used Razor Template Engine for the front end. I also used Tag Helpers to facilitate posting data via Forms to the Binding Models. 

I Abstracted the entities with a service layer that the controller interacts with to make changes to the entities to maintain the MVC design pattern and ease maintainability by making code isolation. 
I registered this data service in the DI container using AddScoped lifetime to get an instance per request.