using AutoMapper;
using ODP_Studio_Api.Application.Commands;
using ODP_Studio_Api.Application.DTOs;
using ODP_Studio_Api.Domain.Entities;
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
            // Map from User entity to LoginResponseDto
            CreateMap<User, LoginResponseDto>()
            .ForMember(dest => dest.RoleType, opt =>
                opt.MapFrom(src => src.UserOrgRoles.FirstOrDefault() != null ? src.UserOrgRoles.First().RoleType.RoleType : string.Empty))
            .ForMember(dest => dest.OrgID, opt =>
                opt.MapFrom(src => src.UserOrgRoles.FirstOrDefault() != null ? src.UserOrgRoles.First().Org.OrgID : 0))
            .ForMember(dest => dest.OrgName, opt =>
                opt.MapFrom(src => src.UserOrgRoles.FirstOrDefault() != null ? src.UserOrgRoles.First().Org.OrgName : string.Empty))
            .ForMember(dest => dest.FirstName, opt =>
                opt.MapFrom(src => src.PersonalInfo.FirstName !=null ? src.PersonalInfo.FirstName : string.Empty))
            .ForMember(dest => dest.LastName, opt =>
                opt.MapFrom(src => src.PersonalInfo.LastName != null ? src.PersonalInfo.LastName : string.Empty));

            // Map from LoginRequestDto to LoginUserCommand if needed
            CreateMap<LoginRequestDto, LoginUserCommand>();
        }
    }
}
