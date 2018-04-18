using DevChatter.GameTracker.Core.Data;
using DevChatter.GameTracker.Core.Data.Specifications;
using DevChatter.GameTracker.Core.Model;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Net.Http;

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

        public IList<GameViewModel> Games { get;set; }

        public void OnGet()
        {
			/**
			 * I wrote all this code here in a giant blob because I wasn't sure how you wanted to fit it into your architecture.
			 * I wrote this all here with the intention that you would probably break it into a format you prefer
			**/
            var gamesFromDb = _repo.List(GamePolicy.All());
			Games = new List<GameViewModel>();
			using(var client = new HttpClient()) {
				string bggBaseUrl = "https://www.boardgamegeek.com/xmlapi2/";

				client.BaseAddress = new System.Uri(bggBaseUrl);
				client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("text/xml"));

				foreach (var dbGame in gamesFromDb)
				{
					string apiSearchQuery = string.Format("search?query={0}&exact=1", dbGame.Title);
					string boardGameGeekLink = "test";

					var response = client.GetAsync(apiSearchQuery);

					if(response.Result.IsSuccessStatusCode)
					{
						//parse response and get link here
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

	/**I wrote this view model here because I needed to add the link to each game but did not
	 * want to modify the Entity as it is connected to EF and is supposed to represent the model
	 * in the database
	**/
	public class GameViewModel
	{
		public System.Guid Id { get; set; }
		public string Title { get; set; }
		public string BoardGameGeekLink { get; set; }
	}
}
