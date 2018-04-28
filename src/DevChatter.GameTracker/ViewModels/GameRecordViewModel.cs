using System;
using System.Collections.Generic;

namespace DevChatter.GameTracker.ViewModels
{
    public class GameRecordViewModel
    {
        public Guid GameId { get; set; }
        public List<Guid> PlayerIds { get; set; }
        public List<Guid> WinnerIds { get; set; }
        public List<Guid> TeacherIds { get; set; }
    }
}