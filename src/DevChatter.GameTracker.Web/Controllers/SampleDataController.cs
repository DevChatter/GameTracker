using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace DevChatter.GameTracker.Web.Controllers
{
    [Route("api/[controller]")]
    public class SampleDataController : Controller
    {
        [HttpGet("[action]")]
        public IEnumerable<Game> Games()
        {
            return new [] {
                new Game { Title = "Pandemic", },
                new Game { Title = "Dominion", },
                new Game { Title = "Dominion: Intrigue", },
                new Game { Title = "7 Wonders", },
                new Game { Title = "Die Macher", },
                new Game { Title = "Puerto Rico", },
                new Game { Title = "Race for the Galaxy", },
                new Game { Title = "Betrayal at House on the Hill", },
                new Game { Title = "Can't Stop", },
                new Game { Title = "Battlestar Galactica", },
                new Game { Title = "The Resistance", },
                new Game { Title = "Chicago Express", },
                new Game { Title = "Railways of the World", },
            };
        }

        [HttpGet("[action]")]
        public IEnumerable<Player> Players()
        {
            return _players;
        }

        [HttpGet("[action]/{id}")]
        public Player Players(int id)
        {
            return _players.SingleOrDefault(p => p.Id == id);
        }

        private Player[] _players = new[] {
                new Player { Id = 1, FirstName = "Brendan", LastName = "Enrick", IsMember = true },
                new Player { Id = 2, FirstName = "Steve", LastName = "Smith", IsMember = true },
                new Player { Id = 3, FirstName = "William", LastName = "Whaties", IsMember = false },
                new Player { Id = 4, FirstName = "Jeffrey", LastName = "Jones", IsMember = false },
                new Player { Id = 5, FirstName = "Gerald", LastName = "George", IsMember = true },
            };


        public class Game
        {
            public string Title { get; set; }
        }

        public class Player
        {
            public int Id { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public bool IsMember { get; set; }
        }
    }
}