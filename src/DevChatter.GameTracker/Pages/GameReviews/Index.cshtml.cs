using System;
using DevChatter.GameTracker.Core.Model;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DevChatter.GameTracker.Data.Ef;
using DevChatter.GameTracker.ViewModels;
using Microsoft.AspNetCore.Identity;

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
            gameReviews.Add(new GameReview {
                Id = Guid.NewGuid(),
                Text = "Hacked in here. Hacked in here. Hacked in here. Hacked in here. Hacked in here. Hacked in here. Hacked in here. Hacked in here. Hacked in here. Hacked in here. Hacked in here. Hacked in here. Hacked in here. Hacked in here. Hacked in here. Hacked in here. Hacked in here. Hacked in here. Hacked in here. Hacked in here. Hacked in here. Hacked in here. Hacked in here. Hacked in here. Hacked in here. Hacked in here. Hacked in here. Hacked in here. Hacked in here. Hacked in here. Hacked in here. Hacked in here.",
                Rating = 1337,
                Game = new Game { Title = "Look At Automapper"},
                User = new IdentityUser("JimboTheHackmaster")});

            IList<GameReviewViewModel> viewModels = gameReviews.Select(x => Mapper.Map<GameReviewViewModel>(x)).ToList();

            GameReviews = viewModels;
        }
    }
}
