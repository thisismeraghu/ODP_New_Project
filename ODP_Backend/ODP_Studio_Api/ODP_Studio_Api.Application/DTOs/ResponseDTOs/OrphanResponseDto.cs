using ODP_Studio_Api.Application.DTOs.CommonDTOs;
using ODP_Studio_Api.Domain.Entities;
using ODP_Studio_Api.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ODP_Studio_Api.Application.DTOs.ResponseDTOs
{
    public class OrphanResponseDto
    {
        public Guid OrphanId { get; set; }
        public PersonalInformationDto PersonalInfo { get; set; } = null!;
        public DateTime AdmissionDate { get; set; }
        public string CurrentStatus { get; set; }
        public bool IsActive { get; set; }
        public ModifiedInfo ModifiedInfo { get; set; } = null!;
       // public ICollection<OrphanOrgDto> OrphanOrgs { get; set; }
    }
}
