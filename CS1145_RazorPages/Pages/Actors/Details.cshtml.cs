using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CS1145_RazorPages.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace CS1145_RazorPages.Pages.Actors
{
    public class DetailsModel : PageModel
    {
        public Actor Actor { get; set; }
        public List<Movie> ActorMovies { get; set; }
        private MovieDbContext Context { get;}

        public DetailsModel(MovieDbContext context)
        {
            Context = context;
        }

        public async Task<ActionResult> OnGetAsync(int id)
        {
            Actor = await Context.Actors.SingleOrDefaultAsync(a => a.Id == id);
            if (Actor is null) return BadRequest();
            ActorMovies = await Context.Movies.Where(m => m.Actors.Contains(Actor)).ToListAsync();
            return Page();
        }
    }
}
