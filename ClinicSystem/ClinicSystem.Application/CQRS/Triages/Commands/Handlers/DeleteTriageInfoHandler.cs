using ClinicSystem.Application.Constants.Errors;
using ClinicSystem.Application.Utils;
using ClinicSystem.Domain.Entities;
using ClinicSystem.Domain.Interfaces.Repositories;
using MediatR;

namespace ClinicSystem.Application.CQRS.Triages.Commands.Handlers;

public class DeleteTriageInfoHandler(ITriageRepository triageRepository) : IRequestHandler<DeleteTriageInfo, Result<bool>>
{
    private readonly ITriageRepository _triageRepository = triageRepository;

    public async Task<Result<bool>> Handle(DeleteTriageInfo request, CancellationToken cancellationToken)
    {
        try
        {
            Triage? entity = await _triageRepository.GetByIdAsync(request.Id);

            if (entity == null)
            {
                return Result<bool>.Failure(TriageErrors.IdNotFound(request.Id));
            }

            _triageRepository.Delete(entity!);

            return Result<bool>.Success(true);
        }
        catch (Exception ex)
        {
            throw new Exception(ExceptionMessages.UnexpectedError(ex.Message));
        }
    }
}
