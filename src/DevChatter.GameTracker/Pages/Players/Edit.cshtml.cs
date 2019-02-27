using DevChatter.GameTracker.Core.Data;
using DevChatter.GameTracker.Core.Data.Specifications;
using DevChatter.GameTracker.Core.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace DevChatter.GameTracker.Pages.Players
{
    public class EditModel : PageModel
    {
        private readonly IRepository _repo;

        public EditModel(IRepository repo)
        {
            _repo = repo;
        }

        [BindProperty]
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

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            try
            {
                _repo.Update(Player);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PlayerExists(Player.Id))
                {
                    return NotFound();
                }

                throw;
            }

            return RedirectToPage("./Index");
        }

        private bool PlayerExists(int id)
        {
            return _repo.Exists(PlayerPolicy.ById(id));
        }
    }
}
