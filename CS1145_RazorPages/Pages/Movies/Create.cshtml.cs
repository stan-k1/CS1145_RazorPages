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
    public class CreateModel : PageModel
    {
        private MovieDbContext Context { get; }
        [BindProperty] public Movie Movie { get; set; }
        [BindProperty] public List<int> ActorIds { get; set; }
        public List<SelectListItem> ActorSelectList { get; set; }

        public CreateModel(MovieDbContext context)
        {
            Context = context;
        }

        public async Task OnGetAsync()
        {
            ActorSelectList = await Context.Actors.Select(a => new SelectListItem()
                    {
                        Value = a.Id.ToString(),
                        Text = a.ToString()
                    }
                ).ToListAsync();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            Movie.Actors = await Context.Actors.Where(a => ActorIds.Contains(a.Id)).ToListAsync();

            Context.Movies.Add(Movie);
            await Context.SaveChangesAsync();

            ViewData["Created"] = Movie.Title;
            return RedirectToPage("Index");
        }
    }
}
