using DevChatter.GameTracker.Core.Data;
using DevChatter.GameTracker.Core.Data.Specifications;
using DevChatter.GameTracker.Core.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DevChatter.GameTracker.Pages.Players
{
    public class DetailsModel : PageModel
    {
        private readonly IRepository _repo;

        public DetailsModel(IRepository repo)
        {
            _repo = repo;
        }

        public Player Player { get; set; }

        public IActionResult OnGet(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Player = _repo.Single(PlayerPolicy.ById(id.Value));

            if (Player == null)
            {
                return NotFound();
            }

            return Page();
        }
    }
}
