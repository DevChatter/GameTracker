using DevChatter.GameTracker.Core.Model;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DevChatter.GameTracker.Data.Ef;
using DevChatter.GameTracker.ViewModels;

namespace DevChatter.GameTracker.Pages.GameReviews
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public IndexModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<GameReviewViewModel> GameReviews { get;set; }

        public async Task OnGetAsync()
        {
            List<GameReview> gameReviews = await _context.GameReviews.ToListAsync();

            //Hack!!!!
            gameReviews.Add(new GameReview { Text = "Hacked in here.", Rating = 1337 });

            IList<GameReviewViewModel> viewModels = gameReviews.Select(x => Mapper.Map<GameReviewViewModel>(x)).ToList();

            GameReviews = viewModels;
        }
    }
}
