using MediatR;
using ODP_Studio_Api.Application.DTOs.CommonDTOs;
using ODP_Studio_Api.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ODP_Studio_Api.Application.Commands
{
    public class UpdateOrphanCommand : IRequest<bool>
    {
        public Guid OrphanId { get; set; }
        public PersonalInformationDto PersonalInfo { get; set; } = null!;
        public DateTime AdmissionDate { get; set; }
        public string CurrentStatus { get; set; }
    }
}
