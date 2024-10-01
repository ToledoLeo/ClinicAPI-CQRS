using ClinicSystem.Domain.Entities;
using ClinicSystem.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ClinicSystem.Infrastructure.Repositories;

public class PatientRepository(ApplicationDbContext context) : GenericRepository<Patient>(context), IPatientRepository
{
    private readonly ApplicationDbContext _dbContext = context;
    private DbSet<Patient> _entity => _dbContext.Set<Patient>();

    public async Task<Patient?> GetPatientByEmailAsync(string emailAddress)
    {
        var patient = await _entity.FirstOrDefaultAsync(x => x.Email == emailAddress);

        return patient;
    }
}