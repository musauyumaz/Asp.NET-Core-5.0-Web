using Microsoft.AspNetCore.Mvc;
using RouteYapilanmasi.Models;
using System.Diagnostics;

namespace RouteYapilanmasi.Controllers
{
    //[Route("[controller]/[action]")]
    [Route("ana")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        [Route("in/{id?}")]
        public IActionResult Index(int? id)
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}