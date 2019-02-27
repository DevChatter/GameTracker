using DevChatter.GameTracker.Core.Data;
using DevChatter.GameTracker.Core.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;

namespace DevChatter.GameTracker.Pages.Players
{
    public class IndexModel : PageModel
    {
        private readonly IRepository _repo;

        public IndexModel(IRepository repo)
        {
            _repo = repo;
        }

        public IList<Player> Player { get;set; }

        public IActionResult OnGet()
        {
            Player = _repo.List<Player>();

            return Page();
        }
    }
}
