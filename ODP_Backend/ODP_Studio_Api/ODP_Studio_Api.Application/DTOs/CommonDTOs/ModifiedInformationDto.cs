using ODP_Studio_Api.Application.DTOs.CommonDTOs;
using ODP_Studio_Api.Domain.Entities;
using ODP_Studio_Api.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ODP_Studio_Api.Application.DTOs.CommonDTOs
{
    public class ModifiedInformationDto
    {
        public Guid Fcb { get; set; }
        public Guid Lub { get; set; }
        public DateTime Fcd { get; set; }
        public DateTime Lud { get; set; }

        public ModifiedInformationDto() { }
        public ModifiedInformationDto(Guid fcb, Guid lub, DateTime fcd, DateTime lud)
        {
            Fcb = fcb;
            Lub = lub;
            Fcd = fcd;
            Lud = lud;
        }
    }
}
