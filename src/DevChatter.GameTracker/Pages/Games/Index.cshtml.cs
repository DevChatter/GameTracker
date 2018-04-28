using DevChatter.GameTracker.Core.Data;
using DevChatter.GameTracker.Core.Data.Specifications;
using DevChatter.GameTracker.Core.Model;
using DevChatter.GameTracker.ViewModels;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace DevChatter.GameTracker.Pages.Games
{
    public class IndexModel : PageModel
    {
        private readonly IRepository _repo;

        public IndexModel(IRepository repo)
        {
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
            using (var client = new HttpClient())
            {
                string bggBaseUrl = "https://www.boardgamegeek.com/xmlapi2/";

                client.BaseAddress = new System.Uri(bggBaseUrl);
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("text/xml"));

                foreach (var dbGame in gamesFromDb)
                {
                    string apiSearchQuery = string.Format("search?query={0}&exact=1", dbGame.Title);
                    string boardGameGeekLink = "test";

                    var response = client.GetAsync(apiSearchQuery);

                    if (response.Result.IsSuccessStatusCode)
                    {
                        string content = response.Result.Content.ReadAsStringAsync().Result;
                    }

                    var newGame = new GameViewModel()
                    {
                        Id = dbGame.Id,
                        Title = dbGame.Title,
                        BoardGameGeekLink = boardGameGeekLink
                    };
                    Games.Add(newGame);
                }
            }
        }
    }
}
