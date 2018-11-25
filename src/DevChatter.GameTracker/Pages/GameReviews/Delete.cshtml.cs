using DevChatter.GameTracker.Core.Model;
using DevChatter.GameTracker.Data.Ef;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace DevChatter.GameTracker.Pages.GameReviews
{
    public class DeleteModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public DeleteModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public GameReview GameReview { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
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

        public async Task<IActionResult> OnPostAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            GameReview = await _context.GameReviews.FindAsync(id);

            if (GameReview != null)
            {
                _context.GameReviews.Remove(GameReview);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
