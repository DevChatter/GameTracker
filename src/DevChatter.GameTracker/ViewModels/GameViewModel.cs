using System;

namespace DevChatter.GameTracker.ViewModels
{
    public class GameViewModel
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string BoardGameGeekLink { get; set; }
    }
}
