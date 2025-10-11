using AutoMapper;
using MediatR;
using ODP_Studio_Api.Application.Commands;
using ODP_Studio_Api.Domain.Entities;
using ODP_Studio_Api.Domain.Interfaces;
using ODP_Studio_Api.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ODP_Studio_Api.Application.CommandHandlers
{
    public class CreateOrphanCommandHandler : IRequestHandler<CreateOrphanCommand, Guid>
    {
        private readonly IOrphanRepository _orphanRepository;
        private readonly IMapper _mapper;

        public CreateOrphanCommandHandler(IOrphanRepository orphanRepository, IMapper mapper)
        {
            _orphanRepository = orphanRepository;
            _mapper = mapper;
        }

        public async Task<Guid> Handle(CreateOrphanCommand request, CancellationToken cancellationToken)
        {
            var orphan = _mapper.Map<Orphan>(request.Orphan);
            orphan.OrphanId = orphan.OrphanId == Guid.Empty ? Guid.NewGuid() : orphan.OrphanId;
            orphan.ModifiedInfo = orphan.ModifiedInfo ?? new ModifiedInfo(orphan.OrphanId, Guid.Empty, DateTime.Now, new DateTime());

            await _orphanRepository.AddAsync(orphan, cancellationToken);
            return orphan.OrphanId;
        }
    }
}
