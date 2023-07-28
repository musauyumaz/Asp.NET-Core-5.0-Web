using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrnekUygulama.Model;

namespace OrnekUygulama.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult CreateProduct()
        {
            return View();
        }
        //[HttpPost]
        //public IActionResult VeriAl(IFormCollection datas)
        //{
        //    string value1 = datas["txtValue1"];
        //    string value2 = datas["txtValue2"];
        //    string value3 = datas["txtValue3"];

        //    return View();
        //}
        //[HttpPost]
        //public IActionResult VeriAl(string txtValue1,string txtValue2, string txtValue3)
        //{

        //    return View();
        //}
        //[HttpPost]
        //public IActionResult VeriAl(Model model)
        //{

        //    return View();
        //}
        [HttpPost]
        public IActionResult VeriAl(Product model)
        {

            return View();
        }
    }
    public class Model
    {
        public string TxtValue1 { get; set; }
        public string TxtValue2 { get; set; }
        public string TxtValue3 { get; set; }
    }
    public class MyClass
    {
        public string ProductName { get; set; }
        public int Quantity { get; set; }
    }
}
