using FluentValidation;
using ODP_Studio_Api.Application.DTOs.RequestDTOs;

namespace ODP_Studio_Api.Validators
{
    public class GetOrgByIdRequestValidator : AbstractValidator<GetOrgByIdRequestDto>
    {
        public GetOrgByIdRequestValidator() 
        {
            RuleFor(x => x.OrgId).NotEmpty().WithMessage("OrgID is required.");
        }
    }
}
