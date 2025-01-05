using Final.BL.DTOs.SizeDto;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final.BL.Validators.SizeDtoValidators
{
    public class SizeUpdateDtoValidator: AbstractValidator<SizeUpdateDto>
    {
        public SizeUpdateDtoValidator()
        {
            RuleFor(x => x.Title)
             .NotEmpty().NotNull().WithMessage("Category cannot be null")
             .MaximumLength(30).WithMessage("Title's max lenght must be 30 letters");
        }
    }
}
