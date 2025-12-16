using App.Core.DTOs.ProductDetailDTOs;
using FluentValidation;

namespace App.Business.Validators.ProductDetailValidators;

public class UpdateProductDetailDTOValidator : AbstractValidator<UpdateProductDetailDTO>
{
    public UpdateProductDetailDTOValidator()
    {
        RuleFor(x => x.Title)
            .NotEmpty()
            .WithMessage("Başlıq tələb olunur.")
            .MaximumLength(200)
            .WithMessage("Başlıq 200 simvoldan çox olmamalıdır.");

        RuleFor(x => x.Description)
            .NotEmpty()
            .WithMessage("Təsvir tələb olunur.")
            .MaximumLength(2000)
            .WithMessage("Təsvir 2000 simvoldan çox olmamalıdır.");

        RuleFor(x => x.ProductId)
            .NotEmpty()
            .WithMessage("Məhsul ID-si tələb olunur.")
            .GreaterThan(0)
            .WithMessage("Məhsul ID-si 0-dan böyük olmalıdır.");
    }
}