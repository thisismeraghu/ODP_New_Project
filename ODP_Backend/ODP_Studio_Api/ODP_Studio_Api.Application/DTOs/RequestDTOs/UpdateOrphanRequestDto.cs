using ODP_Studio_Api.Application.DTOs.CommonDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ODP_Studio_Api.Application.DTOs.RequestDTOs
{
    public class UpdateOrphanRequestDto
    {
        public Guid OrphanId { get; set; }
        public PersonalInformationDto PersonalInfo { get; set; } = null!;
        public DateTime? AdmissionDate { get; set; }
        public string? CurrentStatus { get; set; }
    }
}
