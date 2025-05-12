using Microsoft.AspNetCore.Mvc;
using WebApplication11.Models;

namespace WebApplication11.Controllers
{
    public class SelectSeasonController : Controller
    {
        public IActionResult Index()
        {
            // Prepare the list of seasons
            var seasons = new List<SeasonViewModel>
            {
            new SeasonViewModel { ImageUrl = "/images/Seasons/Kış.png", CorrectSeason = "Kış" },
            new SeasonViewModel { ImageUrl = "/images/Seasons/İlkbahar.jpg", CorrectSeason = "İlkbahar" },
            new SeasonViewModel { ImageUrl = "/images/Seasons/Yaz.jpg", CorrectSeason = "Yaz" },
            new SeasonViewModel { ImageUrl = "/images/Seasons/Sonbahar.jpg", CorrectSeason = "Sonbahar" }
        };

            return View(seasons);
        }
    }
}
