using System;

namespace DevChatter.GameTracker.ViewModels
{
    public class GameReviewViewModel
    {
        public Guid Id { get; set; }
        public string ReviewerName { get; set; }
        public int Rating { get; set; }
        public string ReviewText { get; set; }
        public string GameTitle { get; set; }
    }
}