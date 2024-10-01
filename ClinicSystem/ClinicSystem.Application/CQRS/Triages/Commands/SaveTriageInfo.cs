using ClinicSystem.Application.Utils;
using MediatR;

namespace ClinicSystem.Application.CQRS.Triages.Commands;

public record SaveTriageInfo(Guid ServiceId, Guid SpecialityId, string Symptoms, string BloodPressure, decimal Weight, decimal Height) : IRequest<Result<Guid>>;