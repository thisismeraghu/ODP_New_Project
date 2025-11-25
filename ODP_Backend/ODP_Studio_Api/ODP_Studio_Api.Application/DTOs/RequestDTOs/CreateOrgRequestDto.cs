using ODP_Studio_Api.Application.DTOs.CommonDTOs;
using ODP_Studio_Api.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ODP_Studio_Api.Application.DTOs.RequestDTOs
{
    public class CreateOrgRequestDto
    {
        public Guid OrgId { get; set; }
        public string OrgName { get; set; }
        public OrgInformationDto OrgInfo { get; set; }
        public string PhoneNumber { get; set; }
        public bool IsActive { get; set; }
        public ModifiedInformationDto ModifiedInfo { get; set; }
    }
}
