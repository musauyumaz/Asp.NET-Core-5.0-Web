using Microsoft.AspNetCore.Mvc;
using OrnekUygulama.Models;

namespace OrnekUygulama.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult GetProducts()
        {
            ViewBag.Mesaj = "Merhaba";
            User user = new User
            {
                LastName = "asfasfsadad"
            };

            return View(user);
        }
    }
}
