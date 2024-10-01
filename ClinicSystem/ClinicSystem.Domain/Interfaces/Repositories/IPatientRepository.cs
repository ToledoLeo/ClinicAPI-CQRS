using ClinicSystem.Domain.Entities;

namespace ClinicSystem.Domain.Interfaces.Repositories;

public interface IPatientRepository : IGenericRepository<Patient>
{
    Task<Patient?> GetPatientByEmailAsync(string emailAddress);
}