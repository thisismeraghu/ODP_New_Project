using AutoMapper;
using Azure.Core;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ODP_Studio_Api.Application.Commands;
using ODP_Studio_Api.Application.DTOs;

namespace ODP_Studio_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrphanController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        private readonly IValidator<CreateOrphanRequestDto> _createOrphanRequestValidator;

        public OrphanController(IMediator mediator, IMapper mapper, IValidator<CreateOrphanRequestDto> createOrphanRequestValidator)
        {
            _mediator = mediator;
            _mapper = mapper;
            _createOrphanRequestValidator = createOrphanRequestValidator;
        }
        [HttpPost]
        public async Task<IActionResult> CreateOrphan([FromBody] CreateOrphanRequestDto request, [FromServices] IValidator<CreateOrphanRequestDto> validator)
        {
            var validationResult = await _createOrphanRequestValidator.ValidateAsync(request);
            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors);
            var orphanId = await _mediator.Send(new CreateOrphanCommand(request));
            return Ok(orphanId);
        }
    }
}
