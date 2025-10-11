using ODP_Studio_Api.Domain.Entities;
using ODP_Studio_Api.Domain.ModelDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ODP_Studio_Api.Domain.Interfaces
{
    public interface IOrphanRepository
    {
        Task AddAsync(Orphan orphan, CancellationToken cancellationToken = default);
    }
}
