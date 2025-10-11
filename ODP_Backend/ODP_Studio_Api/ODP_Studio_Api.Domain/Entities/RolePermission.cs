using ODP_Studio_Api.Domain.Interfaces;
using ODP_Studio_Api.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ODP_Studio_Api.Domain.Entities
{
    public class RolePermission : IHasModifiedInfo
    {
        public Guid RolePermissionId { get; set; }
        public int RolePermissionKey { get; set; }
        public Guid RoleId { get; set; }
        public Guid PermissionId { get; set; }
        public bool IsActive { get; set; }
        public ModifiedInfo ModifiedInfo { get; private set; }

        // Navigation properties (optional)
        public virtual Role Role { get; set; }
        public virtual Permission Permission { get; set; }
    }

}
