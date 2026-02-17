using AutoMapper;
using Azure;
using Azure.Core;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ODP_Studio_Api.Application.Commands;
using ODP_Studio_Api.Application.DTOs.RequestDTOs;
using ODP_Studio_Api.Application.DTOs.ResponseDTOs;
using ODP_Studio_Api.Application.Queries;
using ODP_Studio_Api.Common;
using ODP_Studio_Api.Domain.Entities;
using ODP_Studio_Api.Domain.ModelDTOs;
using System;
using static System.Net.Mime.MediaTypeNames;

namespace ODP_Studio_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class OrgController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        // private readonly IValidator _validator;

        public OrgController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
            //_validator = validator;
        }
        [HttpGet("{OrgId:Guid}")]
        public async Task<IActionResult> GetOrg(GetOrgByIdRequestDto OrgId, CancellationToken cancellationToken, [FromServices] IValidator<GetOrgByIdRequestDto> validator)
        {
            var validationResult = await validator.ValidateAsync(OrgId);
            var query = _mapper.Map<GetOrgByOrdIdQuery>(OrgId);
            //var response = await _mediator.Send(query, cancellationToken);


            var test = await _mediator.Send(query, cancellationToken);
            var response = _mapper.Map<OrgResponseDto>(await _mediator.Send(query, cancellationToken));
            if (response == null)
            {
                return BadRequest(new ApiResponse<string>($"Orphan with ID {OrgId} not found.", 400, new List<string> { "orphan id does not exist" }));

            }

            return Ok(new ApiResponse<OrgResponseDto>(response, "Orphan info retrieved successfully"));
        }
        [HttpPost]
        public async Task<IActionResult> CreateOrg([FromBody] CreateOrgRequestDto request, [FromServices] IValidator<CreateOrgRequestDto> validator)
        {
            //var test = _mapper.Map<CreateOrgCommand>(request);
            //var handlerResult = await _mediator.Send(test.Org);
            var validationResult = await validator.ValidateAsync(request);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);

            }

            var response = _mapper.Map<CreateOrgResponseDto>(await _mediator.Send(new CreateOrgCommand(request)));

            if (response == null)
                return BadRequest(new ApiResponse<string>($"Orphan creation failed", 400, new List<string> { "please check all the fields are correct" }));

            return Ok(new ApiResponse<CreateOrgResponseDto>(response, "Org info retrieved successfully"));
        }

        [HttpPut("{OrgId:Guid}")]

        public async Task<IActionResult> UpdateOrg(Guid OrgId, [FromBody] UpdateOrgRequestDto request, [FromServices] IValidator<UpdateOrgRequestDto> validator)
        {
            var validationResult = await validator.ValidateAsync(request);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);

            }
            if (OrgId != request.OrgId)
            { 
                return BadRequest(new ApiResponse<string>($"Org ID mismatch.", 400, new List<string> { "Orphan ID in URL and body do not match" }));
            }

            try
            {
                var command = _mapper.Map<UpdateOrgCommand>(request);
                var result = _mapper.Map<bool>(await _mediator.Send(command));

                if(!result)
                {
                    return NotFound();
                }
                return NoContent(); // 204 No Content for successful update
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }

        }






    }
}
