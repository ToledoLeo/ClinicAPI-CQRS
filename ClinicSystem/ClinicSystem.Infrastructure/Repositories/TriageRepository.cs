using ClinicSystem.Domain.Entities;
using ClinicSystem.Domain.Interfaces.Repositories;

namespace ClinicSystem.Infrastructure.Repositories;

public class TriageRepository(ApplicationDbContext context) : GenericRepository<Triage>(context), ITriageRepository
{
}