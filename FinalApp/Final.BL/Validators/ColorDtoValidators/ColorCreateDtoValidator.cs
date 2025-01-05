using Final.BL.DTOs.Color;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final.BL.Validators.ColorDtoValidators
{
    public class ColorCreateDtoValidator: AbstractValidator<ColorCreateDto>
    {
        public ColorCreateDtoValidator()
        {
            RuleFor(x=> x.Title)
                .NotEmpty().NotNull().WithMessage("Category cannot be null")
                .MaximumLength(30).WithMessage("Title's max lenght must be 30 letters");
        }
    }
}
