using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MvcMovie.Data;
using System;
using System.IO;
using System.Linq;

namespace MvcMovie.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new MvcMovieContext(
                serviceProvider.GetRequiredService<DbContextOptions<MvcMovieContext>>()))
            {
                // Look for any movies.
                if (context.Movie.Any())
                {
                    return;   // DB has been seeded
                }

                context.Movie.AddRange(
                    new Movie
                    {
                        Title = "Brigham City",
                        ReleaseDate = DateTime.Parse("2001-2-12"),
                        Genre = "Murder Mystery",
                        Rating = "R",
                        Price = 7.99M,
                        ImageName = "brigham_city.jpeg" // Add image file name
                    },
                    new Movie
                    {
                        Title = "Baptism at our Barbecue",
                        ReleaseDate = DateTime.Parse("1984-3-13"),
                        Genre = "Comedy",
                        Rating = "R",
                        Price = 8.99M,
                        ImageName = "baptism_at_our_barbecue.jpeg" // Add image file name
                    },
                    new Movie
                    {
                        Title = "Freetown",
                        ReleaseDate = DateTime.Parse("1986-2-23"),
                        Genre = "Action",
                        Rating = "R",
                        Price = 9.99M,
                        ImageName = "freetown.jpeg" // Add image file name
                    },
                    new Movie
                    {
                        Title = "The Errand of Angels",
                        ReleaseDate = DateTime.Parse("1959-4-15"),
                        Genre = "Western",
                        Rating = "R",
                        Price = 3.99M,
                        ImageName = "errand_of_angels.jpeg" // Add image file name
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
