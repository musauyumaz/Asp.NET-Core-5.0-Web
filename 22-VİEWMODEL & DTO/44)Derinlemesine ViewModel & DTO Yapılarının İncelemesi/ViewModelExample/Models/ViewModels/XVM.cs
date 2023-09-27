namespace ViewModelExample.Models.ViewModels
{
    #region Senaryo 2 - Birden Fazla Nesneyi Tek Bir Nesneye Bağlama 
    public class XVM// Bu nesne sayesinde 3 tane nesneyi tek bir nesnede toplayıp ona göre işlem gerçekleştirip bir yere transfer edebiliyorum vs.
    {
        public Personel Personel { get; set; }
        public Urun Urun { get; set; }
        public Musteri Musteri { get; set; }
    } 
    #endregion
}
