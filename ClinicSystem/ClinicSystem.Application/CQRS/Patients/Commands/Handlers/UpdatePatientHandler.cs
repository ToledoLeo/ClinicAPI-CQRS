using ClinicSystem.Application.Constants.Errors;
using ClinicSystem.Application.Utils;
using ClinicSystem.Domain.Entities;
using ClinicSystem.Domain.Interfaces.Repositories;
using MediatR;

namespace ClinicSystem.Application.CQRS.Patients.Commands.Handlers;

public class UpdatePatientHandler(IPatientRepository patientRepository) : IRequestHandler<UpdatePatient, Result<bool>>
{
    private readonly IPatientRepository _patientRepository = patientRepository;

    public async Task<Result<bool>> Handle(UpdatePatient request, CancellationToken cancellationToken)
    {
        try
        {
            Patient? entity = await _patientRepository.GetByIdAsync(request.Id);

            if (entity == null)
            {
                return Result<bool>.Failure(PatientErrors.IdNotFound(request.Id));
            }

            entity.Update(request.Name, request.Phone, request.Gender, request.Email);

            _patientRepository.Update(entity);

            return Result<bool>.Success(true);
        }
        catch (Exception ex)
        {
            throw new Exception(ExceptionMessages.UnexpectedError(ex.Message));
        }
    }
}