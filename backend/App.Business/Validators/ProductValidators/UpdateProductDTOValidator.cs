using App.Core.DTOs.ProductDTOs;
using FluentValidation;

namespace App.Business.Validators.ProductValidators;

public class UpdateProductDTOValidator : AbstractValidator<UpdateProductDTO>
{
    public UpdateProductDTOValidator()
    {
        RuleFor(x => x.Title)
            .NotEmpty()
            .WithMessage("Məhsul başlığı tələb olunur.")
            .MaximumLength(200)
            .WithMessage("Məhsul başlığı 200 simvoldan çox olmamalıdır.");

        RuleFor(x => x.Price)
            .NotEmpty()
            .WithMessage("Qiymət tələb olunur.")
            .GreaterThan(0)
            .WithMessage("Qiymət 0-dan böyük olmalıdır.");

        RuleFor(x => x.Image)
            .Must(x => x == null || x.Length > 0)
            .WithMessage("Məhsul şəkili boş olmamalıdır.");

        RuleFor(x => x.Liter)
            .NotEmpty()
            .WithMessage("Litraj tələb olunur.")
            .GreaterThan(0)
            .WithMessage("Litraj 0-dan böyük olmalıdır.");

        RuleFor(x => x.ProdDate)
            .NotEmpty()
            .WithMessage("İstehsal tarixi tələb olunur.")
            .LessThanOrEqualTo(DateTime.Now)
            .WithMessage("İstehsal tarixi gələcəkdə olmamalıdır.");

        RuleFor(x => x.Location)
            .NotEmpty()
            .WithMessage("Yerlokasiya tələb olunur.")
            .MaximumLength(200)
            .WithMessage("Yerlokasiya 200 simvoldan çox olmamalıdır.");

        RuleFor(x => x.Icon)
            .Must(x => x == null || x.Length > 0)
            .WithMessage("Şirkət ikonası boş olmamalıdır.");
    }
}