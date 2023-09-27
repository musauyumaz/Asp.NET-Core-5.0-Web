using System.ComponentModel.DataAnnotations;
using ViewModelExample.Models.ViewModels;

namespace ViewModelExample.Models
{
    #region Senaryo 1 - Bir Model’in View’de ki Etkileşimine Uygun Parçasını Temsil Etme
    //Entity Model: veritabanında herhangi bir tabloya karşılık gelen model
    public class Personel// Personel class'ı benim entity model'ım. Şimdi ben bunun üzerinde gerekli validasyonları yaparım yapmam o benim o anki ihtiyacıma bağlı. 
    #endregion
    {
        public int Id { get; set; }
        [Required]
        public string Adi { get; set; }
        public string Soyadi { get; set; }
        [Required]
        [StringLength(13)]
        public string Pozisyon { get; set; }
        public int Maas { get; set; }
        [Required]
        public bool MedeniHal { get; set; }

        #region PersonelCreateVM -> Personel & Personel -> PersonelCreateVM Implicit Operator Overload (implicit/gizli/Bilinçsiz) 
        //public static implicit operator PersonelCreateVM(Personel model)//Parametredeki nesne verilen isimdeki nesneye dönüştürülücektir.
        //{
        //    return new PersonelCreateVM() 
        //    {
        //        Adi = model.Adi,
        //        Soyadi = model.Soyadi,
        //    };
        //}

        //public static implicit operator Personel(PersonelCreateVM model)//Parametredeki nesne verilen isimdeki nesneye dönüştürülücektir.
        //{
        //    return new Personel()
        //    {
        //        Adi = model.Adi,
        //        Soyadi = model.Soyadi,
        //    };
        //}
        ////Bu çalışmalar sayesinde implicit yani bilinçsiz bir şekilde tür dönüşümünü sağlamış oldum.
        ////Bu işlemleri birebir PersonelCreateVM sınıfında da gerçekleştirebilirdim. Bu yapılanmanın özelliği herhangi bir sınıfta bu dönüşümü yapabilmen.
        #endregion
        #region PersonelCreateVM -> Personel & Personel -> PersonelCreateVM Explicit Operator Overload (implicit/Açık/Bilinli) 
        public static explicit operator PersonelCreateVM(Personel model)//Parametredeki nesne verilen isimdeki nesneye dönüştürülücektir.
        {
            return new PersonelCreateVM()
            {
                Adi = model.Adi,
                Soyadi = model.Soyadi,
            };
        }

        public static explicit operator Personel(PersonelCreateVM model)//Parametredeki nesne verilen isimdeki nesneye dönüştürülücektir.
        {
            return new Personel()
            {
                Adi = model.Adi,
                Soyadi = model.Soyadi,
            };
        }
        //Bilinçli ve bilinçsiz tür dönüşümlerindeki mevzunun ta kendisi.
        #endregion
    }
}
