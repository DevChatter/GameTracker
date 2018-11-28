using DevChatter.GameTracker.Core.Data.Specifications;
using DevChatter.GameTracker.Core.Model;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace DevChatter.GameTracker.UnitTests.Core.Data.Specifications.GamePolicyTests
{
    public class ByTitleLikeShouldReturn
    {
        [Theory]
        [InlineData("Pand ", "Pandemic", "Pandemic Legacy")]
        [InlineData(" leGa", "Pandemic Legacy", "Risk Legacy")]
        public void FilteredList_GivenSingleTerm(string filter, params string[] expected)
        {
            List<Game> games = GetTestGames();

            var predicate = GamePolicy.ByTitleLike(filter).Criteria.Compile();
            var filteredGames = games.Where(predicate).ToList();

            Assert.Equal(expected.Length, filteredGames.Count);
            Assert.Equal(expected, filteredGames.Select(g => g.Title));
        }

        [Theory]
        [InlineData("Candy")]
        public void EmptyCollection_NoMatches(string filter)
        {
            List<Game> games = GetTestGames();

            var predicate = GamePolicy.ByTitleLike(filter).Criteria.Compile();
            var filteredGames = games.Where(predicate).ToList();

            Assert.Empty(filteredGames);
        }

        private List<Game> GetTestGames()
        {
            return new List<Game>
            {
                new Game { Title = "Die Macher" },
                new Game { Title = "Scrabble" },
                new Game { Title = "Monopoly" },
                new Game { Title = "Clue" },
                new Game { Title = "Pandemic" },
                new Game { Title = "Pandemic Legacy" },
                new Game { Title = "Risk" },
                new Game { Title = "Risk Legacy" },
                new Game { Title = "Terraforming Mars" },
                new Game { Title = "Splendor" },
                new Game { Title = "Ticket to Ride" },
            };
        }
    }
}