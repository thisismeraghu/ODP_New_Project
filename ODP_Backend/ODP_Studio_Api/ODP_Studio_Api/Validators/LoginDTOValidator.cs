// Api/Validators/LoginDTOValidator.cs
using FluentValidation;
using ODP_Studio_Api.Application.DTOs;


namespace ODP_Studio_Api.Validators
{
    public class LoginDTOValidator : AbstractValidator<LoginRequestDto>
    {
        public LoginDTOValidator()
        {
            RuleFor(x => x.Username)
                .NotEmpty().WithMessage("Username is required.")
                .MinimumLength(3).WithMessage("Username must be at least 3 characters long.");

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("Password is required.")
                .MinimumLength(4).WithMessage("Password must be at least 6 characters long.");
        }
    }
}
