using App.Core.DTOs.SlideDTOs;
using FluentValidation;

namespace App.Business.Validators.SlideValidators;

public class UpdateSlideDTOValidator : AbstractValidator<UpdateSlideDTO>
{
    public UpdateSlideDTOValidator()
    {
        RuleFor(x => x.Image)
            .Must(x => x == null || x.Length > 0)
            .WithMessage("Şəkil boş olmamalıdır.");
    }
}