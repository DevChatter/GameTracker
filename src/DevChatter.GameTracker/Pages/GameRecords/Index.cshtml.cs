using DevChatter.GameTracker.ViewModels;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;

namespace DevChatter.GameTracker.Pages.GameRecords
{
    public class IndexModel : PageModel
    {
        public void OnPost(GameRecordViewModel gameRecord)
        {
            Guid gameRecordGameId = gameRecord.GameId;
        }
    }
}