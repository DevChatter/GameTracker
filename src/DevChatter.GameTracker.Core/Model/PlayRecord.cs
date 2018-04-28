namespace DevChatter.GameTracker.Core.Model
{
    public class PlayRecord : BaseEntity
    {
        public Player Player { get; set; }
        public bool Won { get; set; }
        public bool Taught { get; set; }
    }
}