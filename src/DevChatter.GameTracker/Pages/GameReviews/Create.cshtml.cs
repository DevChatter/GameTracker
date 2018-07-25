using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using DevChatter.GameTracker.Core.Model;
using DevChatter.GameTracker.Data.Ef;

namespace DevChatter.GameTracker.Pages.GameReviews
{
    public class CreateModel : PageModel
    {
        private readonly DevChatter.GameTracker.Data.Ef.ApplicationDbContext _context;

        public CreateModel(DevChatter.GameTracker.Data.Ef.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public GameReview GameReview { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.GameReviews.Add(GameReview);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}