using ODP_Studio_Api.Domain.Entities;
using ODP_Studio_Api.Domain.ModelDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ODP_Studio_Api.Domain.Interfaces
{
    public interface IOrgRepository
    {
        Task<OrgInfoDto> GetbyIdAsync(Guid OrgId, CancellationToken cancellationToken);
        Task<OrgCreateSummaryDto> AddAsync(Org org, CancellationToken cancellationToken = default);
        Task<OrgUpdateSummaryDto> UpdateAsync(Org request, CancellationToken cancellationToken = default);
    }
}
