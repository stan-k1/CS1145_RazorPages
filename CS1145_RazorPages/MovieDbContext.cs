using System;
using System.Collections.Generic;
using CS1145_RazorPages.Domain;
using Microsoft.EntityFrameworkCore;

namespace CS1145_RazorPages
{
    public class MovieDbContext : DbContext
    {
        public MovieDbContext(DbContextOptions<MovieDbContext> options) : base(options)
        { }

        public DbSet<Movie> Movies { get; set; }
        public DbSet<Actor> Actors { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Movie>().HasData(new Movie()
            {
                Id = 1,
                Title = "All About Eve",
                Description = "Margo, an established theater actress, appoints Eve, an aspiring actress, as her personal assistant.",
                Genre = Genre.Drama,
                Director = "Joseph L. Mankiewicz",
            });

            modelBuilder.Entity<Actor>().HasData(
                new Actor()
                {
                    Id = 1,
                    FirstName = "Bette",
                    LastName = "Davis"
                },
                new Actor()
                {
                    Id = 2,
                    FirstName = "Anne",
                    LastName = "Baxter"
                });

            // INSERT INTO ActorMovie(ActorsId, MoviesId)
            // VALUES(1, 1), (2, 1);

            base.OnModelCreating(modelBuilder);
        }
    }
}
