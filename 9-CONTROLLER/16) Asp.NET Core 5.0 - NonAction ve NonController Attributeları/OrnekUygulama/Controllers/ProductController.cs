using Microsoft.AspNetCore.Mvc;

namespace OrnekUygulama.Controllers
{
    [NonController]
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            X();
            return View();
        }
        [NonAction]
        public void X()
        {
        }
    }
}
