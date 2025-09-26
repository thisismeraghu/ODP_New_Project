using AutoMapper;
using FluentValidation;
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
        private readonly IValidator<LoginRequestDto> _loginValidator;

        public LoginController(IMediator mediator, IMapper mapper, IValidator<LoginRequestDto> loginValidator)
        {
            _mediator = mediator;
            _mapper = mapper;
            _loginValidator = loginValidator;
        }

        [HttpPost]
        public async Task<ActionResult<LoginResponseDto>> Login([FromBody] LoginRequestDto request, [FromServices] IValidator<LoginRequestDto> validator)
        {
            var validationResult = await _loginValidator.ValidateAsync(request);
            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors);

            var command = _mapper.Map<LoginUserCommand>(request);
            var response = await _mediator.Send(command);
            return Ok(_mapper.Map<LoginResponseDto>(response));
        }
    }
}
