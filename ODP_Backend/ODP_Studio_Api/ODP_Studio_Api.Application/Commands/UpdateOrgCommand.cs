using MediatR;
using ODP_Studio_Api.Application.DTOs.CommonDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ODP_Studio_Api.Application.Commands
{
    public class UpdateOrgCommand : IRequest<bool>
    {
        public Guid OrgId { get; set; }
        public string OrgName { get; set; } 
        public string PhoneNumber { get; set; }
        public bool IsActive { get; set; }
        public OrgInformationDto OrgInfo { get; set; }
    }
}
