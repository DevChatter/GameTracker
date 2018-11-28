using System.Collections.Generic;
using System.Linq;
using DevChatter.GameTracker.Core.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;
using AutoMapper;
using DevChatter.GameTracker.Data.Ef;
using DevChatter.GameTracker.ViewModels;
using Microsoft.AspNetCore.Identity;

namespace DevChatter.GameTracker.Pages.GameReviews
{
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public CreateModel(ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public IActionResult OnGet()
        {
            // We'll eventually need to handle this better once there are more games.
            List<Game> games = _context.Games.ToList();

            Games = games.Select(x => Mapper.Map<GameViewModel>(x)).ToList();
            return Page();
        }

        [BindProperty]
        public CreateGameReviewModel GameReviewViewModel { get; set; }

        public List<GameViewModel> Games { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var gameReview = Mapper.Map<GameReview>(GameReviewViewModel);
            gameReview.User = await _userManager.GetUserAsync(User);
            _context.GameReviews.Add(gameReview);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}