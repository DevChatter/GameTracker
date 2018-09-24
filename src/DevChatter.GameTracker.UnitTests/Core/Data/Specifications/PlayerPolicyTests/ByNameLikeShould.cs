using System;
using System.Collections.Generic;
using System.Linq;
using DevChatter.GameTracker.Core.Data.Specifications;
using DevChatter.GameTracker.Core.Model;
using Xunit;

namespace DevChatter.GameTracker.UnitTests.Core.Data.Specifications.PlayerPolicyTests
{
    public class ByNameLikeShouldReturn
    {
        [Theory]
        [InlineData("Bre")]
        [InlineData("Brendan")]
        [InlineData("brend")]
        public void FilteredList_GivenSingleTerm(string filter)
        {
            List<Player> players = GetTestPlayers();

            var predicate = PlayerPolicy.ByNameLike(filter).Criteria.Compile();
            var filteredPlayes = players.Where(predicate).ToList();

            Assert.Equal(players.Count-1, filteredPlayes.Count);
            Assert.Contains("Johnson", players.Select(x => x.LastName));
            Assert.DoesNotContain("Johnson", filteredPlayes.Select(x => x.LastName));
        }

        [Theory]
        [InlineData("Bre Enri", "Brendan")]
        [InlineData("Brendan eiCH", "Brendan")]
        [InlineData("fra bre", "Brendan")]
        [InlineData("Sa Br", "Saint")]
        [InlineData("Jo Fr", "Fred")]
        public void SingleResult_GivenMultipleTerms(string filter, string expectedFirstName)
        {
            List<Player> players = GetTestPlayers();

            var predicate = PlayerPolicy.ByNameLike(filter).Criteria.Compile();
            var filteredPlayes = players.Where(predicate).ToList();

            Assert.Equal(expectedFirstName, filteredPlayes.Single().FirstName);
        }

        [Theory]
        [InlineData("Michael")]
        [InlineData("Robert")]
        [InlineData("Brandon")]
        public void EmptyCollection_NoMatches(string filter)
        {
            List<Player> players = GetTestPlayers();

            var predicate = PlayerPolicy.ByNameLike(filter).Criteria.Compile();
            var filteredPlayes = players.Where(predicate).ToList();

            Assert.Empty(filteredPlayes);
        }

        private List<Player> GetTestPlayers()
        {
            return new List<Player>
            {
                new Player {FirstName = "Brendan", LastName = "Enrick" },
                new Player {FirstName = "Brendan", LastName = "Eich" },
                new Player {FirstName = "Brendan", LastName = "Frazier" },
                new Player {FirstName = "Brendan", LastName = "" },
                new Player {FirstName = "Saint", LastName = "Brendan" },
                new Player {FirstName = "Brendan", LastName = "the Navigator" },
                new Player {FirstName = "Fred", LastName = "Johnson" },
            };
        }
    }
}