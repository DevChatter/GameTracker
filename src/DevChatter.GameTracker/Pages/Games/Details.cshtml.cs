using DevChatter.GameTracker.Core.Model;
using DevChatter.GameTracker.Data.Ef;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;
using DevChatter.GameTracker.Core.Data;
using DevChatter.GameTracker.Core.Data.Specifications;

namespace DevChatter.GameTracker.Pages.Games
{
    public class DetailsModel : PageModel
    {
        private readonly IRepository _repo;

        public DetailsModel(IRepository repo)
        {
            _repo = repo;
        }


        public Game Game { get; set; }

        public IActionResult OnGet(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Game = _repo.Single(GamePolicy.ById(id.Value));

            if (Game == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
