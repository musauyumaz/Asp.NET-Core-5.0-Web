using Microsoft.AspNetCore.Mvc;
using OrnekUygulama.Models;

namespace OrnekUygulama.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult GetProducts()
        {
            Product product = new();

            //Veri üretildi....
            //ViewResult result = View(); //--> İlgili action ismiyle birebir aynı olan view'i tetikler.
            ViewResult result = View("Ahmet"); // --> İlgili action'ı belirtilen view ismindeki view dosyasını render eder.

            //return View();
            return result;
        }
    }
}
