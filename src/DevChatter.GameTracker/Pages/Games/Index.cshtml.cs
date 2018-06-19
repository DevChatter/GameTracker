using DevChatter.GameTracker.Core.Data;
using DevChatter.GameTracker.Core.Data.Specifications;
using DevChatter.GameTracker.Infra.Bgg;
using DevChatter.GameTracker.ViewModels;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Linq;

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
            var gamesFromDb = _repo.List(GamePolicy.All());
            Games = new List<GameViewModel>();

            foreach (var gameFromDb in gamesFromDb)
            {
                string bggTitle = gameFromDb.Title;
                int? bggId = gameFromDb.BoardGameGeekId;

                //if (!gameFromDb.BoardGameGeekId.HasValue)
                //{
                //    (bggTitle, bggId) = _gameDataService.GetPossibleGameIds(gameFromDb.Title).FirstOrDefault();
                //}

                var newGame = new GameViewModel
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
