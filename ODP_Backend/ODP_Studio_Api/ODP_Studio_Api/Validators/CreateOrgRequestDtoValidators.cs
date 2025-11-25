using FluentValidation;
using ODP_Studio_Api.Application.DTOs.RequestDTOs;
using ODP_Studio_Api.Domain.ModelDTOs;
namespace ODP_Studio_Api.Validators
{
    public class CreateOrgRequestDtoValidators : AbstractValidator<CreateOrgRequestDto>
    {
        public CreateOrgRequestDtoValidators()
        {
            RuleFor(x => x.OrgName).NotEmpty().WithMessage("OrgName is required.");
            RuleFor(x => x.OrgInfo.Address.Value).NotEmpty().WithMessage("Address is required.");
            RuleFor(x => x.OrgInfo.ContactEmail.Value).NotEmpty().WithMessage("Contact Email is required");
            
        }
    }
}
