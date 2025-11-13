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
    public class GetOrphanByOrphanIdQueryHandler : IRequestHandler<GetOrphanByOrphanIdQuery, OrphanInfoWithOrgDto>
    {
        private readonly IOrphanRepository _repo;

        public GetOrphanByOrphanIdQueryHandler(IOrphanRepository repo)
        {
            _repo = repo;
        }

        public async Task<OrphanInfoWithOrgDto> Handle(GetOrphanByOrphanIdQuery request, CancellationToken cancellationToken)
        {
            var result = await _repo.GetByIdAsync(request.OrphanId, cancellationToken);
            return result;
            
        }
    }
}
