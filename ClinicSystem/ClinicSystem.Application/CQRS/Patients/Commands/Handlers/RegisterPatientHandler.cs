using ClinicSystem.Application.Constants.Errors;
using ClinicSystem.Application.Utils;
using ClinicSystem.Domain.Entities;
using ClinicSystem.Domain.Interfaces.Repositories;
using MediatR;

namespace ClinicSystem.Application.CQRS.Patients.Commands.Handlers;

public class RegisterPatientHandler(IPatientRepository patientRepository) : IRequestHandler<RegisterPatient, Result<Guid>>
{
    private readonly IPatientRepository _patientRepository = patientRepository;

    public Task<Result<Guid>> Handle(RegisterPatient request, CancellationToken cancellationToken)
    {
        try
        {
            Patient entity = new(request.Name, request.Phone, request.Gender, request.Email);

            _patientRepository.Add(entity);

            return Task.FromResult(Result<Guid>.Success(entity.Id));
        }
        catch (Exception ex)
        {
            throw new Exception(ExceptionMessages.UnexpectedError(ex.Message));
        }
    }
}
