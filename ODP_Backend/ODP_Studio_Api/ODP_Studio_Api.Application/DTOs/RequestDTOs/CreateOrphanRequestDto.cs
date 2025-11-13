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
    public class CreateOrphanRequestDto
    {
        public Guid OrgId { get; set; } // OrphanOrg Model
        public PersonalInformationDto PersonalInfo { get; set; } = null;
        public DateTime AdmissionDate { get; set; }
        public string CurrentStatus { get; set; }
        public bool IsActive { get; set; }
        public DateTime AssociationStartDate { get; set; } // OrphanOrg Model
        public DateTime? AssociationEndDate { get; set; } // OrphanOrg Model
        public ModifiedInfo ModifiedInfo { get; set; }
    }
}
