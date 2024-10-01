using ClinicSystem.Application.Utils;
using MediatR;

namespace ClinicSystem.Application.CQRS.Triages.Commands;

public record UpdateTriageInfo(
    Guid Id,
    Guid SpecialityId,
    string Symptoms,
    string BloodPressure,
    decimal Weight,
    decimal Height) : IRequest<Result<bool>>;
