namespace ViewModelExample.Models.ViewModels
{
    #region Senaryo 1 - Bir Model’in View’de ki Etkileşimine Uygun Parçasını Temsil Etme
    public class PersonelListeVM//View'de kullanılacak olan datanın hangi verileri kullanılıyorsa onları temsil eden bir viewmodel oluşturdum haliyle benim controller'ım bu viewmodel'a uygun bir şekilde verileri üretmeli ve o şekilde view'e göndermeli ya da API'dan client'a göndermeli.
    {
        public string Adi { get; set; }
        public string Soyadi { get; set; }
        public string Pozisyon { get; set; }
    } 
    #endregion
}
