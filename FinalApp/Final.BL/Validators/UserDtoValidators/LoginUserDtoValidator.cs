using Final.BL.DTOs.UserDto;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final.BL.Validators.UserDtoValidators
{
    public class LoginUserDtoValidator: AbstractValidator<LoginUserDto>
    {
        public LoginUserDtoValidator()
        {
            RuleFor(x => x.UserNameOrEmail).NotEmpty().NotNull().WithMessage("Email or UserName is required.");
            RuleFor(x => x.Password).NotEmpty().NotNull().WithMessage("Password is required.");
        }
    }
}
