using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ODP_Studio_Api.Domain.Entities
{
    [Table("RoleType", Schema = "ODPLookUp")]
    public class Role
    {
        public int RoleTypeID { get; set; }
        public string RoleType { get; set; }
        public string RoleTypeDesc { get; set; }
        public bool IsActive { get; private set; }
        public string fcb { get; set; }
        public string lub { get; set; }
        public DateTime fcd { get; set; }
        public DateTime lud { get; set; }

    }
}
