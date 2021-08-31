using System;
using System.Linq;
using System.Threading.Tasks;
using CS1145_RazorPages.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace CS1145_RazorPages.Pages.Actors
{
    public class EditModel : PageModel
    {
        [BindProperty] public Actor Actor { get; set; }
        private MovieDbContext Context { get; }

        public EditModel(MovieDbContext context)
        {
            Context = context;
        }

        public async Task<ActionResult> OnGetAsync(int id)
        {
            Actor = await Context.Actors.SingleOrDefaultAsync(a => a.Id == id);
            if (Actor is null) return NotFound();
            return Page();
        }

        public async Task<ActionResult> OnPostAsync(int id)
        {
            Actor toUpdate = Context.Actors.SingleOrDefault(a => a.Id == id);
            if (toUpdate is null) return BadRequest();

            toUpdate.FirstName = Actor.FirstName;
            toUpdate.LastName = Actor.LastName;

            Context.Update(toUpdate);
            await Context.SaveChangesAsync();
            return RedirectToPage("Index");
        }
    }
}
