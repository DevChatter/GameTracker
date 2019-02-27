using DevChatter.GameTracker.Core.Data;
using DevChatter.GameTracker.ViewModels;
using DevChatter.GameTracker.ViewModels.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DevChatter.GameTracker.Pages.Players
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
        public PlayerCreateModel Player { get; set; }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _repo.Create(Player.ToModel());

            return RedirectToPage("./Index");
        }
    }
}