using Microsoft.AspNetCore.Mvc;

public class AlphabetController : Controller
{
    private readonly AlphabetService _alphabetService;

    public AlphabetController()
    {
        _alphabetService = new AlphabetService();
    }

    // Alfabeyi gösterecek olan başlangıç sayfası
    public IActionResult Index()
    {
        var alphabet = _alphabetService.GetAlphabet();
        return View(alphabet);
    }

    // Seçilen harf için resimleri döndüren fonksiyon
    public IActionResult GetImages(string letter)
    {
        var images = _alphabetService.GetImagesForLetter(letter);
        return PartialView("_ImagesPartial", images); // Partial view kullanarak dinamik yükleme yapılır
    }
}

