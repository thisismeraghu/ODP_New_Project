using ODP_Studio_Api.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ODP_Studio_Api.Domain.ModelDTOs
{
    public class OrphansListDto
    {
        public ICollection<Orphan> orphans { get; set; } = null!;
    }
}
