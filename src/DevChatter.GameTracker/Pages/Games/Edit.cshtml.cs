using DevChatter.GameTracker.Core.Data;
using DevChatter.GameTracker.Core.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using DevChatter.GameTracker.Core.Data.Specifications;

namespace DevChatter.GameTracker.Pages.Games
{
    public class EditModel : PageModel
    {
        private readonly IRepository _repo;

        public EditModel(IRepository repo)
        {
            _repo = repo;
        }


        [BindProperty]
        public Game Game { get; set; }

        public IActionResult OnGet(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Game = _repo.Single(BaseEntityPolicy<Game>.ById(id.Value));

            if (Game == null)
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
                _repo.Update(Game);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GameExists(Game.Id))
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

        private bool GameExists(Guid id)
        {
            return _repo.Single(BaseEntityPolicy<Game>.ById(id)) != null;
        }
    }
}
