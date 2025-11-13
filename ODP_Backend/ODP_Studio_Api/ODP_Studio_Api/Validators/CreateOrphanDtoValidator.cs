using FluentValidation;
using ODP_Studio_Api.Application.DTOs.RequestDTOs;

namespace ODP_Studio_Api.Validators
{
    public class CreateOrphanDtoValidator : AbstractValidator<CreateOrphanRequestDto>
    {
        public CreateOrphanDtoValidator()
        {
            RuleFor(x => x.PersonalInfo.FirstName)
                .NotEmpty().WithMessage("FirstName is required.")
                .MinimumLength(3).WithMessage("FirstName must be at least 3 characters long.");
        }
    }
}
