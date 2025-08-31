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
            CreateMap<User, LoginResponseDto>();

            // Map from LoginRequestDto to LoginUserCommand if needed
            CreateMap<LoginRequestDto, LoginUserCommand>();
        }
    }
}
