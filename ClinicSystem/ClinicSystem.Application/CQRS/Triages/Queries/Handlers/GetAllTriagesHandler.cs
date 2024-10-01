using ClinicSystem.Application.Constants.Errors;
using ClinicSystem.Application.Models.Triages.Responses;
using ClinicSystem.Application.Utils;
using ClinicSystem.Domain.Entities;
using ClinicSystem.Domain.Interfaces.Repositories;
using MediatR;

namespace ClinicSystem.Application.CQRS.Triages.Queries.Handlers;

public class GetAllTriagesHandler(ITriageRepository triageRepository) : IRequestHandler<GetAllTriages, Result<IEnumerable<TriageResponse?>>>
{
    private readonly ITriageRepository _triageRepository = triageRepository;

    public async Task<Result<IEnumerable<TriageResponse?>>> Handle(GetAllTriages request, CancellationToken cancellationToken)
    {
        try
        {
            IEnumerable<Triage> triages = await _triageRepository.GetAllAsync();

            var response = triages.Select(triage =>
            {
                TriageResponse? triageResponse = triage;
                return triageResponse;
            });

            return Result<IEnumerable<TriageResponse?>>.Success(response ?? []);
        }
        catch (Exception ex)
        {
            throw new Exception(ExceptionMessages.UnexpectedError(ex.Message));
        }
    }
}