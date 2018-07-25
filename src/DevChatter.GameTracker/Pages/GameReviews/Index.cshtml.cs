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
    public class IndexModel : PageModel
    {
        private readonly DevChatter.GameTracker.Data.Ef.ApplicationDbContext _context;

        public IndexModel(DevChatter.GameTracker.Data.Ef.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<GameReview> GameReview { get;set; }

        public async Task OnGetAsync()
        {
            GameReview = await _context.GameReviews.ToListAsync();
        }
    }
}
