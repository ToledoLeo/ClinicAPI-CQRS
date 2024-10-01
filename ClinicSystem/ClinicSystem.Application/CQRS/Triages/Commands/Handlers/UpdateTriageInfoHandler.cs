using ClinicSystem.Application.Constants.Errors;
using ClinicSystem.Application.Utils;
using ClinicSystem.Domain.Entities;
using ClinicSystem.Domain.Interfaces.Repositories;
using MediatR;

namespace ClinicSystem.Application.CQRS.Triages.Commands.Handlers;

public class UpdateTriageInfoHandler(ITriageRepository triageRepository) : IRequestHandler<UpdateTriageInfo, Result<bool>>
{
    private readonly ITriageRepository _triageRepository = triageRepository;

    public async Task<Result<bool>> Handle(UpdateTriageInfo request, CancellationToken cancellationToken)
    {
        try
        {
            Triage? entity = await _triageRepository.GetByIdAsync(request.Id);

            if (entity == null)
            {
                return Result<bool>.Failure(TriageErrors.IdNotFound(request.Id));
            }

            entity!.Update(request.SpecialityId, request.Symptoms, request.BloodPressure, request.Weight, request.Height);

            _triageRepository.Update(entity);

            return Result<bool>.Success(true);
        }
        catch (Exception ex)
        {
            throw new Exception(ExceptionMessages.UnexpectedError(ex.Message));
        }
    }
}