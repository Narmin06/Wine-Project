using App.Core.DTOs.SlideDTOs;
using FluentValidation;

namespace App.Business.Validators.SlideValidators;

public class CreateSlideDTOValidator : AbstractValidator<CreateSlideDTO>
{
    public CreateSlideDTOValidator()
    {
        RuleFor(x => x.Image)
            .NotNull()
            .WithMessage("Şəkil tələb olunur.")
            .Must(x => x.Length > 0)
            .WithMessage("Şəkil boş olmamalıdır.");
    }
}