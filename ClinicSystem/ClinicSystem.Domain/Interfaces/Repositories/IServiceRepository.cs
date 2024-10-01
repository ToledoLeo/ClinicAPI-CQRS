using ClinicSystem.Domain.Entities;

namespace ClinicSystem.Domain.Interfaces.Repositories;

public interface IServiceRepository : IGenericRepository<Service>
{
    Task<Service?> GetNextTriageServiceAsync();
    Task<Service?> GetNextMedicalServiceAsync();
    Task<bool> SendToMedicalServiceAsync(Guid id);
    Task<bool> CompleteServiceAsync(Guid id);
}