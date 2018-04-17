using DevChatter.GameTracker.Core.Model;
using DevChatter.GameTracker.Data.Ef;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;
using DevChatter.GameTracker.Core.Data;

namespace DevChatter.GameTracker.Pages.Games
{
    public class CreateModel : PageModel
    {
        private readonly IRepository _repo;

        public CreateModel(IRepository repo)
        {
            _repo = repo;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Game Game { get; set; }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _repo.Create(Game);

            return RedirectToPage("./Index");
        }
    }
}