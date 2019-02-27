using DevChatter.GameTracker.Core.Model;

namespace DevChatter.GameTracker.ViewModels.Extensions
{
    public static class PlayerConverters
    {
        public static Player ToModel(this PlayerCreateModel createModel)
        {
            return new Player
            {
                FirstName = createModel.FirstName,
                LastName = createModel.LastName,
                EmailAddress = createModel.EmailAddress
            };
        }
    }
}