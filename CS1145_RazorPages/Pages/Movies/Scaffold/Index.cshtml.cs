using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CS1145_RazorPages;
using CS1145_RazorPages.Domain;

namespace CS1145_RazorPages.Pages.Movies.Scaffold
{
    public class IndexModel : PageModel
    {
        private readonly CS1145_RazorPages.MovieDbContext _context;

        public IndexModel(CS1145_RazorPages.MovieDbContext context)
        {
            _context = context;
        }

        public IList<Movie> Movie { get;set; }

        public async Task OnGetAsync()
        {
            Movie = await _context.Movies.ToListAsync();
        }
    }
}
