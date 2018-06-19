using DevChatter.GameTracker.Infra.Bgg.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Xml.Serialization;

namespace DevChatter.GameTracker.Infra.Bgg
{
    public class GameDataService : IGameDataService
    {
        public List<(string, int)> GetPossibleGameIds(string gameTitle)
        {
            var possibleGameIds = new List<(string, int)> { };

            using (var client = new HttpClient())
            {

                string bggBaseUrl = "https://www.boardgamegeek.com/xmlapi2/";

                client.BaseAddress = new Uri(bggBaseUrl);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("text/xml"));

                string apiSearchQuery = $"search?query={gameTitle}";

                var result = client.GetAsync(apiSearchQuery).Result;

                if (result.IsSuccessStatusCode)
                {
                    XmlSerializer xmlSerializer = new XmlSerializer(typeof(items));

                    items boardgames = (items)xmlSerializer.Deserialize(result.Content.ReadAsStreamAsync().Result);

                    var possibleGame = boardgames?.item?.FirstOrDefault();
                    if (possibleGame != null)
                    {
                        possibleGameIds.Add((possibleGame.name.value, (int)possibleGame.id));
                    }
                }
            }

            return possibleGameIds;
        }
    }
}
