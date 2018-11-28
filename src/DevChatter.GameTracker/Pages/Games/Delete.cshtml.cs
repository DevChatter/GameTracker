using DevChatter.GameTracker.Core.Data;
using DevChatter.GameTracker.Core.Data.Specifications;
using DevChatter.GameTracker.Core.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DevChatter.GameTracker.Pages.Games
{
    public class DeleteModel : PageModel
    {
        private readonly IRepository _repo;

        public DeleteModel(IRepository repo)
        {
            _repo = repo;
        }


        [BindProperty]
        public Game Game { get; set; }

        public IActionResult OnGet(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Game = _repo.Single(GamePolicy.ById(id.Value));

            if (Game == null)
            {
                return NotFound();
            }
            return Page();
        }

        public IActionResult OnPost(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Game = _repo.Single(GamePolicy.ById(id.Value));

            if (Game != null)
            {
                _repo.Remove(Game);
            }

            return RedirectToPage("./Index");
        }
    }
}
