using System.Collections.Generic;

namespace DevChatter.GameTracker.Infra.Bgg
{
    public class GameDataService : IGameDataService
    {
        public List<(string, int)> GetPossibleGameIds(string gameTitle)
        {

            //using (var client = new HttpClient())
            //{
            //    string bggBaseUrl = "https://www.boardgamegeek.com/xmlapi2/";

            //    client.BaseAddress = new System.Uri(bggBaseUrl);
            //    client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("text/xml"));

            //    foreach (var dbGame in gamesFromDb)
            //    {
            //        string apiSearchQuery = string.Format("search?query={0}&exact=1", dbGame.Title);
            //        string boardGameGeekLink = "test";

            //        var response = client.GetAsync(apiSearchQuery);

            //        if (response.Result.IsSuccessStatusCode)
            //        {
            //            string content = response.Result.Content.ReadAsStringAsync().Result;
            //        }

            //    }
            //}
            return new List<(string, int)> { ("Not A Game", 12312412) };
        }
    }
}
