using Microsoft.AspNetCore.Mvc;

namespace ModulerTasarimYapilanmasi.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.images = new List<string> { "doga3.jpg", "doga3.jpg", "doga2.jpg" };

            object o = new();
            return View(o);
        }
    }
}
