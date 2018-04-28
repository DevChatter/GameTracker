using System.Collections.Generic;

namespace DevChatter.GameTracker.Infra.Bgg
{
    public interface IGameDataService
    {
        List<(string, int)> GetPossibleGameIds(string gameTitle);
    }
}
