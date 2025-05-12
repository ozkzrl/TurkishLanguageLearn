using Microsoft.AspNetCore.Mvc;
using WebApplication11.Models;

namespace WebApplication11.Controllers
{
    public class ThisWortTwoController : Controller
    {
        public IActionResult Index()
        {
            // Resim klasörü yolu
            string imagesPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images/harfresimleri");

            // Resim dosyalarını al
            var allImages = Directory.GetFiles(imagesPath)
                                     .Select(Path.GetFileName) // Sadece dosya adını al
                                     .ToList();

            // "mek" ve "mak" ile biten ve belirttiğiniz kelimeleri çıkar
            var excludedWords = new List<string>
    {
        "beş","mavi", "ışık", "casus", "çocuk", "dünya", "eğlence", "fakir", "genç", "ihtiyar", "iki", "japonya",
        "Jimnastikçi", "kadın", "ocak", "pahalı", "sarı", "sayı", "ok", "ülke", "üye", "yaz", "yirmi", "zengin"
    };

            var filteredImages = allImages
                .Where(img => !excludedWords.Contains(Path.GetFileNameWithoutExtension(img)) &&
                              !Path.GetFileNameWithoutExtension(img).EndsWith("mek") &&
                              !Path.GetFileNameWithoutExtension(img).EndsWith("mak"))
                .ToList();

            // 15 rastgele resim seç
            var randomImages = filteredImages.OrderBy(x => Guid.NewGuid())
                                             .Take(15)
                                             .Select(img =>
                                             {
                                                 var name = Path.GetFileNameWithoutExtension(img);
                                                 return new Photo
                                                 {
                                                     Name = name,
                                                     Src = $"/images/harfresimleri/{img}"
                                                 };
                                             })
                                             .ToList();

            return View(randomImages);
        }
    }
}

