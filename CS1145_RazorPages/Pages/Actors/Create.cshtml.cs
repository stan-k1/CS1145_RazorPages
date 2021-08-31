using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CS1145_RazorPages.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Razor.Language.Extensions;

namespace CS1145_RazorPages.Pages.Actors
{
    public class CreateModel : PageModel
    {
        [BindProperty] public Actor Actor { get; set; }
        private MovieDbContext Context { get; }
        public int ActorCount { get; set; }

        public CreateModel(MovieDbContext context)
        {
            Context = context;
        }

        public void OnGet()
        {
            ActorCount = Context.Actors.Count();
        }

        public ActionResult OnPost()
        {
            Context.Actors.Add(Actor);
            Context.SaveChanges();
            return RedirectToPage("Index");
        }
    }
}
