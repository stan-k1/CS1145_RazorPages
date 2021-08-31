using System;
using System.Collections.Generic;
using System.Linq;
using CS1145_RazorPages.Domain;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace CS1145_RazorPages.Pages.Movies
{
    public class IndexModel : PageModel
    {
        public List<Movie> Movies { get; set; }
        private MovieDbContext Context { get; }

        public IndexModel(MovieDbContext context)
        {
            Context = context;
        }

        public void OnGet()
        {
            Movies = Context.Movies.Include(m => m.Actors).ToList();
        }
    }
}
