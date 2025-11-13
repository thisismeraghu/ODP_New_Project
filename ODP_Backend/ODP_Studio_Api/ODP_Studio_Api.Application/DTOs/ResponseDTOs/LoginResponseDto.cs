using System;


namespace ODP_Studio_Api.Application.DTOs.ResponseDTOs
{
    public class LoginResponseDto
    {
        public Guid UserID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string RoleType { get; set; }
        public Guid OrgID { get; set; }
        public string OrgName { get; set; }
        public string Token { get; set; }
    }
}
