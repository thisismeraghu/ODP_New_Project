using ODP_Studio_Api.Application.DTOs.CommonDTOs;
using ODP_Studio_Api.Domain.Entities;
using ODP_Studio_Api.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ODP_Studio_Api.Application.DTOs.RequestDTOs
{
    public class GetOrgByIdRequestDto
    {
        public Guid OrgId { get; set; }
    }
}
