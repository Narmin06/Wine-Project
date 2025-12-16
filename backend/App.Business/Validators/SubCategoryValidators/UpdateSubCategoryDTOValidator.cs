using App.Core.DTOs.SubCategoryDTOs;
using FluentValidation;

namespace App.Business.Validators.SubCategoryValidators;

public class UpdateSubCategoryDTOValidator : AbstractValidator<UpdateSubCategoryDTO>
{
    public UpdateSubCategoryDTOValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .WithMessage("Alt-kategoriya adı tələb olunur.")
            .MaximumLength(100)
            .WithMessage("Alt-kategoriya adı 100 simvoldan çox olmamalıdır.");

        RuleFor(x => x.CategoryId)
            .NotEmpty()
            .WithMessage("Kategoriya ID-si tələb olunur.")
            .GreaterThan(0)
            .WithMessage("Kategoriya ID-si 0-dan böyük olmalıdır.");
    }
}