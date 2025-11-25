using MediatR;
using ODP_Studio_Api.Domain.Entities;
using ODP_Studio_Api.Domain.ModelDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ODP_Studio_Api.Application.Queries
{
    public class GetOrgByOrdIdQuery: IRequest<OrgInfoDto>
    {
        public Guid OrgId { get; }
        public GetOrgByOrdIdQuery(Guid orgId)
        {
            OrgId = orgId;
        }

    }
}
