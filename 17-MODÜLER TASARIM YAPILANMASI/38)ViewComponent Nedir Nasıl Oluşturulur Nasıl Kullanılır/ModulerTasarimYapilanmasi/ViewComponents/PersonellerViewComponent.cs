using Microsoft.AspNetCore.Mvc;
using ModulerTasarimYapilanmasi.Models;

namespace ModulerTasarimYapilanmasi.ViewComponents
{
    [NonViewComponent]
    public class PersonellerViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke(int id)
        {
            List<Personel> datas = new()
            {
                new(){Adi="Şuayip",Soyadi="Abi"},
                new(){Adi="Hüseyin",Soyadi="Sümer"},
                new(){Adi="Rıfkı",Soyadi="Bilmemneoğlu"},
                new(){Adi="Şakir",Soyadi="Çorumlu"},
                new(){Adi="Hilmi",Soyadi="Celayir"}
            };
            return View(datas);
        }
    }
}
