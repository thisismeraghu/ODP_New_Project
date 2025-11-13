using AutoMapper;
using MediatR;
using ODP_Studio_Api.Application.Commands;
using ODP_Studio_Api.Domain.Entities;
using ODP_Studio_Api.Domain.Exceptions;
using ODP_Studio_Api.Domain.Interfaces;
using ODP_Studio_Api.Domain.ModelDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ODP_Studio_Api.Application.CommandHandlers
{
    public class UpdateOrphanCommandHandler : IRequestHandler<UpdateOrphanCommand, bool>
    {
        private readonly IOrphanRepository _orphanRepository;
        private readonly IMapper _mapper;

        public UpdateOrphanCommandHandler(IOrphanRepository orphanRepository, IMapper mapper)
        {
            _orphanRepository = orphanRepository;
            _mapper = mapper;
        }

        public async Task<bool> Handle(UpdateOrphanCommand request, CancellationToken cancellationToken)
        {
            var orphan = _mapper.Map<Orphan>(request);
            var dto = await _orphanRepository.UpdateByIdAsync(orphan, cancellationToken);
            return true;
        }
    }
}
