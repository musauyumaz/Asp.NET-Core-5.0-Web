using System.ComponentModel.DataAnnotations;

namespace ViewModelExample.Models.ViewModels
{
    #region Senaryo 1 - Bir Model’in View’de ki Etkileşimine Uygun Parçasını Temsil Etme
    public class PersonelCreateVM//Ekstradan fazladan bir alan tutmuyor buradaki viewmodel'imiz ne taşıyacaksa o alana karşılık gelen property'lere sahip.
    {
        //ViewModel'da sadece taşınacak olan veri temsil edilir.
        [Required]
        public string Adi { get; set; }
        [Required]
        public string Soyadi { get; set; }
    }
    //Viewmodel ve DTO nesneleri kendi içerisinde modelledikleri datanın hangi verilerini/property'lerini alıyorlarsa birebir aynı isimde vermeye dikkat edin çünkü automapper gibi hazır kütüphanelerle dönüşümler sağlanırken burada birebir eşleşen isimler kullanılıyor. Ama bu zorunlu değildir. Farklı isimde kullanmayı çok fazla tavsiye etmeyiz.
    //Aynı ismi kullandığın sürece kodun gelişim ve bakım süresi de oradaki maliyette düşürülmüş olacaktır. 
    #endregion
    #region ViewModel'lar da Validation Durumları
    //Amma velakin bir personel eklenirken personel ekleme esnasında kullanmış olduğumuz buradaki viewmodel'ım sayesinde ilgil verileri alıyorum ya işte bu veriler gelirken benim iş kurallarım gereği bu veriler doğrulanabilir verilerse eğer haliyle bunu buradaki viewmodel üzerinde gerçekleştirmem gerekecek.
    //Validasyonları standart olarak iki farklı türde uygulayabiliriz. Data Annotations dediğimiz yapılanmayı kullanıyorduk bir diğeri de validation dediğimiz kütüphaneyi kullanıyorduk.
    //Elinde viewmodel varsa bu viewmodel üzerinden gelen veriyi kesinlikle viewmodel'da check etmen gerekecektir.
    //Bu viewmodel ilgili gelecek olan verilerin boş olup olmadığını zaten bana söyleyecek ve benimle o anki operasyon neyse personel ekleme durumunda gelen personel bilgisi her neyse ona göre gerekli validasyonları kontrol edecek. YUani maaşıyla yok personelin pozisyonuyla ilgili bir validasyon varsa personel ekleme durumunda o validasyonluk bir işimiz yok dolayısıyla ona bakmayacaktır. Biz olayı daha da özelleştirmiş spesifik hale getirmiş oluyoruyz bu şekilde yani viewmodel nereden bakarsanız bakın web uygulamalarında API yapılanmalarında vs olmazsa olmaz diyebiliriz. 
    #endregion
}
