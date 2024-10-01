using ClinicSystem.Domain.Entities;
using ClinicSystem.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ClinicSystem.Infrastructure.Repositories;

public class GenericRepository<T>(ApplicationDbContext context) : IGenericRepository<T> where T : BaseEntity
{
    private readonly ApplicationDbContext _dbContext = context;
    private DbSet<T> _entity => _dbContext.Set<T>();

    public void Add(T entity)
    {
        _entity.Add(entity);
    }   

    public void Delete(T entity)
    {
        _entity.Remove(entity);
    }        

    public async Task<IEnumerable<T>> GetAllAsync()
    {
        return await _entity.AsNoTracking().ToListAsync() ?? [];
    }
    
    public async Task<T?> GetByIdAsync(Guid id)
    {
        return await _entity.FindAsync(id);
    }
    
    public void Update(T entity)
    {
        _entity.Update(entity);
    }
}