using System;
using System.Collections.Generic;
using ODP_Studio_Api.Application.DTOs.CommonDTOs;
using ODP_Studio_Api.Domain.Entities;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ODP_Studio_Api.Domain.ValueObjects;

namespace ODP_Studio_Api.Application.DTOs.CommonDTOs
{
    public class OrgInformationDto
    {
        public Address Address { get; set; }
        public Email ContactEmail { get; set; }
    }
}
