using Microsoft.AspNetCore.Mvc;
using OrnekUygulama.Models;

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
            Product product = new Product()
            {
                ProductName = "B Product",
                Quantity = 25
            };
            return View(product);
        }

        [HttpPost]
        public IActionResult CreateProduct(Product product)
        {
            return RedirectToAction("CreateProduct");
        }
    }
}
