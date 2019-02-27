namespace DevChatter.GameTracker.Core.Model
{
    public class Player : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
    }
}