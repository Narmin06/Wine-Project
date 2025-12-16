using App.Core.DTOs.CategoryDTOs;
using FluentValidation;

namespace App.Business.Validators.CategoryValidators;

public class UpdateCategoryDTOValidator : AbstractValidator<UpdateCategoryDTO>
{
    public UpdateCategoryDTOValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .WithMessage("Kategoriya adı tələb olunur.")
            .MaximumLength(100)
            .WithMessage("Kategoriya adı 100 simvoldan çox olmamalıdır.");
    }
}