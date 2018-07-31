using Microsoft.AspNetCore.Identity;

namespace DevChatter.GameTracker.Core.Model
{
    public class GameReview : BaseEntity
    {
        public Game Game { get; set; }
        public int Rating { get; set; }
        public string Text { get; set; }
        public IdentityUser User { get; set; }
    }
}