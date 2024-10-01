using ClinicSystem.Application.CQRS.Triages.Commands;
using ClinicSystem.Application.CQRS.Triages.Queries;
using ClinicSystem.Application.Models.Triages.Requests;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ClinicSystem.WebApi.Controllers;

[ApiController]
[Route("api/triages")]
public class TriageController(IMediator mediator) : ControllerBase
{
    private readonly IMediator _mediator = mediator;

    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
    {
        try
        {
            var result = await _mediator.Send(new GetAllTriages());

            return Ok(result.Data);
        }
        catch (Exception e)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
        }
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetByIdAsync(Guid id)
    {
        try
        {
            var result = await _mediator.Send(new GetTriageInfoById(id));

            if(result.IsFailure)
            {
                return NotFound(result.Message);
            }

            return Ok(result.Data);
        }
        catch (Exception e)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
        }
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsync([FromBody] CreateTriageRequest request)
    {
        try
        {
            var result = await _mediator.Send(new SaveTriageInfo(request.ServiceId, request.SpecialityId, request.Symptoms, request.BloodPressure, request.Weight, request.Height));

            return Ok(result.Data);
        }
        catch (Exception e)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
        }
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Update(Guid id, [FromBody] UpdateTriageRequest request)
    {
        try
        {
            var result = await _mediator.Send(new UpdateTriageInfo(id, request.SpecialityId, request.Symptoms, request.BloodPressure, request.Weight, request.Height));

            if (result.IsFailure)
            {
                return NotFound(result.Message);
            }

            return Ok(result.Data);
        }
        catch (Exception e)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
        }
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        try
        {
            var result = await _mediator.Send(new DeleteTriageInfo(id));

            if (result.IsFailure)
            {
                return NotFound(result.Message);
            }

            return Ok(result.Data);
        }
        catch (Exception e)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
        }
    }
}