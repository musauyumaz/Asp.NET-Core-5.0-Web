using Microsoft.AspNetCore.Mvc;

namespace AreaExample.Areas.yonetim_paneli.Controllers
{
    [Area("yonetim_paneli")]// Sen ana dizinin controller'ı değilsin sen yönetimPaneli isimli areanın controller'ısın. Dolayısıyla ne zaman buna bir istek gelir o zaman sen tetiklenceksin.
    // Çakışma ihtimali olan controller'ları bu şekilde ayırırız.
    // İsimlendirirken hangi area ise o ismi vermek daha iyidir.
    // Senin uygulamaya koymuş olduğun controller'lar yapısal olarak hangi klasörün içerisinde olduğu önemli değil. Controller'ı sen area attribute'uyla işaretlediğin zaman bu attribute sayesinde sen esasında bu controller'a farklı bir rota vermiş oluyorsun. Asıl area'nın getirmiş olduğu özellik bu.
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            TempData["data"] = "sebepsiz boş yere ayrılacaksan...";
            //return RedirectToAction("Index","Home");// Eğer bu şekilde hiçbir bildiride bulunmazsak herhangi bir area bildirisinde bulunmazsak mevcudiyetteki o anki area hangisiyse onun altında ilgili action'ı arayacaktır. İlgili controller nesnesi üretip ona göre actipn tetikleyecektir.
            return RedirectToAction("Index", "Home", new {area = "fatura_paneli" });
        }
    }
}
