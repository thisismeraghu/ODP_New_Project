using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ODP_Studio_Api.Application.DTOs
{
    public class UserLoginInfoDto
    {
        public int UserID { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string RoleType { get; set; } = string.Empty;
        public int OrgID { get; set; }
        public string OrgName { get; set; } = string.Empty;
        public string Token { get; set; } = string.Empty;
    }

}
