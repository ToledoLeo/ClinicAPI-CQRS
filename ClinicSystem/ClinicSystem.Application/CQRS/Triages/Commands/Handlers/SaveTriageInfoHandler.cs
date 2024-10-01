using ClinicSystem.Application.Constants.Errors;
using ClinicSystem.Application.Utils;
using ClinicSystem.Domain.Entities;
using ClinicSystem.Domain.Interfaces.Repositories;
using MediatR;

namespace ClinicSystem.Application.CQRS.Triages.Commands.Handlers;

public class SaveTriageInfoHandler(ITriageRepository triageRepository, IServiceRepository serviceRepository) : IRequestHandler<SaveTriageInfo, Result<Guid>>
{
    private readonly ITriageRepository _triageRepository = triageRepository;
    private readonly IServiceRepository _serviceRepository = serviceRepository;

    public async Task<Result<Guid>> Handle(SaveTriageInfo request, CancellationToken cancellationToken)
    {
        try
        {
            Triage entity = new(request.ServiceId, request.SpecialityId, request.Symptoms, request.BloodPressure, request.Weight, request.Height);

            _triageRepository.Add(entity);

            var result = await _serviceRepository.SendToMedicalServiceAsync(request.ServiceId);

            if (!result)
            {
                throw new Exception(ServiceErrors.MedicalStatusChangeError(request.ServiceId));
            }

            return Result<Guid>.Success(entity.Id);
        }
        catch (Exception ex)
        {
            throw new Exception(ExceptionMessages.UnexpectedError(ex.Message));
        }
    }
}
