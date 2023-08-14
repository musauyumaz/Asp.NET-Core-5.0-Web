using System.ComponentModel.DataAnnotations;

namespace OrnekUygulama.Models
{
    public class Product
    {
        [Required(ErrorMessage = "Lütfen propduct name'i giriniz.")]
        [StringLength(maximumLength: 100, ErrorMessage = "Lütfen product name'i en fazla 100 karakter giriniz.")]
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        [EmailAddress(ErrorMessage ="Lütfen doğru bir email adresi giriniz.")]
        public string Email { get; set; }
    }
}
