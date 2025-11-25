using MediatR;
using ODP_Studio_Api.Application.DTOs;
using ODP_Studio_Api.Application.Queries;
using ODP_Studio_Api.Domain.Entities;
using ODP_Studio_Api.Domain.Interfaces;
using ODP_Studio_Api.Domain.ModelDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ODP_Studio_Api.Application.QueryHandlers
{
    public class GetOrgByOrgIdQueryHandler : IRequestHandler<GetOrgByOrdIdQuery, OrgInfoDto>
    {
        private readonly IOrgRepository _orgRepository;

        public GetOrgByOrgIdQueryHandler (IOrgRepository orgRepository)
        {
            _orgRepository = orgRepository;
        }
        public async Task<OrgInfoDto> Handle (GetOrgByOrdIdQuery request, CancellationToken cancellationToken)
        {
            var result = await _orgRepository.GetbyIdAsync(request.OrgId , cancellationToken);
            return result;
        }
    }
}
