using DataLayer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.Data
{
    public class FilmManagerDbContext : DbContext
    {
        // The three properties link to the database tables with the same name.
        public DbSet<Film> Films { get; set; }
        public DbSet<Actor> Actors { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Review> Reviews { get; set; }
         
        // Constructor for tell ASP.Net how to create an instance of FilmManagerDbContext.
        public FilmManagerDbContext(DbContextOptions<FilmManagerDbContext> options)
                                 : base(options)
        {

        }

        // Tell EF Core about the Many-to-Many table keys.
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<FilmActor>().HasKey(x => new { x.FilmId, x.ActorId });
            builder.Entity<FilmCategory>().HasKey(x => new { x.FilmId, x.CategoryId });
        }

    }
}
