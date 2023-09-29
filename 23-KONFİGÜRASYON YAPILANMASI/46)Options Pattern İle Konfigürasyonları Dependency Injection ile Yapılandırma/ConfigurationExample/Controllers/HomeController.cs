using ConfigurationExample.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Diagnostics;

namespace ConfigurationExample.Controllers
{
    public class HomeController : Controller
    {
        #region Konfigürasyon Verilerini IConfiguration üzerinden Okuma
        //private readonly IConfiguration _configuration;

        //public HomeController(IConfiguration configuration)
        //{
        //    _configuration = configuration;
        //}

        //public IActionResult Index()
        //{
        //    string? host = _configuration["MailInfo:Host"];
        //    string? port = _configuration["MailInfo:Port"];

        //    MailInfo? mailInfo = _configuration.GetSection("MailInfo").Get<MailInfo>();//Tasarladığınız model hani Get metodunu kullanırken sana ilgili konfigürasyonu yapılandırıp(yani ilgili konfigürasyonu ilgili fonksiyonları kullanarak sen MailInfo türünden bir nesne elde ediyorsun Bu senin açından oradaki konfigürasyon dosyalarını dil açısından yapılandırılıp yani nesnel karşılığını elde ediyorsun böyle yapınaldırmış oluyorsun.) getiriyor ya işte bu durumda birebir bizim konfigürasyon isimleriyle property isimleri aynı olması gerekiyor. Eğer ki bir fark olursa ilgili eşleştirme yapılamayacağından dolayı Property'ler null değerinde gelebilir.
        //    //Options pattern buradaki yapılandırmayı dependency injection üzerinden tek elden yapmamızı sağlayan bir kolaylık sağlıyor. Sana her MailInfo lazım olduğunda _configuration.GetSection("MailInfo").Get<MailInfo>(); bu işlemi yapmak zorundasın. Yani her lazım olduğu yerde IConfiguration'ı enjekte edeceksin. Bu işlemden sonra geleceksin GetSection("MailInfo") diyip Get<MailInfo>(); deyip işlemi yapman gerekecek. Ölme eşşeğim ölme :)
        //    return View();
        //}
        #endregion
        #region Konfigürasyon Verilerini Options Pattern İle Okuma
        MailInfo _mailInfo;
        public HomeController(IOptions<MailInfo> mailInfo)
        {
            _mailInfo = mailInfo.Value;
        }
        public IActionResult Index()
        {
            
            return View();
        }
        #endregion
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