using System;
using System.Collections.Generic;

namespace DevChatter.GameTracker.ViewModels
{
    public class GameRecordViewModel
    {
        public int GameId { get; set; }
        public List<int> PlayerIds { get; set; }
        public List<int> WinnerIds { get; set; }
        public List<int> TeacherIds { get; set; }
    }
}