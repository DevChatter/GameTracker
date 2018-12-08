using DevChatter.GameTracker.Core.Data;
using DevChatter.GameTracker.Core.Data.Specifications;
using DevChatter.GameTracker.Core.Model;
using DevChatter.GameTracker.ViewModels;
using DevChatter.GameTracker.ViewModels.Extensions;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevChatter.GameTracker.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameRecordsController : ControllerBase
    {
        private readonly IRepository _repository;

        public GameRecordsController(IRepository repository)
        {
            _repository = repository;
        }

        // GET: api/GameRecords
        [HttpGet]
        public IEnumerable<CreateGameRecordViewModel> GetGameRecords()
        {
            List<GameRecord> gameRecords = _repository.List<GameRecord>();
            return gameRecords.Select(x => x.ToViewModel());
        }

        // GET: api/GameRecords/2
        [HttpGet("{gameRecordId}")]
        public IActionResult GetGameRecord([FromRoute] int gameRecordId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var gameRecords = _repository.List(GameRecordPolicy.ById(gameRecordId));
            var viewModels = gameRecords.Select(x => x.ToViewModel());

            return Ok(viewModels);
        }

        // POST: api/GameRecords
        [HttpPost]
        public async Task<IActionResult> PostGameRecord([FromBody]
            CreateGameRecordViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            GameRecord gameRecord = viewModel.ToGameRecord();

            gameRecord = _repository.Create(gameRecord);

            return CreatedAtAction("GetGameRecord", 
                new { gameRecordId = gameRecord.Id }, gameRecord);
        }
    }
}