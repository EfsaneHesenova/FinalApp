using Final.BL.DTOs.UserDto;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Final.BL.Validators.UserDtoValidators
{
    public class RegisterUserDtoValidator: AbstractValidator<RegisterUserDto>
    {
        public RegisterUserDtoValidator()
        {
            RuleFor(x => x.FirstName)
            .NotEmpty().WithMessage("First name cannot be empty")
            .MaximumLength(30).WithMessage("First name cannot be more than 30 characters");

            RuleFor(x => x.LastName)
                .NotEmpty().WithMessage("Last name cannot be empty")
                .MaximumLength(30).WithMessage("Last name cannot be more than 30 characters");

            RuleFor(x => x.UserName)
                .NotEmpty().NotNull().WithMessage("Username cannot be empty")
                .MaximumLength(30).WithMessage("Username cannot be more than 30 characters");

            RuleFor(x => x.Email)
                .NotEmpty().NotNull().WithMessage("Email cannot be empty")
                .Must(e => BeValidEmailAddress(e)).WithMessage("Invalid email address");


            RuleFor(x => x.Password)
                .NotEmpty().NotNull().WithMessage("Password cannot be empty");

            RuleFor(x => x.CheckPassword)
                .Equal(x => x.Password).WithMessage("Passwords do not match");
        }

        public bool BeValidEmailAddress(string email)
        {
            Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            Match match = regex.Match(email);
            if (match.Success) { return true; }
            return false;
        }
    }
}
