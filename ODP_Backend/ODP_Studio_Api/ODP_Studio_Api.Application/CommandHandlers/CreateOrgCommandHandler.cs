using AutoMapper;
using MediatR;
using ODP_Studio_Api.Application.Commands;
using ODP_Studio_Api.Domain.Entities;
using ODP_Studio_Api.Domain.Interfaces;
using ODP_Studio_Api.Domain.ModelDTOs;
using ODP_Studio_Api.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ODP_Studio_Api.Application.CommandHandlers
{
    public class CreateOrgCommandHandler : IRequestHandler<CreateOrgCommand, OrgCreateSummaryDto>
    {   
        public readonly IOrgRepository _orgRepository;
        public readonly IMapper _mapper;

        public CreateOrgCommandHandler(IOrgRepository orgRepository, IMapper mapper)
        {
            _orgRepository = orgRepository;
            _mapper = mapper;
        }
        public Task<OrgCreateSummaryDto> Handle(CreateOrgCommand request, CancellationToken cancellationToken)
        {
            var Org = _mapper.Map<Org>(request.Org);
            Org.OrgId = Org.OrgId == Guid.Empty ?  Guid.NewGuid() : Org.OrgId;

            var dto =  _orgRepository.AddAsync(Org, cancellationToken);
            return dto;
        }
    }
}
