using ClinicSystem.Domain.Entities;
using ClinicSystem.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ClinicSystem.Infrastructure.Repositories;

public class ServiceRepository(ApplicationDbContext context) : GenericRepository<Service>(context), IServiceRepository
{
    private readonly ApplicationDbContext _dbContext = context;
    private DbSet<Service> _entity => _dbContext.Set<Service>();

    public async Task<Service?> GetNextTriageServiceAsync()
    {
        var service = await _entity
            .AsNoTracking()
            .Where(x => x.Status == Domain.Enums.Status.Triage)
            .OrderBy(x => x.ArrivalDate)
            .Include(x => x.Patient)
            .FirstOrDefaultAsync();

        return service;
    }

    public async Task<Service?> GetNextMedicalServiceAsync()
    {
        var service = await _entity
            .AsNoTracking()
            .Where(x => x.Status == Domain.Enums.Status.MedicalService)
            .OrderBy(x => x.ArrivalDate)
            .Include(x => x.Patient)
            .Include(x => x.Triage)
            .FirstOrDefaultAsync();

        return service;
    }

    public async Task<bool> SendToMedicalServiceAsync(Guid id)
    {
        var rowsAffected = await _entity
            .Where(x => x.Id == id)
            .ExecuteUpdateAsync(x => x.SetProperty(p => p.Status, Domain.Enums.Status.MedicalService));

        return rowsAffected > 0;
    }

    public async Task<bool> CompleteServiceAsync(Guid id)
    {
        var rowsAffected = await _entity
            .Where(x => x.Id == id)
            .ExecuteUpdateAsync(x => x.SetProperty(p => p.Status, Domain.Enums.Status.Completed));

        return rowsAffected > 0;
    }
}