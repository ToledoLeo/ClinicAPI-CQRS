using ClinicSystem.Application.Constants.Errors;
using ClinicSystem.Application.Utils;
using ClinicSystem.Domain.Entities;
using ClinicSystem.Domain.Interfaces.Repositories;
using MediatR;

namespace ClinicSystem.Application.CQRS.Services.Commands.Handlers;

public class CreateServiceNumberHandler(IServiceRepository serviceRepository, IPatientRepository patientRepository) : IRequestHandler<CreateServiceNumber, Result<Guid>>
{
    private readonly IServiceRepository _serviceRepository = serviceRepository;
    private readonly IPatientRepository _patientRepository = patientRepository;

    public async Task<Result<Guid>> Handle(CreateServiceNumber request, CancellationToken cancellationToken)
    {
        try
        {
            Patient? patient = await _patientRepository.GetPatientByEmailAsync(request.PatientEmail);

            if (patient == null)
            {
                return Result<Guid>.Failure(PatientErrors.EmailNotFound(request.PatientEmail));
            }

            Service entity = new(patient!.Id);

            _serviceRepository.Add(entity);

            return Result<Guid>.Success(entity.Id);
        }
        catch (Exception ex)
        {
            throw new Exception(ExceptionMessages.UnexpectedError(ex.Message));
        }
    }
}