using Microsoft.EntityFrameworkCore;
using WebApp_RazorPages.Models;

namespace WebApp_RazorPages.Data
{
    public class RazorPagesMovieContext : DbContext
    {
        public RazorPagesMovieContext (DbContextOptions<RazorPagesMovieContext> options) : base(options)
        {

        }
        public DbSet<Movie> Movie{get; set;}
    }
}