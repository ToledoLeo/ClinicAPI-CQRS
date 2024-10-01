using ClinicSystem.Application.Models.Patients.Responses;
using ClinicSystem.Application.Utils;
using MediatR;

namespace ClinicSystem.Application.CQRS.Patients.Queries;

public record GetPatientById(Guid Id) : IRequest<Result<PatientResponse?>>;
