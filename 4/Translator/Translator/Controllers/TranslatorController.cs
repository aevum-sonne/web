using Microsoft.AspNetCore.Mvc;

namespace Translator.Controllers
{
    public class TranslationController : Controller
    {
        // GET
        public IActionResult Index()
        {
            return View();
        }
    }
}