using DevChatter.GameTracker.Core.Data;
using DevChatter.GameTracker.Core.Data.Specifications;
using DevChatter.GameTracker.Core.Model;
using DevChatter.GameTracker.Infra.Bgg;
using DevChatter.GameTracker.ViewModels;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace DevChatter.GameTracker.Pages.Games
{
    public class IndexModel : PageModel
    {
        private readonly IRepository _repo;
        readonly IGameDataService _gameDataService;

        public IndexModel(IRepository repo, IGameDataService gameDataService)
        {
            _gameDataService = gameDataService;
            _repo = repo;
        }

        public string PageTitle { get; set; } = "Game List";

        public IList<GameViewModel> Games { get; set; }

        public void OnGet()
        {
            /**
            * I wrote all this code here in a giant blob because I wasn't sure how you wanted to fit it into your architecture.
            * I wrote this all here with the intention that you would probably break it into a format you prefer
            **/
            var gamesFromDb = _repo.List(GamePolicy.All());
            Games = new List<GameViewModel>();

            foreach (var gameFromDb in gamesFromDb)
            {
                (string bggTitle, int bggId) = _gameDataService.GetPossibleGameIds(gameFromDb.Title).FirstOrDefault();
                var newGame = new GameViewModel()
                {
                    Id = gameFromDb.Id,
                    Title = gameFromDb.Title,
                    BoardGameGeekId = bggId,
                    BoardGameGeekTitle = bggTitle
                };
                Games.Add(newGame);
            }
        }
    }
}
