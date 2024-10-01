using ClinicSystem.Application.Constants.Errors;
using ClinicSystem.Application.Models.Services.Responses;
using ClinicSystem.Application.Utils;
using ClinicSystem.Domain.Entities;
using ClinicSystem.Domain.Interfaces.Repositories;
using MediatR;

namespace ClinicSystem.Application.CQRS.Services.Queries.Handlers;

public class GetServiceByIdHandler(IServiceRepository serviceRepository) : IRequestHandler<GetServiceById, Result<ServiceResponse?>>
{
    private readonly IServiceRepository _serviceRepository = serviceRepository;

    public async Task<Result<ServiceResponse?>> Handle(GetServiceById request, CancellationToken cancellationToken)
    {
        try
        {
            Service? service = await _serviceRepository.GetByIdAsync(request.Id);

            if (service == null)
            {
                return Result<ServiceResponse?>.Failure(ServiceErrors.IdNotFound(request.Id));
            }

            ServiceResponse? response = service;

            return Result<ServiceResponse?>.Success(response);
        }
        catch (Exception ex)
        {
            throw new Exception(ExceptionMessages.UnexpectedError(ex.Message));
        }
    }
}