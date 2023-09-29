using ConfigurationExample.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ConfigurationExample.Controllers
{
    public class HomeController : Controller
    {
        #region IConfiguration Arayüzü Nedir?
        private readonly IConfiguration _configuration;
        public HomeController(IConfiguration configuration)//Ben buradakine bağımlı olacağım yani bu IConfiguration'ı kullanacam bu nesneyi bunu ben new'lemek istemiyorum sen bu bağımlılığı dışarıdan enjekte et. IoC'deki provider'dan ilgili nesneyi getiriyor. Gelen bu nesne buradaki parametre tarafından yakalanıyor. bu işlem neticesinde bunu bu uygulamada kullanabilmek istediğim yerde taşıyabilmek için global olarak tanımladığım readonly referans sayesinde işaretleyip her yerde global olarak kullanabilmekteyim.
        {
            _configuration = configuration;
        }
        #endregion

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            #region Indexer İle Veri Okuma Nasıl Yapılır?
            string? val1 = _configuration["OrnekMetin"];
            string? val2 = _configuration["Person"];
            string? val3 = _configuration["Person:Name"];
            string? val4 = _configuration["Person:Surname"];
            string? val5 = _configuration["Logging:LogLevel:Microsoft.Hosting.Lifetime"];
            #endregion
            #region GetSection Metodu İle Veri Okuma Nasıl Yapılır?
            var v6 = _configuration.GetSection("Person");
            var v7 = _configuration.GetSection("Person:Name");
            #endregion

            #region Get Metoduyla Verileri Uygun Nesneyle Eşleştirme​
            var v8 =_configuration.GetSection("Person").Get(typeof(Person));//Sen önce burada hangi section ile çalışacağını bildir ardından Get üzerinden ilgili section bir objeyse value olarak bir string dönmeyecekse bunu Get olarak belirli bir türde elde edebilirsin.
            var v9 = _configuration.GetSection("Person:Name").Get(typeof(String));
            #endregion
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}