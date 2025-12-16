using App.Core.DTOs.ProductFieldDTOs;
using FluentValidation;

namespace App.Business.Validators.ProductFieldValidators;

public class UpdateProductFieldDTOValidator : AbstractValidator<UpdateProductFieldDTO>
{
    public UpdateProductFieldDTOValidator()
    {
        RuleFor(x => x.Key)
            .NotEmpty()
            .WithMessage("Açar tələb olunur.")
            .MaximumLength(100)
            .WithMessage("Açar 100 simvoldan çox olmamalıdır.");

        RuleFor(x => x.Value)
            .NotEmpty()
            .WithMessage("Qiymət tələb olunur.")
            .MaximumLength(500)
            .WithMessage("Qiymət 500 simvoldan çox olmamalıdır.");

        RuleFor(x => x.ProductId)
            .NotEmpty()
            .WithMessage("Məhsul ID-si tələb olunur.")
            .GreaterThan(0)
            .WithMessage("Məhsul ID-si 0-dan böyük olmalıdır.");
    }
}