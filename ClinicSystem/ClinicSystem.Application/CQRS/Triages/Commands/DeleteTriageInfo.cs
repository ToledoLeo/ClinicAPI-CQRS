using ClinicSystem.Application.Utils;
using MediatR;

namespace ClinicSystem.Application.CQRS.Triages.Commands;

public record DeleteTriageInfo(Guid Id) : IRequest<Result<bool>>;
