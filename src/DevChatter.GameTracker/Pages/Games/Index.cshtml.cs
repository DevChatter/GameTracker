using DevChatter.GameTracker.Core.Model;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using DevChatter.GameTracker.Data.Ef;

namespace DevChatter.GameTracker.Pages.Games
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public IndexModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public string PageTitle { get; set; } = "Game List";

        public IList<Game> Game { get;set; }

        public async Task OnGetAsync()
        {
            Game = await _context.Games.ToListAsync();
        }
    }
}
