using System;
using System.Data;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TradieApp.Application.Common.Wrappers;
using TradieApp.Application.Features.Jobs.Commands;
using TradieApp.Application.Features.Jobs.Queries;
using TradieApp.Domain.Entities;
using TradieApp.Domain.Enums;
using TradieApp.Presentation.Models;

namespace TradieApp.Presentation.Controllers.V1
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [ApiVersion("1.0")]
    public class JobsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public JobsController(IMediator mediator)
		{
            _mediator = mediator;
        }

        [HttpGet]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PagedCollection<Job>))]
        public async Task<IActionResult> GetJobs([FromQuery] GetJobsQuery query)
        {
            var response = await _mediator.Send(query).ConfigureAwait(false);
            return Ok(response);
        }

        [HttpPut("{id}")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PagedCollection<Job>))]
        public async Task<IActionResult> UpdateJobStatus(int id, [FromBody] UpdateJobStatusModel model)
        {
            var response = await _mediator.Send(new ChangeJobStatusCommand(id, model?.JobStatus ?? JobStatusEnum.none)).ConfigureAwait(false);
            return Ok(response);
        }
    }
}

