using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using OrnekUygulama.Models;
using System.Collections.Generic;
using System.Linq;

namespace OrnekUygulama.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult CreateProduct()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateProduct(Product model)
        {
            if (ModelState.IsValid)
            {
                List<KeyValuePair<string, ModelStateEntry>> messages = ModelState.ToList();

                return View(model);
            }

            return View(model);
        }
    }
}
