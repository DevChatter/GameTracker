using DevChatter.GameTracker.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DevChatter.GameTracker.Pages.GameRecords
{
    public class IndexModel : PageModel
    {
        [BindProperty]
        public GameRecordViewModel GameRecord { get; set; }

        public void OnGet()
        {

        }
    }
}