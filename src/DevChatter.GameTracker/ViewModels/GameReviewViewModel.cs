using System;
using System.ComponentModel;

namespace DevChatter.GameTracker.ViewModels
{
    public class GameReviewViewModel
    {
        public Guid Id { get; set; }
        [DisplayName("Reviewer")]
        public string ReviewerName { get; set; }
        public int Rating { get; set; }
        [DisplayName("Review Text")]
        public string ReviewText { get; set; }
        [DisplayName("Game")]
        public string GameTitle { get; set; }
    }
}