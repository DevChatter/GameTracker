using DevChatter.GameTracker.Core.Data;
using DevChatter.GameTracker.Core.Data.Specifications;
using DevChatter.GameTracker.Core.Model;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DevChatter.GameTracker.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GamesController : ControllerBase
    {
        private readonly IRepository _repository;

        public GamesController(IRepository repository)
        {
            _repository = repository;
        }

        // GET: api/Games
        [HttpGet]
        public IEnumerable<Game> GetGames()
        {
            return _repository.List<Game>();
        }

        // GET: api/Games/Terra
        [HttpGet("{filter}")]
        public IActionResult SearchGames([FromRoute] string filter)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var games = _repository.List(GamePolicy.ByTitleLike(filter));

            return Ok(games);
        }

        // POST: api/Games
        [HttpPost]
        public async Task<IActionResult> PostGame([FromBody] Game game)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            game = _repository.Create(game);

            return CreatedAtAction("GetGame", new { id = game.Id }, game);
        }

    }
}