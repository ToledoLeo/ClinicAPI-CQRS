using ClinicSystem.Application.Models.Services.Responses;
using ClinicSystem.Application.Utils;
using MediatR;

namespace ClinicSystem.Application.CQRS.Services.Queries;

public record GetAllServices : IRequest<Result<IEnumerable<ServiceResponse?>>>;
