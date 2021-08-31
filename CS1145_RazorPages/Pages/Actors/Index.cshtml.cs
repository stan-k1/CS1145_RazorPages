using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CS1145_RazorPages.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace CS1145_RazorPages.Pages.Actors
{
    public class IndexModel : PageModel
    {
        private MovieDbContext Context { get; }
        public List<Actor> Actors { get; set; }

        public IndexModel(MovieDbContext context)
        {
            Context = context;
        }

        public async Task OnGetAsync()
        {
            Actors = await Context.Actors.ToListAsync();
        }
    }
}
