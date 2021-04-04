using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApp_RazorPages.Models;
using System.Linq;

namespace WebApp_RazorPages.Pages.Movies
{
    #region snippet1
    public class IndexModel : PageModel
    {
        private readonly WebApp_RazorPages.Data.RazorPagesMovieContext _context;

        public IndexModel(WebApp_RazorPages.Data.RazorPagesMovieContext context)
        {
            _context = context;
        }
        #endregion
        public IList<Movie> Movie {get; set;}
        [BindProperty(SupportsGet = true)]
        public string SearchString {get; set;}
        public SelectList Genres {get; set;}
        [BindProperty(SupportsGet = true)]
        public string MovieGenre {get; set;}

        public async Task OnGetAsync()
        {
            //use LINQ to get list of genres
            IQueryable<string> genreQuery = from m in _context.Movie    
                                            orderby m.Genre
                                            select m.Genre;
            var movies = from m in _context.Movie
                        select m;

            if(!string.IsNullOrEmpty(SearchString))
            {
                movies = movies.Where(s => s.Title.Contains(SearchString));
            }

            if(!string.IsNullOrEmpty(MovieGenre))
            {
                movies = movies.Where(x => x.Genre == MovieGenre);
            }
            Genres = new SelectList(await genreQuery.Distinct().ToListAsync());
            Movie = await movies.ToListAsync();
        }

      
        
    }
}