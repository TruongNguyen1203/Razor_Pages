
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApp_RazorPages.Data;
using WebApp_RazorPages.Models;

namespace WebApp_RazorPages.Pages.Movies
{
    public class CreateModel : PageModel
    {
        private readonly RazorPagesMovieContext _context;
        public CreateModel(RazorPagesMovieContext context)
        {
            _context = context;
        }

        public IActionResult OnGet(){
            return Page();
        }

        [BindProperty]
        public Movie Movie {get;set;}

        public async Task<IActionResult> OnPostAsync()
        {
            if( !ModelState.IsValid)
            {
                return Page();
            }

            _context.Movie.Add(Movie);
            await _context.SaveChangesAsync();
            return RedirectToPage("./Index");
        }

    }
}