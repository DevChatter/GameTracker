using System;
using System.ComponentModel.DataAnnotations;

namespace DevChatter.GameTracker.ViewModels
{
    public class CreateGameReviewModel
    {
        [Required]
        [MinLength(2, ErrorMessage = "That's not long enough to be a review.")]
        [MaxLength(1000, ErrorMessage = "Review cannot be longer than 1000 characters.")]
        public string ReviewText { get; set; }
        [Required]
        public Guid GameId { get; set; }
        [Required]
        [Range(1,5)]
        public int Rating { get; set; }
    }
}