using Microsoft.AspNetCore.Mvc;
using OrnekUygulama.Models;
using OrnekUygulama.Models.ViewModels;

namespace OrnekUygulama.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult GetProducts()
        {
            Product product = new()
            {
                Id = 1,
                ProductName = "A Product",
                Quantity = 15
            };

            User user = new()
            {
                Id = 1,
                Name = "Musa",
                LastName = "Uyumaz"
            };

            //UserProduct userProduct = new()
            //{
            //    Product = product,
            //    User = user
            //};
            //return View(userProduct);

            (Product product, User user) userProduct = (product, user);
            return View();
        }
    }
}
