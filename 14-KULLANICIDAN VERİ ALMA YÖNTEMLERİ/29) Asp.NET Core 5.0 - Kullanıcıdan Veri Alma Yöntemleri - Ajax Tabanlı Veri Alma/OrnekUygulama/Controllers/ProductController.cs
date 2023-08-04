using Microsoft.AspNetCore.Mvc;

namespace OrnekUygulama.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult CreateProduct()
        {
            return View();
        }
        [HttpPost]
        public IActionResult VeriAl(AjaxData ajaxData)
        {
            return View();
        }
    }
    public class AjaxData
    {
        public string A { get; set; }
        public string B { get; set; }
    }
}
