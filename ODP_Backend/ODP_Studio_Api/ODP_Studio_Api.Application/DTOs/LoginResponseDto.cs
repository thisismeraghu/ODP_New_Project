using System;


namespace ODP_Studio_Api.Application.DTOs
{
    public class LoginResponseDto
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
