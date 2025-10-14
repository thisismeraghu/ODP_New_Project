using ODP_Studio_Api.Domain.Entities;
using ODP_Studio_Api.Domain.Interfaces;
using ODP_Studio_Api.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ODP_Studio_Api.Application.DTOs
{
    public class OrphanOrgDto
    {
        //public Guid OrphanOrgId { get; set; }
        //public Guid OrphanId { get; set; }
        public Guid OrgId { get; set; }
        public DateTime AssociationStartDate { get; set; }
        public DateTime? AssociationEndDate { get; set; }
        public bool IsActive { get; set; }
        public ModifiedInfo ModifiedInfo { get; private set; }           

    }
}
