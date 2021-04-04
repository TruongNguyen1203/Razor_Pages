using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using WebApp_RazorPages.Data;

namespace WebApp_RazorPages.Models
{
    public static class SeedData
    {
        public static void Initilize(IServiceProvider serviceProvider)
        {
            using (var context = new RazorPagesMovieContext(
                serviceProvider.GetRequiredService<
                DbContextOptions<RazorPagesMovieContext>>()
            ))
            {
                if(context.Movie.Any())
                {
                    return; //database has been seed
                }
                context.Movie.AddRange(
                    new Movie{
                        Title ="Godzila vs Kong",
                        ReleaseDate = DateTime.Parse("2021-3-26"),
                        Genre = "Monter verse",
                        Price = 7.99M,
                        Rating = "R"
                    },

                    new Movie{
                        Title ="Kong : Skull Island",
                        ReleaseDate = DateTime.Parse("2017-3-12"),
                        Genre = "Monter verse",
                        Price = 7.99M,
                         Rating = "R"
                    },


                    new Movie{
                        Title ="Godzilla",
                        ReleaseDate = DateTime.Parse("2021-6-17"),
                        Genre = "Monter verse",
                        Price = 7.99M,
                        Rating = "R"
                    },



                    new Movie{
                        Title ="Godzila: King of the monter",
                        ReleaseDate = DateTime.Parse("2021-3-31"),
                        Genre = "Monter verse",
                        Price = 7.99M,
                        Rating = "R"
                    },

                    new Movie{
                        Title ="King Kong",
                        ReleaseDate = DateTime.Parse("2021-3-26"),
                        Genre = "Monter verse",
                        Price = 7.99M,
                         Rating = "R"
                    }
                );
                context.SaveChanges();
            }
        }
    }
}