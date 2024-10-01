using ClinicSystem.Application.Models.Services.Responses;
using ClinicSystem.Application.Utils;
using MediatR;

namespace ClinicSystem.Application.CQRS.Services.Queries;

public record GetServiceById(Guid Id) : IRequest<Result<ServiceResponse?>>;
