using MediatR;
using ODP_Studio_Api.Application.DTOs.ResponseDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ODP_Studio_Api.Application.Commands
{
    public record LoginUserCommand(string Username, string Password) : IRequest<LoginResponseDto>;
}
