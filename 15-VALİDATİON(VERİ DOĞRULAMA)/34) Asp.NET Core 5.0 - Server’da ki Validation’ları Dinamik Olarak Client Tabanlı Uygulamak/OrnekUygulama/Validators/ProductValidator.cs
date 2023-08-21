using FluentValidation;
using OrnekUygulama.Models;

namespace OrnekUygulama.Validators
{
    public class ProductValidator : AbstractValidator<Product>
    {
        public ProductValidator()
        {
            RuleFor(p => p.Email).NotNull().WithMessage("Email boş olamaz!");
            RuleFor(p => p.Email).EmailAddress().WithMessage("Lütfen doğru bir Email giriniz.");

            RuleFor(p => p.ProductName).NotNull().NotEmpty().WithMessage("Lütfen product name'i boş geçmeyiniz.");
            RuleFor(p => p.ProductName).MaximumLength(100).WithMessage("Lütfen product name'i 100 karakterden fazla girmeyiniz.");
        }
    }
}
