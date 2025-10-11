using Microsoft.EntityFrameworkCore;
using ODP_Studio_Api.Domain.Entities;
using ODP_Studio_Api.Domain.Interfaces;
using ODP_Studio_Api.Domain.ModelDTOs;
using ODP_Studio_Api.Domain.ValueObjects;
using ODP_Studio_Api.Infrastructure.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ODP_Studio_Api.Infrastructure.Persistence.Repository
{
    public class OrphanRepository : IOrphanRepository
    {
        private readonly AppDbContext _context;
        public OrphanRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Orphan orphan, CancellationToken cancellationToken = default)
        {
            await _context.Orphans.AddAsync(orphan, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
        }
    }

}
