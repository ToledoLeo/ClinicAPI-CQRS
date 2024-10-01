using ClinicSystem.Application.Constants.Errors;
using ClinicSystem.Application.Models.Services.Responses;
using ClinicSystem.Application.Utils;
using ClinicSystem.Domain.Entities;
using ClinicSystem.Domain.Interfaces.Repositories;
using MediatR;

namespace ClinicSystem.Application.CQRS.Services.Queries.Handlers;

public class GetNextMedicalServiceHandler(IServiceRepository serviceRepository) : IRequestHandler<GetNextMedicalService, Result<ServiceResponse?>>
{
    private readonly IServiceRepository _serviceRepository = serviceRepository;

    public async Task<Result<ServiceResponse?>> Handle(GetNextMedicalService request, CancellationToken cancellationToken)
    {
        try
        {
            Service? entity = await _serviceRepository.GetNextMedicalServiceAsync();

            if (entity == null)
            {
                return Result<ServiceResponse?>.Failure(ServiceErrors.MedicalServiceNotFound);
            }

            var result = await _serviceRepository.CompleteServiceAsync(entity.Id);

            if (!result)
            {
                throw new Exception(ServiceErrors.CompleteServiceError(entity.Id));
            }

            return Result<ServiceResponse?>.Success(entity);
        }
        catch (Exception ex)
        {
            throw new Exception(ExceptionMessages.UnexpectedError(ex.Message));
        }
    }
}