using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DevChatter.GameTracker.Core.Model;
using DevChatter.GameTracker.Data;

namespace DevChatter.GameTracker.Pages.Games
{
    public class EditModel : PageModel
    {
        private readonly DevChatter.GameTracker.Data.ApplicationDbContext _context;

        public EditModel(DevChatter.GameTracker.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Game).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GameExists(Game.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool GameExists(Guid id)
        {
            return _context.Games.Any(e => e.Id == id);
        }
    }
}
