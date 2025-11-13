using FluentValidation;
using ODP_Studio_Api.Application.DTOs.RequestDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ODP_Studio_Api.Application.Validators
{
    public class UpdateOrphanRequestDtoValidator  : AbstractValidator<UpdateOrphanRequestDto>
    {
        public UpdateOrphanRequestDtoValidator()
        {
            RuleFor(x => x.OrphanId).NotEmpty().WithMessage("Invalid Orphan ID");
        }
    }
}
