using EnvironmentExample.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace EnvironmentExample.Controllers
{
    public class HomeController : Controller
    {
        #region IWebHostEnvironment Arayüzü İle Runtime Environment Ortamına Erişim
        //private IWebHostEnvironment _webHostEnvironment;

        //public HomeController(IWebHostEnvironment webHostEnvironment){
        //    _webHostEnvironment = webHostEnvironment;
        //} 
        #endregion
        #region Environment​ Değişkenlerin secrets.json ve appsettings.json Dosyalarını Ezmesi ​
        private IWebHostEnvironment _webHostEnvironment;
        private IConfiguration _configuration;
        public HomeController(IWebHostEnvironment webHostEnvironment, IConfiguration configuration)
        {
            _webHostEnvironment = webHostEnvironment;
            _configuration = configuration;
        }
        #endregion
        public IActionResult Index()
        {
            #region Docker Üzerinden Örnek
            ViewBag.Mesaj = _configuration["Mesaj"]; 
            #endregion

            #region Environment​ Değişkenlerin secrets.json ve appsettings.json Dosyalarını Ezmesi ​
            string? aDegeri = _configuration["a"]; 
            #endregion

            #region IWebHostEnvironment Arayüzü İle Runtime Environment Ortamına Erişim

            //if (_webHostEnvironment.IsDevelopment())
            //{
            //    ViewBag.Env = "Development";
            //}
            //else if (_webHostEnvironment.IsProduction())
            //{
            //    ViewBag.Env = "Production";
            //}
            //else if (_webHostEnvironment.IsStaging())
            //{
            //    ViewBag.Env = "Staging";
            //}
            //else if (_webHostEnvironment.IsEnvironment("Ahmet"))
            //{
            //    ViewBag.Env = "Ahmet";
            //}

            //_webHostEnvironment.IsDevelopment();// uygulamanın çalıştığı ortamı bu şekilde öğrenebilmekteyiz.
            //_webHostEnvironment.IsEnvironment("Ahmet");
            #endregion

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