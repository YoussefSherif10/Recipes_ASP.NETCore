using System;
using Microsoft.EntityFrameworkCore;


namespace recipe.Data
{
    // has the list of entities needed to access the DB
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        { }

        public DbSet<Recipe> Recipes { get; set; } // used to query the DB
    }
}



