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
using ODP_Studio_Api.Domain.Exceptions;
using System.Security.Cryptography;
using System.Threading;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace ODP_Studio_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrphanController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public OrphanController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrphan([FromBody] CreateOrphanRequestDto request, [FromServices] IValidator<CreateOrphanRequestDto> validator)
        {
            var validationResult = await validator.ValidateAsync(request);
            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors);
            var response = _mapper.Map<CreateOrphanResponseDto>(await _mediator.Send(new CreateOrphanCommand(request)));
            if (response == null)
                return BadRequest(new ApiResponse<string>($"Orphan creation failed", 400, new List<string> { "please check all the fields are correct" }));

            return Ok(new ApiResponse<CreateOrphanResponseDto>(response, "Orphan info retrieved successfully"));
        }

        /// <summary>
        /// Get orphan by OrphanId
        /// </summary>
        /// <param name="orphanId">Unique identifier for the orphan</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>Orphan details</returns>
        [HttpGet("{orphanId:guid}")]
        public async Task<IActionResult> GetOrphan(Guid orphanId, CancellationToken cancellationToken)
        {
            var query = _mapper.Map<GetOrphanByOrphanIdQuery>(orphanId);
            var response = _mapper.Map<OrphanDetailsDto>(await _mediator.Send(query, cancellationToken));
            if (response == null)
                return BadRequest(new ApiResponse<string>($"Orphan with ID {orphanId} not found.", 400, new List<string> { "orphan id does not exist" }));
            
            return Ok(new ApiResponse<OrphanDetailsDto>(response, "Orphan info retrieved successfully"));
        }

        /// <summary>
        /// Get all orphans by Organization ID
        /// </summary>
        /// <param name="orgId">Organization ID</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>List of orphans in the organization</returns>
        [HttpGet("organization/{orgId:guid}")]
        public async Task<IActionResult> GetAllOrphansByOrg(Guid orgId, CancellationToken cancellationToken)
        {
            var query = _mapper.Map<GetAllOrphansByOrgIdQuery>(orgId);
            var response = _mapper.Map<OrphanListResponseDto>(await _mediator.Send(query, cancellationToken));
            if (response == null)
                return BadRequest(new ApiResponse<string>("No Orphans found for this organization", 400, new List<string> { "Give valid org id"}));
                
            return Ok(new ApiResponse<OrphanListResponseDto>(response, "Orphans list retrieved successfully"));
        }

        [HttpPut("{orphanId:guid}")]
        public async Task<IActionResult> UpdateOrphan(Guid orphanId, [FromBody] UpdateOrphanRequestDto request)
        {
            if (orphanId != request.OrphanId)
            {
                return BadRequest("Orphan ID in URL and body do not match");
            }

            try
            {
                var command = _mapper.Map<UpdateOrphanCommand>(request);
                var response = _mapper.Map<bool>(await _mediator.Send(command));

                if (!response)
                {
                    return NotFound();
                }
                return NoContent(); // 204 No Content for successful update
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            // You can catch other exceptions here for global error handling or use middleware
        }
    }
}
