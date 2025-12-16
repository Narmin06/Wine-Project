using App.Core.DTOs.CategoryDTOs;
using FluentValidation;

namespace App.Business.Validators.CategoryValidators;

public class CreateCategoryDTOValidator : AbstractValidator<CreateCategoryDTO>
{
    public CreateCategoryDTOValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .WithMessage("Kategoriya adı tələb olunur.")
            .MaximumLength(100)
            .WithMessage("Kategoriya adı 100 simvoldan çox olmamalıdır.");
    }
}