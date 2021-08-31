using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CS1145_RazorPages.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace CS1145_RazorPages.Pages.Movies
{
    public class EditModel : PageModel
    {
        private MovieDbContext Context { get; }
        [BindProperty] public Movie Movie { get; set; }
        [BindProperty] public List<int> ActorIds { get; set; }
        public List<SelectListItem> ActorSelectList { get; set; }

        public EditModel(MovieDbContext context)
        {
            Context = context;
        }

        public async Task PopulateActorsList()
        {
            if (Movie.Actors is not null)
            {
                ActorSelectList = await Context.Actors.Select(a => new SelectListItem()
                    {
                        Value = a.Id.ToString(),
                        Text = a.ToString(),
                        Selected = Movie.Actors.Contains(a)
                    }
                ).ToListAsync();
            }
            else
            {
                ActorSelectList = await Context.Actors.Select(a => new SelectListItem()
                    {
                        Value = a.Id.ToString(),
                        Text = a.ToString(),
                    }
                ).ToListAsync();
            }
        }
        
        public async Task<ActionResult> OnGetAsync([FromRoute]int id)
        {
            Movie = Context.Movies.Include(m => m.Actors).SingleOrDefault(m => m.Id == id);
            if (Movie is null) return NotFound();
            await PopulateActorsList();
            return Page();
        }

        public async Task<ActionResult> OnPostAsync([FromRoute] int id)
        {
            if (Movie is null) return BadRequest();

            Movie toUpdate = Context.Movies.Include(m => m.Actors).Single(m => m.Id == id);

            toUpdate.Title = Movie.Title;
            toUpdate.Description = Movie.Description;
            toUpdate.Genre = Movie.Genre;
            toUpdate.Director = Movie.Director;

            if (ActorIds is not null)
                toUpdate.Actors = await Context.Actors.Where(a => ActorIds.Contains(a.Id)).ToListAsync();
            else toUpdate.Actors = null;

            Context.Movies.Update(toUpdate);
            await Context.SaveChangesAsync();

            await PopulateActorsList();
            ViewData["Edited"] = Movie.Title;
            return Page();
        }
    }
}
