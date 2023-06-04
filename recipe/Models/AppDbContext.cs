﻿using System;
using Microsoft.EntityFrameworkCore;

namespace recipe.Models
{
	public class AppDbContext : DbContext
	{
		public AppDbContext(DbContextOptions<AppDbContext> options): base(options)
		{}

		public DbSet<Recipe> Recipes { get; set; }
	}
}

