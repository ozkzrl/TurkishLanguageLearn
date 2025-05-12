using WebApplication11.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

public class SahisController : Controller
{
    public IActionResult Index()
    {
        var zamirler = new List<EvModel>
        {
            new EvModel { Zamir = "Ben", EvFormu = "uzunum" },
            new EvModel { Zamir = "Sen", EvFormu = "uzunsun" },
            new EvModel { Zamir = "O", EvFormu = "uzun" },
            new EvModel { Zamir = "Biz", EvFormu = "uzunuz" },
            new EvModel { Zamir = "Siz", EvFormu = "uzunsunuz" },
            new EvModel { Zamir = "Onlar", EvFormu = "uzunlar" }
        };

        // "Ev" kelimelerini rastgele sıraya koyuyoruz.
        var shuffledEvFormlari = zamirler.OrderBy(x => System.Guid.NewGuid()).ToList();

        ViewBag.Zamirler = zamirler;           // Doğru sıralama için
        ViewBag.ShuffledEvFormlari = shuffledEvFormlari; // Rastgele sıralı
        return View();
    }
}
