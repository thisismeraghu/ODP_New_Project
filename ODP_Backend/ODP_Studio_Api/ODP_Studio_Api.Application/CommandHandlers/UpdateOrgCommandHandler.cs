using AutoMapper;
using MediatR;
using ODP_Studio_Api.Application.Commands;
using ODP_Studio_Api.Domain.Entities;
using ODP_Studio_Api.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ODP_Studio_Api.Application.CommandHandlers
{
    public class UpdateOrgCommandHandler : IRequestHandler<UpdateOrgCommand, bool>
    {
        public readonly IOrgRepository _orgRepository;
        public readonly IMapper _mapper;

        public UpdateOrgCommandHandler(IOrgRepository orgRepository, IMapper mapper)
        {
            _orgRepository = orgRepository;
            _mapper = mapper;
        }

        public async Task<bool> Handle(UpdateOrgCommand request, CancellationToken cancellationToken)
        {
            var org = _mapper.Map<Org>(request);
            var dto = await _orgRepository.UpdateAsync(org, cancellationToken);
            return true;

        }
    }
}
