using Microsoft.AspNetCore.Mvc;
using WebApplication11.Models; // DialogModel sınıfı için gerekli using
using System.Collections.Generic;
using System.Linq;

namespace WebApplication11.Controllers
{
    public class DialogController : Controller
    {
        // DialogModel listesi
        private readonly List<DialogModel> dialogs;

        // Constructor
        public DialogController()
        {
            // DialogModel listesi oluşturuluyor
            dialogs = new List<DialogModel>
            {
                new DialogModel
                {
                    Sentence = "Özkan: Merhaba",
                    DropZoneIds = new List<string> { "drop-1" },
                    MissingParts = new List<string> { "Merhaba" },
                    DragOptions = new List<string> { "Merhaba" }
                },
                new DialogModel
                {
                    Sentence = "Özkan: Benim adım Özkan. Sizin adınız ne?",
                    DropZoneIds = new List<string> { "drop-2" },
                    MissingParts = new List<string> { "Benim adım Seda." },
                    DragOptions = new List<string> { "Benim adım Seda."}
                },
                new DialogModel
                {
                    Sentence = "Özkan: Nasılsınız?",
                    DropZoneIds = new List<string> { "drop-3" },
                    MissingParts = new List<string> { "İyiyim. Teşekkür ederim. Siz nasılsınız?" },
                    DragOptions = new List<string> { "İyiyim. Teşekkür ederim. Siz nasılsınız?"}
                },
                new DialogModel
                {
                    Sentence = "Özkan: Ben de iyiyim. Teşekkür ederim. Tanıştığımıza memnun oldum.",
                    DropZoneIds = new List<string> { "drop-4" },
                    MissingParts = new List<string> { "Ben de tanıştığımıza memnun oldum." },
                    DragOptions = new List<string> { "Ben de tanıştığımıza memnun oldum."}
                },
                new DialogModel
                {
                    Sentence = "Özkan: Hoşçakal.",
                    DropZoneIds = new List<string> { "drop-5" },
                    MissingParts = new List<string> { "Güle güle" },
                    DragOptions = new List<string> { "Güle güle" }
                }
            };
        }

        // Index action, dialogs listesini View'e gönderir randomize
        public IActionResult Index()
        {
            var randomizedDialogs = dialogs.SelectMany(d => d.DragOptions).OrderBy(x => Guid.NewGuid()).ToList();
            ViewBag.RandomizedDragOptions = randomizedDialogs; // Rastgele sıralı ifadeleri View'e gönder

            return View(dialogs);
        }

        [HttpPost]
        public IActionResult CheckCorrectness([FromBody] Dictionary<string, string> data)
        {
            string draggedContent = data["draggedContent"];
            string dropZoneId = data["dropZoneId"];

            var correctAnswers = dialogs
                .Where(d => d.DropZoneIds != null && d.MissingParts != null)
                .SelectMany(d => d.DropZoneIds.Zip(d.MissingParts, (zone, part) => new { DropZone = zone, Part = part }))
                .ToDictionary(x => x.DropZone, x => x.Part);

            bool isCorrect = correctAnswers.ContainsKey(dropZoneId) && correctAnswers[dropZoneId] == draggedContent;

            return Json(new { isCorrect });
        }

    }
}

