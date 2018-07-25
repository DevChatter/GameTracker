using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DevChatter.GameTracker.Core.Model;
using DevChatter.GameTracker.Data.Ef;

namespace DevChatter.GameTracker.Pages.GameReviews
{
    public class EditModel : PageModel
    {
        private readonly DevChatter.GameTracker.Data.Ef.ApplicationDbContext _context;

        public EditModel(DevChatter.GameTracker.Data.Ef.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public GameReview GameReview { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            GameReview = await _context.GameReviews.FirstOrDefaultAsync(m => m.Id == id);

            if (GameReview == null)
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

            _context.Attach(GameReview).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GameReviewExists(GameReview.Id))
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

        private bool GameReviewExists(Guid id)
        {
            return _context.GameReviews.Any(e => e.Id == id);
        }
    }
}
