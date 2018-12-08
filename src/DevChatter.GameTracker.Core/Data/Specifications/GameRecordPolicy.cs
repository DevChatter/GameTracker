using DevChatter.GameTracker.Core.Model;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace DevChatter.GameTracker.Core.Data.Specifications
{
    public class GameRecordPolicy : BaseEntityPolicy<GameRecord>, ISpecification<GameRecord>
    {
        protected GameRecordPolicy(Expression<Func<GameRecord, bool>> criteria)
            : base(criteria)
        {
        }

        public static GameRecordPolicy WithPlayer(int playerId)
        {
            return new GameRecordPolicy(
                gr => gr.PlayRecords.Any(pr => pr.Player.Id == playerId));
        }

        public static GameRecordPolicy ByGame(int gameId)
        {
            return new GameRecordPolicy(gr => gr.Game.Id == gameId);
        }
    }
}