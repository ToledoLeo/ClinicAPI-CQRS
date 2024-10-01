using ClinicSystem.Application.CQRS.Services.Commands;
using ClinicSystem.Application.CQRS.Services.Queries;
using ClinicSystem.Application.Models.Services.Requests;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ClinicSystem.WebApi.Controllers;

[ApiController]
[Route("api/services")]
public class ServiceController(IMediator mediator) : ControllerBase
{
    private readonly IMediator _mediator = mediator;

    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
    {
        try
        {
            var result = await _mediator.Send(new GetAllServices());

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
            var result = await _mediator.Send(new GetServiceById(id));

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

    [HttpGet("triage-service/")]
    public async Task<IActionResult> GetNextTriageServiceAsync()
    {
        try
        {
            var result = await _mediator.Send(new GetNextTriageService());

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

    [HttpGet("medical-service/")]
    public async Task<IActionResult> GetNextMedicalServiceAsync()
    {
        try
        {
            var result = await _mediator.Send(new GetNextMedicalService());

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

    [HttpPost]
    public async Task<IActionResult> CreateServiceNumberAsync([FromBody] CreateServiceRequest request)
    {
        try
        {
            var result = await _mediator.Send(new CreateServiceNumber(request.PatientEmail));

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