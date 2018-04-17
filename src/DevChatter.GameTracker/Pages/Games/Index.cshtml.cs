using DevChatter.GameTracker.Core.Data;
using DevChatter.GameTracker.Core.Data.Specifications;
using DevChatter.GameTracker.Core.Model;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;

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

        public IList<Game> Game { get;set; }

        public void OnGet()
        {
            Game = _repo.List(GamePolicy.All());
        }
    }
}
