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
    public class PlayersController : ControllerBase
    {
        private readonly IRepository _repository;

        public PlayersController(IRepository repository)
        {
            _repository = repository;
        }

        // GET: api/Players
        [HttpGet]
        public IEnumerable<Player> GetPlayers()
        {
            return _repository.List<Player>();
        }

        // GET: api/Players/Brend
        [HttpGet("{filter}")]
        public IActionResult SearchPlayers([FromRoute] string filter)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var players = _repository.List(PlayerPolicy.ByNameLike(filter));

            return Ok(players);
        }

        // POST: api/Players
        [HttpPost]
        public async Task<IActionResult> PostPlayer([FromBody] Player player)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            player = _repository.Create(player);

            return CreatedAtAction("GetPlayer", new { id = player.Id }, player);
        }
    }
}