using System.Collections.Generic;

namespace DevChatter.GameTracker.Core.Model
{
    public class GameRecord : BaseEntity
    {
        public Game Game { get; set; }
        public List<PlayRecord> PlayRecords { get; set; }
    }
}