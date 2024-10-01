using ClinicSystem.Application.Utils;
using MediatR;

namespace ClinicSystem.Application.CQRS.Services.Commands;

public record CreateServiceNumber(string PatientEmail) : IRequest<Result<Guid>>;