using Microsoft.AspNetCore.Mvc;

namespace AreaExample.Areas.fatura_paneli.Controllers
{
    [Area("fatura_paneli")]// Bu controller'ları sen area'larla işaretlemesen bu uuygulamada aynı isimde birden fazla controller olamaz. Oluyorsa eğer bunları [Area()] ile işaretlemen lazım.
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            var data = TempData["data"].ToString();
            return View();
        }
    }
}
