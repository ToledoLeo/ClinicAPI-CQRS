using ClinicSystem.Application.Constants.Errors;
using ClinicSystem.Application.Models.Patients.Responses;
using ClinicSystem.Application.Utils;
using ClinicSystem.Domain.Entities;
using ClinicSystem.Domain.Interfaces.Repositories;
using MediatR;

namespace ClinicSystem.Application.CQRS.Patients.Queries.Handlers;

public class GetAllPatientsHandler(IPatientRepository patientRepository) : IRequestHandler<GetAllPatients, Result<IEnumerable<PatientResponse?>>>
{
    private readonly IPatientRepository _patientRepository = patientRepository;

    public async Task<Result<IEnumerable<PatientResponse?>>> Handle(GetAllPatients request, CancellationToken cancellationToken)
    {
        try
        {
            IEnumerable<Patient> patients = await _patientRepository.GetAllAsync();

            var response = patients.Select(patient =>
            {
                PatientResponse? patientResponse = patient;
                return patientResponse;
            });

            return Result<IEnumerable<PatientResponse?>>.Success(response ?? []);
        }
        catch (Exception ex)
        {
            throw new Exception(ExceptionMessages.UnexpectedError(ex.Message));
        }
    }
}