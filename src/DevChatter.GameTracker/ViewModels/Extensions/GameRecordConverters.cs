using System;
using DevChatter.GameTracker.Core.Model;

namespace DevChatter.GameTracker.ViewModels.Extensions
{
    public static class GameRecordConverters
    {
        public static GameRecord ToGameRecord(this CreateGameRecordViewModel src)
        {
            var gameRecord = new GameRecord();
            throw new NotImplementedException();
        }

        public static CreateGameRecordViewModel ToViewModel(this GameRecord src)
        {
            var viewModel = new CreateGameRecordViewModel();
            throw new NotImplementedException();
        }
    }
}