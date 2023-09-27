using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ViewModelExample.Business;
using ViewModelExample.Models;
using ViewModelExample.Models.ViewModels;

namespace ViewModelExample.Controllers
{
    public class PersonelController : Controller
    {
        private readonly IMapper _mapper;

        public PersonelController(IMapper mapper)// Bu kütüphaneyi kullanabilmek için constructor'da bu IMapper'ı çağırmam gerekiyor. İlgili nesne dependency injection ile geleecktir.
        {
            _mapper = mapper;
        }

        [HttpPost]
        #region ViewModel'lar da Validation Durumları
        public IActionResult Index(PersonelCreateVM personelCreateVM)//Kullanıcıdan gelen verilerin sadece Adı ve Soyadı olması beklenirken kullanıcı ilgili forma gireecği verilere ben validasyon kontrolü yapmış olsaydım eğer ki parametre Personel olsaydı o durumda validasyonda takılı kalacaktık. Personel'in sadece adını soyadını kullanıyorsun view'de ama pozisyon ve medeni hali var bunlarda her ne kadar kullanmasanda validasyona takılacağından dolayı ilgili validasyonu bir türlü geçemeyecektik. Haliyle böyle durumlar yaşamayalım biz sadece yapmış olduğumuz operasyona özel veri modelleri oluşturalım diye zaten viewmodel oluşturuyoruz.
        //Dolayısıyla bu viewmodel yapılanmsaında validasyonlar hangi operasyondaysan o operasyona göre tasarlanmalı. Sen veri mi oluşturacaksın yani bir personel mi ekleyeceksin o zaman personel eklşemeye dair validasyonları senin PersonelCreateVM'da olmalı. Personel güncelleme mi yapacaksın personel güncellemeye dair viewmodel'da validasyonları uygulaman gerek. Bütün operasyonlara karşılık viewmodel oluşturabilirsiniz ve bu operasyonlara karşılık gelecek validasyonları ilgili viewmodel'larda tasarlamanız gerekecektir.
        {
            #region (Amelaus)Manuel Dönüştürme
            //....
            Personel p = new() { Adi = personelCreateVM.Adi, Soyadi = personelCreateVM.Soyadi };// Object initializer üzerinden olur. Öbür türlü referans üzerinde olur. İlgili property'lere erişip hangi property'e atama işlemi sağlayacaksanız bu şekilde viewmodel üzerinden ilgili atamayı yapmanız yeterli olacaktır. 
            #endregion
            #region Implicit
            Personel personel = personelCreateVM;// İleri programlamada implicit ve explicit operatör yapılanması sayesinde ilgili sınıfları aralarında polimorfizm ilişki olmaksızın farklı türdeki sınıfları birbirlerine atayabilmekteyiz.
            PersonelCreateVM vm = personel;
            #endregion
            #region Explicit
            Personel p1 = (Personel)personelCreateVM;
            PersonelCreateVM p2 = (PersonelCreateVM)p;
            #endregion
            #region Reflection
            Personel p3 = TypeConversion.Conversion<PersonelCreateVM, Personel>(personelCreateVM);
            PersonelListeVM plvm = TypeConversion.Conversion<Personel, PersonelListeVM>(p3);
            #endregion
            #region Automapper
            Personel p5 = _mapper.Map<Personel>(personelCreateVM);
            PersonelCreateVM pcvm = _mapper.Map<PersonelCreateVM>(p5);
            #endregion
            return View();
        } 
        #endregion
        #region Senaryo 1 - Bir Model’in View’de ki Etkileşimine Uygun Parçasını Temsil Etme
        public IActionResult Listele()
        {
            List<PersonelListeVM> personeller = new List<Personel>()
            {
                new(){Adi = "A", Soyadi = "B"},
                new(){Adi = "A1", Soyadi = "B"},
                new(){Adi = "A2", Soyadi = "B"},
                new(){Adi = "A3", Soyadi = "B"},
                new(){Adi = "A4", Soyadi = "B"},
                new(){Adi = "A5", Soyadi = "B"}

            }.Select(p => new PersonelListeVM() { Adi = p.Adi, Soyadi = p.Soyadi, Pozisyon = p.Pozisyon }).ToList();//Viewmodel'ım neyse ilgili kullanacağı muhattap olacağı veri türü neyse sadece o verilerle o verileri taşıyan bir nesne oluşturdum onu ilgili view'e client'a gönderiyorum.

            return View(personeller);
        }
        #endregion

        #region Senaryo 2 - Birden Fazla Nesneyi Tek Bir Nesneye Bağlama 
        public IActionResult Get()
        {
            //Üç tane veriyi Get'in view'ine göndermek istiyorsam gerçekleştirebileceğim 2 tane yol vardır.
            // Tuple nesne kullanabilirim. Tuple nesnesiyle gönderebilirim.
            //Tuple nesnesiyle zaten viewmodel'ın 2. sorumluluğu aynı işlemi görmekte yani birden fazla farklı türdeki nesneleri ya da aynı türde de olabilir birden fazla nesneyi tek bir nesnede birleştirmemizi sağlayan bir işlem görüyor çoklu nesne oluşturmamızı sağlıyor.
            (Personel, Musteri, Urun) nesne = (new Personel(), new Musteri(), new Urun());

            //Fiziksel bir viewmodel oluşturarakta bu birleştirme işlemini gerçekleştirebilirsin.
            XVM xVM = new XVM() { Personel = new(), Musteri = new(), Urun = new() };
            return View();
        } 
        #endregion
    }
}
