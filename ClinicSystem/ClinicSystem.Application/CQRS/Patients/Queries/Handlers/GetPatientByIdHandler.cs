using ClinicSystem.Application.Constants.Errors;
using ClinicSystem.Application.Models.Patients.Responses;
using ClinicSystem.Application.Utils;
using ClinicSystem.Domain.Entities;
using ClinicSystem.Domain.Interfaces.Repositories;
using MediatR;

namespace ClinicSystem.Application.CQRS.Patients.Queries.Handlers;

public class GetPatientByIdHandler(IPatientRepository patientRepository) : IRequestHandler<GetPatientById, Result<PatientResponse?>>
{
    private readonly IPatientRepository _patientRepository = patientRepository;

    public async Task<Result<PatientResponse?>> Handle(GetPatientById request, CancellationToken cancellationToken)
    {
        try
        {
            Patient? patient = await _patientRepository.GetByIdAsync(request.Id);

            if (patient == null)
            {
                return Result<PatientResponse?>.Failure(PatientErrors.IdNotFound(request.Id));
            }

            PatientResponse? response = patient;

            return Result<PatientResponse?>.Success(response);
        }
        catch (Exception ex)
        {
            throw new Exception(ExceptionMessages.UnexpectedError(ex.Message));
        }
    }
}