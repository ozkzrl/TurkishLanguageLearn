using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using WebApplication11.Models;

public class MonthController : Controller
{
    public IActionResult Index()
    {
        // Türk ayları listesini karıştırarak frontend'e gönder
        var months = new List<string>
        {
            "Ocak", "Şubat", "Mart", "Nisan", "Mayıs", "Haziran",
            "Temmuz", "Ağustos", "Eylül", "Ekim", "Kasım", "Aralık"
        };

        // Ayları karıştır
        var random = new Random();
        var shuffledMonths = months.OrderBy(x => random.Next()).ToList();

        var model = new MonthViewModel
        {
            Months = shuffledMonths
        };

        return View(model);
    }

    // Doğru sıralamayı kontrol eden bir endpoint
    [HttpPost]
    public IActionResult CheckOrder([FromBody] List<string> sortedMonths)
    {
        var correctOrder = new List<string>
        {
            "Ocak", "Şubat", "Mart", "Nisan", "Mayıs", "Haziran",
            "Temmuz", "Ağustos", "Eylül", "Ekim", "Kasım", "Aralık"
        };

        bool isCorrect = correctOrder.SequenceEqual(sortedMonths);
        return Json(new { success = isCorrect });
    }
}
