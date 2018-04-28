using System;
using System.ComponentModel.DataAnnotations;

namespace DevChatter.GameTracker.ViewModels
{
    public class GameViewModel
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        [Display(Name = "BGG Link")]
        public string BoardGameGeekLink => $"https://boardgamegeek.com/boardgame/{BoardGameGeekId}";
        public string BoardGameGeekTitle { get; set; }
        public int? BoardGameGeekId { get; set; }
    }
}
