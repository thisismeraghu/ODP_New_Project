using Azure.Core;
using Microsoft.EntityFrameworkCore;
using ODP_Studio_Api.Domain.Entities;
using ODP_Studio_Api.Domain.Exceptions;
using ODP_Studio_Api.Domain.Interfaces;
using ODP_Studio_Api.Domain.ModelDTOs;
using ODP_Studio_Api.Domain.ValueObjects;
using ODP_Studio_Api.Infrastructure.Persistence.Context;
using ODP_Studio_Api.Infrastructure.CommonFunction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ODP_Studio_Api.Infrastructure.Persistence.Repository
{
    public class OrgRepository : IOrgRepository
    {
        private readonly AppDbContext _dbconext;
        
        public OrgRepository(AppDbContext dbconext)
        {
            _dbconext = dbconext;
            
        }

        public async Task<OrgInfoDto> GetbyIdAsync(Guid orgId, CancellationToken cancellationToken)
        {
            var orgInfo = await _dbconext.Orgs.FirstOrDefaultAsync(o=> o.OrgId == orgId, cancellationToken);
            if (orgInfo == null)
                return null;
            // var result = _mapper.Map<OrgResponseDto>(await _mediator
            var dto = new OrgInfoDto
            {
                Org = orgInfo
            };
            return dto;
        }

        public async Task<OrgCreateSummaryDto> AddAsync(Org org, CancellationToken cancellationToken = default)
        {
            await _dbconext.Orgs.AddAsync(org, cancellationToken);
            await _dbconext.SaveChangesAsync(cancellationToken);
            var orgid = new OrgCreateSummaryDto { OrgId = org.OrgId };
            return orgid;
        }

        public async Task<OrgUpdateSummaryDto> UpdateAsync(Org request, CancellationToken cancellationToken = default)
        {
            var org = await _dbconext.Orgs.FindAsync(request.OrgId , cancellationToken);
            if (org == null)
            {
                throw new NotFoundException("Org does not exist or Created");
            }

            ObjectUpdator.UpdateNonNullProperties(org , request);
            await _dbconext.SaveChangesAsync(cancellationToken);
            return new OrgUpdateSummaryDto { status = true };


        }
    }
}
