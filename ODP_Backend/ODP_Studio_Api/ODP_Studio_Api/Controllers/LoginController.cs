using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ODP_Studio_Api.Application.Commands;
using ODP_Studio_Api.Application.DTOs;
using System.Security.Authentication;

namespace ODP_Studio_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public LoginController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginRequestDto request)
        {
            var command = _mapper.Map<LoginUserCommand>(request);
            var response = await _mediator.Send(command);
            return Ok(response);
        }
    }
}
