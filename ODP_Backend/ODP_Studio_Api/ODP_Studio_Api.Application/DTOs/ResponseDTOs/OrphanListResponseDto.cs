using ODP_Studio_Api.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ODP_Studio_Api.Application.DTOs.ResponseDTOs
{
    public class OrphanListResponseDto
    {
        public ICollection<OrphanResponseDto> OrphansList { get; set; } = null!;
    }
   
}
