using DataLayer.Models;
using DataLayer.Models.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.Data
{
    // To avoid creating two databases, one for custom DbContext and one for IdentityDbContext we shall inherit our DbContext class with IdentityDbContext which derives from DbContext.
    public class FilmManagerDbContext : IdentityDbContext<AppUser, AppRole, int>
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
            // Empty constructor.
        }
       
        protected override void OnModelCreating(ModelBuilder builder)
        {
            // Keys of Identity tables are mapped in OnModelCreating method of IdentityDbContext and if this method is not called, you will end up getting the error.
            base.OnModelCreating(builder);
            // Tell EF Core about the Many-to-Many table keys.
            builder.Entity<FilmActor>().HasKey(x => new { x.FilmId, x.ActorId });
            builder.Entity<FilmCategory>().HasKey(x => new { x.FilmId, x.CategoryId });

            // One-to-many relationship Film-Review
            builder.Entity<Film>()
                .HasMany(x => x.Reviews)
                .WithOne(y => y.Film)
                .OnDelete(DeleteBehavior.Cascade); // Setting On Cascade DELETE action, so our relationship is not optional, and all dependants will be deleted.
        }

    }
}
