using ClinicSystem.Application.Constants.Errors;
using ClinicSystem.Application.Models.Services.Responses;
using ClinicSystem.Application.Utils;
using ClinicSystem.Domain.Entities;
using ClinicSystem.Domain.Interfaces.Repositories;
using MediatR;

namespace ClinicSystem.Application.CQRS.Services.Queries.Handlers;

public class GetAllServicesHandler(IServiceRepository serviceRepository) : IRequestHandler<GetAllServices, Result<IEnumerable<ServiceResponse?>>>
{
    private readonly IServiceRepository _serviceRepository = serviceRepository;

    public async Task<Result<IEnumerable<ServiceResponse?>>> Handle(GetAllServices request, CancellationToken cancellationToken)
    {
        try
        {
            IEnumerable<Service> services = await _serviceRepository.GetAllAsync();

            var response = services.Select(service =>
            {
                ServiceResponse? serviceResponse = service;
                return serviceResponse;
            });

            return Result<IEnumerable<ServiceResponse?>>.Success(response ?? []);
        }
        catch (Exception ex)
        {
            throw new Exception(ExceptionMessages.UnexpectedError(ex.Message));
        }
    }
}