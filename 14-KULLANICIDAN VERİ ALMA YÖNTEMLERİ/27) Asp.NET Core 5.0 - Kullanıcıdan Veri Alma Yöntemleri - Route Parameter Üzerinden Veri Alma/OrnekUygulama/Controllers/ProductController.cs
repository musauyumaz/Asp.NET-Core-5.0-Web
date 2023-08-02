using Microsoft.AspNetCore.Mvc;

namespace OrnekUygulama.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult GetProducts()
        {
            return View();
        }
        public IActionResult CreateProduct()
        {
            return View();
        }
        //public IActionResult VeriAl(string id,string a,string b)
        public IActionResult VeriAl(RouteData routeData)
        {
            var values = Request.RouteValues;
            return View();
        }
    }
    public class RouteData
    {
        public int Id { get; set; }
        public string A { get; set; }
        public string B { get; set; }
    }
}
