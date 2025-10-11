using AutoMapper;
using ODP_Studio_Api.Application.Commands;
using ODP_Studio_Api.Application.DTOs;
using ODP_Studio_Api.Domain.Entities;
using ODP_Studio_Api.Domain.ModelDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ODP_Studio_Api.Application.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<UserProfileWithOrgsDto, LoginResponseDto>()
                .ForMember(dest => dest.UserID, opt => opt.MapFrom(src => (Guid?)src.UserProfile.UserProfileId))
                .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src =>
                    src.UserProfile.UserType == "Orphan" && src.OrphanOrgs.Any()
                        ? src.OrphanOrgs.First().Orphan.PersonalInfo.FirstName
                        : src.UserProfile.UserType == "Manager" && src.ManagerOrgs.Any()
                            ? src.ManagerOrgs.First().Manager.PersonalInfo.FirstName
                            : string.Empty))
                .ForMember(dest => dest.LastName, opt => opt.MapFrom(src =>
                    src.UserProfile.UserType == "Orphan" && src.OrphanOrgs.Any()
                        ? src.OrphanOrgs.First().Orphan.PersonalInfo.LastName
                        : src.UserProfile.UserType == "Manager" && src.ManagerOrgs.Any()
                            ? src.ManagerOrgs.First().Manager.PersonalInfo.LastName
                            : string.Empty))
                .ForMember(dest => dest.RoleType, opt => opt.MapFrom(src => src.UserProfile.Role != null ? src.UserProfile.Role.RoleName : string.Empty))
                .ForMember(dest => dest.OrgID, opt => opt.MapFrom(src =>
                    src.OrphanOrgs.Any()
                        ? (Guid?)src.OrphanOrgs.First().Org.OrgId
                        : src.ManagerOrgs.Any()
                            ? (Guid?)src.ManagerOrgs.First().Org.OrgId
                            : null))
                .ForMember(dest => dest.OrgName, opt => opt.MapFrom(src =>
                    src.OrphanOrgs.Any()
                        ? src.OrphanOrgs.First().Org.OrgName
                        : src.ManagerOrgs.Any()
                            ? src.ManagerOrgs.First().Org.OrgName
                            : string.Empty));


            // Example Mapping for LoginRequestDto => LoginUserCommand
            CreateMap<LoginRequestDto, LoginUserCommand>();
        }
    }

}
