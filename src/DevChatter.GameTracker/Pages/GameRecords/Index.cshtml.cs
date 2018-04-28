using System;
using DevChatter.GameTracker.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

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