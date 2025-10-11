using ODP_Studio_Api.Domain.Interfaces;
using ODP_Studio_Api.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ODP_Studio_Api.Domain.Entities
{
    public class Permission : IHasModifiedInfo
    {
        public Guid PermissionId { get; set; }
        public int PermissionKey { get; set; }
        public string PermissionName { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
        public ModifiedInfo ModifiedInfo { get; private set; }
    }
}
