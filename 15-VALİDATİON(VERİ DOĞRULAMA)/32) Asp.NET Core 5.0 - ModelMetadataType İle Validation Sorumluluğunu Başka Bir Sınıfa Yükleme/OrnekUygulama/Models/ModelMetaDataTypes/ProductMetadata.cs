using System.ComponentModel.DataAnnotations;

namespace OrnekUygulama.Models.ModelMetaDataTypes
{
    public class ProductMetadata
    {
        [Required(ErrorMessage ="Lütfen product name'i giriniz.")]
        [StringLength(100,ErrorMessage ="Lütfen product name'i en fazla 100 karakter giriniz.")]
        public string ProductName { get; set; }
        [EmailAddress(ErrorMessage ="Lütfen doğru bir email adresi giriniz.")]
        public string Email { get; set; }
    }
}
