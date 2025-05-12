using Microsoft.AspNetCore.Mvc;

namespace WebApplication11.Controllers
{
    public class ThisWortController : Controller
    {
        public IActionResult Index()
        {
            var photos = new List<object>
    {
        new { Name = "balık", Src ="/images/harfresimleri/balık.png" },
        new { Name = "cadde", Src = "/images/harfresimleri/cadde.png" },
        new { Name = "gemi", Src = "/images/harfresimleri/gemi.png" },
        new { Name = "uydu", Src ="/images/harfresimleri/uydu.png" },
        new { Name = "zehir", Src = "/images/harfresimleri/zehir.png" },
        new { Name = "zincir", Src = "/images/harfresimleri/zincir.png" },
        new { Name = "çiçek", Src ="/images/harfresimleri/çiçek.png" },
        new { Name = "uçak", Src = "/images/harfresimleri/uçak.png" },
        new { Name = "ütü", Src = "/images/harfresimleri/ütü.png" },
        new { Name = "daire", Src ="/images/harfresimleri/daire.png" },
        new { Name = "saç", Src = "/images/harfresimleri/saç.png" },
        new { Name = "palto", Src = "/images/harfresimleri/palto.png" },
        new { Name = "pantolon", Src = "/images/harfresimleri/pantolon.png" },
        new { Name = "parmak", Src = "/images/harfresimleri/parmak.png" },
        new { Name = "radio", Src = "/images/harfresimleri/radio.png" },
        new { Name = "fare", Src = "/images/harfresimleri/fare.png" },
        new { Name = "ekmek", Src = "/images/harfresimleri/ekmek.png" },
        new { Name = "at", Src = "/images/harfresimleri/at.png" },
        new { Name = "araba", Src = "/images/harfresimleri/araba.png" },
        new { Name = "bilgisayar", Src = "/images/harfresimleri/bilgisayar.png" },
    };
            return View(photos);
        }

    }
}
