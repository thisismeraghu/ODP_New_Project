using AutoMapper;
using ODP_Studio_Api.Application.Commands;
using ODP_Studio_Api.Application.DTOs.CommonDTOs;
using ODP_Studio_Api.Application.DTOs.RequestDTOs;
using ODP_Studio_Api.Application.DTOs.ResponseDTOs;
using ODP_Studio_Api.Application.Queries;
using ODP_Studio_Api.Domain.Entities;
using ODP_Studio_Api.Domain.ModelDTOs;
using ODP_Studio_Api.Domain.ValueObjects;
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

            CreateMap<Orphan, CreateOrphanRequestDto>().ReverseMap();

            CreateMap<PersonalInformationDto, PersonalInformation>().ReverseMap();

            CreateMap<UpdateOrphanRequestDto, UpdateOrphanCommand>().ReverseMap();

            CreateMap<Orphan, UpdateOrphanCommand>().ReverseMap();

            // CreateMap<Org, GetOrgByIdRequestDto>().ReverseMap();

            //CreateMap<OrgInfoDto, OrgResponseDto>().ReverseMap();


            // Map child entity and DTO
            CreateMap<OrphanInfoWithOrgDto, OrphanDetailsDto>()
                .ForMember(dest => dest.OrphansInfo, opt => opt.MapFrom(src => src.Orphan)).ReverseMap();
            CreateMap<OrgInfoDto, OrgResponseDto>()
                .ForMember(dest => dest.orgDto, opt => opt.MapFrom(src => src.Org)).ReverseMap();

            CreateMap<Org, OrgDto>().ReverseMap();
            CreateMap<Orphan, OrphanResponseDto>().ReverseMap();
            CreateMap<CreateOrphanResponseDto, OrphanSummaryDto>().ReverseMap();

            CreateMap< GetOrgByIdRequestDto, GetOrgByOrdIdQuery>()
                .ForMember(dest => dest.OrgId, opt => opt.MapFrom(src => src.OrgId)).ReverseMap();
            //CreateMap<Org, OrgDto>().ReverseMap();
            //CreateMap<Org, OrgResponseDto>().ReverseMap();

            // Map wrapper DTOs
            CreateMap<OrphanListResponseDto, OrphansListDto>()
                .ForMember(dest => dest.orphans, opt => opt.MapFrom(src => src.OrphansList));

            CreateMap<OrphansListDto, OrphanListResponseDto>()
                .ForMember(dest => dest.OrphansList, opt => opt.MapFrom(src => src.orphans));


            // CreateMap<Orphan, OrphanResponseDto>();
            CreateMap<CreateOrgResponseDto, OrgCreateSummaryDto>().ReverseMap();
            //CreateMap<CreateOrgCommand, CreateOrgRequestDto>().ReverseMap()
            //.ForMember(dest => dest.Org, opt => opt.MapFrom(src => src));
            CreateMap<CreateOrgRequestDto, Org>().ReverseMap()
                .ForMember(dest => dest.ModifiedInfo, opt=> opt.MapFrom(src => src.ModifiedInfo)).ReverseMap();
            CreateMap<CreateOrgRequestDto, Org>().ReverseMap()
                .ForMember(dest => dest.OrgInfo, opt => opt.MapFrom(src => src.OrgInfo)).ReverseMap();
            //CreateMap<CreateOrgCommand, Org>().ReverseMap()
            //     .ForPath(dest => dest.Org.ModifiedInfo, opt => opt.MapFrom(src => src.ModifiedInfo)).ReverseMap();
            //CreateMap<CreateOrgCommand, Org>().ReverseMap()
            //    .ForPath(dest => dest.Org.OrgInfo, opt => opt.MapFrom(src => src.ModifiedInfo)).ReverseMap();
            CreateMap<OrgInformationDto, OrgInformation>().ReverseMap();
            CreateMap<OrgInformationDto, OrgInformation>().ReverseMap();
            CreateMap<ModifiedInformationDto, ModifiedInfo>().ReverseMap();
            CreateMap<UpdateOrgRequestDto, UpdateOrgCommand>().ReverseMap();
            CreateMap<Org, UpdateOrgCommand>().ReverseMap();


        }
    }

}
