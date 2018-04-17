using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DevChatter.GameTracker.Core.Model;
using DevChatter.GameTracker.Data;

namespace DevChatter.GameTracker.Pages.Games
{
    public class DetailsModel : PageModel
    {
        private readonly DevChatter.GameTracker.Data.ApplicationDbContext _context;

        public DetailsModel(DevChatter.GameTracker.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public Game Game { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Game = await _context.Games.SingleOrDefaultAsync(m => m.Id == id);

            if (Game == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
