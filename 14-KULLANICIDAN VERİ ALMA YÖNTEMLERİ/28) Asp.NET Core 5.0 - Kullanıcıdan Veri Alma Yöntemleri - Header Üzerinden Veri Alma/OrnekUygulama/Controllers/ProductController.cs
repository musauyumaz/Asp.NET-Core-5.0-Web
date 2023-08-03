using Microsoft.AspNetCore.Mvc;

namespace OrnekUygulama.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult VeriAl()
        {
            var headers = Request.Headers;
            return View();
        }
    }
}
