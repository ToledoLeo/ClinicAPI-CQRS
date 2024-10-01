using ClinicSystem.Application.Constants.Errors;
using ClinicSystem.Application.CQRS.Services.Queries;
using ClinicSystem.Application.Models.Services.Responses;
using ClinicSystem.Application.Utils;
using ClinicSystem.Domain.Entities;
using ClinicSystem.Domain.Interfaces.Repositories;
using MediatR;

namespace ClinicSystem.Application.CQRS.Services.Queries.Handlers;

public class GetNextTriageServiceHandler(IServiceRepository serviceRepository) : IRequestHandler<GetNextTriageService, Result<ServiceResponse?>>
{
    private readonly IServiceRepository _serviceRepository = serviceRepository;

    public async Task<Result<ServiceResponse?>> Handle(GetNextTriageService request, CancellationToken cancellationToken)
    {
        try
        {
            Service? entity = await _serviceRepository.GetNextTriageServiceAsync();

            if (entity == null)
            {
                return Result<ServiceResponse?>.Failure(ServiceErrors.TriageServiceNotFound);
            }

            return Result<ServiceResponse?>.Success(entity);
        }
        catch (Exception ex)
        {
            throw new Exception(ExceptionMessages.UnexpectedError(ex.Message));
        }
    }
}