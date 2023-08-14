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
            //if (!string.IsNullOrEmpty(model.ProductName) && model.ProductName.Length <= 100 && model.Email)
            //{

            //}
            //`ModelState` : MVC'de bir type'ın data annotations'larının durumunu kontrol eden ve geriye sonuç dönen bir property.
            if (!ModelState.IsValid)
            {
                //Loglama 
                //Kullanıcı bilgilendirme
                //ViewBag.HataMesaj = ModelState.Values.FirstOrDefault(x => x.ValidationState == ModelValidationState.Invalid).Errors[0].ErrorMessage;
                List<KeyValuePair<string, ModelStateEntry>> messages = ModelState.ToList();
                return View(model);
            }
            //İşleme/Operasyona/Algoritmaya tabi tutulur.

            return View();
        }
    }
}
