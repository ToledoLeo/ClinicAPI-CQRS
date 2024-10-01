using ClinicSystem.Application.CQRS.Patients.Commands;
using ClinicSystem.Application.CQRS.Patients.Queries;
using ClinicSystem.Application.Models.Patients.Requests;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ClinicSystem.WebApi.Controllers;

[ApiController]
[Route("api/patients")]
public class PatientController(IMediator mediator) : ControllerBase
{
    private readonly IMediator _mediator = mediator;

    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
    {
        try
        {
            var result = await _mediator.Send(new GetAllPatients());

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
            var result = await _mediator.Send(new GetPatientById(id));

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
    public async Task<IActionResult> CreateAsync([FromBody] CreatePatientRequest request)
    {
        try
        {
            var result = await _mediator.Send(new RegisterPatient(request.Name, request.Phone, request.Gender, request.Email));

            return Ok(result.Data);
        }
        catch (Exception e)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
        }
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Update(Guid id, [FromBody] UpdatePatientRequest request)
    {
        try
        {
            var result = await _mediator.Send(new UpdatePatient(id, request.Name, request.Phone, request.Gender, request.Email));

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
            var result = await _mediator.Send(new DeletePatient(id));

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