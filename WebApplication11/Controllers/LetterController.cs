using Microsoft.AspNetCore.Mvc;

namespace WebApplication11.Controllers
{
    public class LetterController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
