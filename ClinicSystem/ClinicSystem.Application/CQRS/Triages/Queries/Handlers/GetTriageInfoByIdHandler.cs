using ClinicSystem.Application.Constants.Errors;
using ClinicSystem.Application.Models.Triages.Responses;
using ClinicSystem.Application.Utils;
using ClinicSystem.Domain.Entities;
using ClinicSystem.Domain.Interfaces.Repositories;
using MediatR;

namespace ClinicSystem.Application.CQRS.Triages.Queries.Handlers;

public class GetTriageInfoByIdHandler(ITriageRepository triageRepository) : IRequestHandler<GetTriageInfoById, Result<TriageResponse?>>
{
    private readonly ITriageRepository _triageRepository = triageRepository;

    public async Task<Result<TriageResponse?>> Handle(GetTriageInfoById request, CancellationToken cancellationToken)
    {
        try
        {
            Triage? triage = await _triageRepository.GetByIdAsync(request.Id);

            if (triage == null)
            {
                return Result<TriageResponse?>.Failure(TriageErrors.IdNotFound(request.Id));
            }

            TriageResponse? response = triage;

            return Result<TriageResponse?>.Success(response);
        }
        catch (Exception ex)
        {
            throw new Exception(ExceptionMessages.UnexpectedError(ex.Message));
        }
    }
}