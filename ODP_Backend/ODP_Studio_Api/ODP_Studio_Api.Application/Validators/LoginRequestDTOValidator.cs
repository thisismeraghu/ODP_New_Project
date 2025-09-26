using FluentValidation;
using ODP_Studio_Api.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ODP_Studio_Api.Application.Validators
{
    public class LoginResponseDtoValidator : AbstractValidator<LoginResponseDto>
    {
        public LoginResponseDtoValidator()
        {
            RuleFor(x => x.UserID)
                .GreaterThan(0).WithMessage("UserID must be greater than zero.");

            RuleFor(x => x.FirstName)
                .NotEmpty().WithMessage("FirstName is required.");

            RuleFor(x => x.LastName)
                .NotEmpty().WithMessage("LastName is required.");

            RuleFor(x => x.RoleType)
                .NotEmpty().WithMessage("RoleType is required.");

            RuleFor(x => x.OrgID)
                .GreaterThan(0).WithMessage("OrgID must be greater than zero.");

            RuleFor(x => x.OrgName)
                .NotEmpty().WithMessage("OrgName is required.");

            RuleFor(x => x.Token)
                .NotEmpty().WithMessage("Token is required.");
        }
    }

}
