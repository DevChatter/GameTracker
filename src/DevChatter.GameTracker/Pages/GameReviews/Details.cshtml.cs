using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DevChatter.GameTracker.Core.Model;
using DevChatter.GameTracker.Data.Ef;

namespace DevChatter.GameTracker.Pages.GameReviews
{
    public class DetailsModel : PageModel
    {
        private readonly DevChatter.GameTracker.Data.Ef.ApplicationDbContext _context;

        public DetailsModel(DevChatter.GameTracker.Data.Ef.ApplicationDbContext context)
        {
            _context = context;
        }

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
    }
}
