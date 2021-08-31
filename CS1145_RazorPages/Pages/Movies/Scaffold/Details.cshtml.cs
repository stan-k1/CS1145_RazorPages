﻿using System;
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
    public class DetailsModel : PageModel
    {
        private readonly CS1145_RazorPages.MovieDbContext _context;

        public DetailsModel(CS1145_RazorPages.MovieDbContext context)
        {
            _context = context;
        }

        public Movie Movie { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Movie = await _context.Movies.FirstOrDefaultAsync(m => m.Id == id);

            if (Movie == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
