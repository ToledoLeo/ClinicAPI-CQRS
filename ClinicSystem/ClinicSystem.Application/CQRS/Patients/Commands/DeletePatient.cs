using ClinicSystem.Application.Utils;
using MediatR;

namespace ClinicSystem.Application.CQRS.Patients.Commands;

public record DeletePatient(Guid Id) : IRequest<Result<bool>>;
