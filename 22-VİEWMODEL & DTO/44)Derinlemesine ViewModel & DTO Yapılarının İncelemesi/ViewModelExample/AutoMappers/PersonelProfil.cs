using AutoMapper;
using ViewModelExample.Models;
using ViewModelExample.Models.ViewModels;

namespace ViewModelExample.AutoMappers
{   //Bu sınıfı herhangi bir yerde bildirmeme gerek yok çünkü Automapper'da arka planda reflection'ı kullanıyor reflection üzerinden ilgili sınıfları bulup ona göre dönüşümü sağlıyor.
    public class PersonelProfil : Profile //Profile sınıflarının Automapper kütüphanesi altındaki Profile sınıfından türemesi gerekmektedir.
    {
        public PersonelProfil()
        {
            CreateMap<Personel, PersonelCreateVM>().ReverseMap();
        }
    }
}
