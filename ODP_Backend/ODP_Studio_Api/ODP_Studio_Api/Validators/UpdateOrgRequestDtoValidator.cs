using FluentValidation;
using ODP_Studio_Api.Application.DTOs.RequestDTOs;
namespace ODP_Studio_Api.Validators
{
    public class UpdateOrgRequestDtoValidator : AbstractValidator<UpdateOrgRequestDto>
    {
        public UpdateOrgRequestDtoValidator()
        {
            RuleFor(x => x.OrgId).NotEmpty().WithMessage("Invalid Org ID");
        }
    }
}
