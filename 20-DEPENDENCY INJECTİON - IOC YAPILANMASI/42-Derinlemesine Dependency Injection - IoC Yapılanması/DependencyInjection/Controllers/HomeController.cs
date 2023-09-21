using DependencyInjection.Models;
using DependencyInjection.Services;
using DependencyInjection.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace DependencyInjection.Controllers
{
    public class HomeController : Controller
    {
        //private readonly ILog _log;
        //public HomeController(ILog log)//Container'daki ILog türündeki nesne her neyse sen onu buraya getir bir bakayım diyorsun. Artık ilgili nesneyi sana buraya getirecektir. 
        //                               //İlgili nesneyi property/field olarak global bir hale getireceksin ardından bu global property'i istediğin yerde kullanacaksın.
        //{
        //    _log = log;
        //}

        public IActionResult Index([FromServices]ILog log)// Herhangi bir post neticesinde beklemeyeceksem direkt container'dan gelen nesneyle eşleştirilmesini bekleyeceksem [FromServices] attribute'unu kullanmam yeterli olacaktır.
                                                          //ILog log türünden olan bu değeri kardeşim Services'tan yani container'dan getir buradaki parametreye bağla.
        {
            //Index'e istek geldiği zaman Console'a ya da text'e bir log atacaksam eğer burada ilgili servise erişmek ve bu serviste ilgili gerekli fonksiyonları çağırıp Loglama işlemini sağlamak. Sen eğer bu servislere erişmeye çalışırken eğer ki burada `new` operatörünü ilgili servislerden nesne üretiyorsan işte burada bağımlılık söz konusudur. Bu kod tehlikelidir. Çünkü senin bağımlılık yarattığın bu servisle bu yapılanmada yarın bir değişiklik olabilir. ConsoleLog tuttuğunu herhangi bir noktada TextLog'una dönüştürme yapman gerekebilir. Böyle bir durumda davranışın/ihtiyacın değiştiği taktirde kaynak kodu gelip değiştirme durumu zaten bizim için yeterli bir handikaptır.
            // İlk başta benim buradaki bağımlılığı soyutlamam lazım. Benim burada new operatörüyle ilgili servisleri oluşturmamam lazım. Bunun içinde Dependency Injection'dan yararlanacağız.
            // IoC yapılanmasıyla Dependency Injection'ı desteklersem daha efektif bir sonuca varabilirim. Dolayısıyla benim IoC yapılanması kullanmam lazım yeri gelecek Console'u yeri gelecek Text'i ilgili IoC'in bana sağlamıl olduğu controller'a yerleştireceğim hem burada bağımlılıklarımı soyutlamış olacam hem de yönetimi tersine dönüştürmüş olacağım. Kontrol tersine dönmüş olacak ben hangisini kullanmak istiyorsam sistem onu kullanıp ona göre işlem gerçekleştirecek. Dolayısıyla ideal tasarıma kavuşmuş olacağız.


            //ConsoleLog log = new();
            //log.Log();
            //TextLog log = new();
            //log.Log();

            //_log.Log();// Buradaki log'a ne geldiği önemli değil. Console'mu geldi Text'mi geldi farketmiyor artık bir standardı var. 
            log.Log();
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