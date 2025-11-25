using MediatR;
using ODP_Studio_Api.Application.DTOs.RequestDTOs;
using ODP_Studio_Api.Domain.ModelDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ODP_Studio_Api.Application.Commands
{
    public class CreateOrgCommand : IRequest<OrgCreateSummaryDto>
    {
        public CreateOrgRequestDto Org { get; set; }
        public CreateOrgCommand(CreateOrgRequestDto org)
        {
            Org=org;
        }
    }
}
