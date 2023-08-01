using Microsoft.AspNetCore.Http;
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
        //public IActionResult VeriAl(string a,string b)
        public IActionResult VeriAl(QueryData queryData)
        {
            QueryString queryString = Request.QueryString; //Request yapılan endpoint'e query string parametresi eklenmiş mi eklenmemiş mi bununla ilgili bilgi verir.
            string a =Request.Query["a"].ToString();
            string b =Request.Query["b"].ToString();
            return View();
        }
    }
    public class QueryData
    {
        public int A { get; set; }
        public string B { get; set; }
    }
}
