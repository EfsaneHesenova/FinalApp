using Final.BL.DTOs.CategoryDto;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final.BL.Validators.CategoryDtoValidators
{
    public class CategoryUpdateDtoValidator: AbstractValidator<CategoryUpdateDto>
    {
        public CategoryUpdateDtoValidator()
        {
            RuleFor(x=> x.Title)
                .NotEmpty().NotNull().WithMessage("Category cannot be null")
                .MaximumLength(30).WithMessage("Title's max lenght must be 30 letters");
            RuleFor(x=> x.Description)
                .MaximumLength(30).WithMessage("Description's max lenght must be 30 letters");
        }
    }
}
