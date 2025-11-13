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
    public class GetAllOrphansByOrgIdQuery : IRequest<OrphansListDto>
    {
        public Guid OrgId { get; }
        public GetAllOrphansByOrgIdQuery(Guid orgId) => OrgId = orgId;
    }
}
