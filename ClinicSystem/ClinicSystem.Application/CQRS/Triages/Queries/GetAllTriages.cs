using ClinicSystem.Application.Models.Triages.Responses;
using ClinicSystem.Application.Utils;
using MediatR;

namespace ClinicSystem.Application.CQRS.Triages.Queries;

public record GetAllTriages() : IRequest<Result<IEnumerable<TriageResponse?>>>;