using EvoltisPruebaTecnica.Data.IRepositories;
using EvoltisPruebaTecnica.Model;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public class GenericRepository<T> : IGenericRepository<T> where T : GenericModel
{
    private readonly DbContext _context;
    private readonly DbSet<T> _dbSet;

    public GenericRepository(DbContext context)
    {
        _context = context;
        _dbSet = context.Set<T>();
    }

    public async Task<List<T>> GetAll()
    {
        return await _dbSet.ToListAsync();
    }

    public async Task<T> GetByDni(int dni)
    {
        return await _dbSet.FirstOrDefaultAsync(e => EF.Property<int>(e, "DNI") == dni);
    }

    public async Task<bool> Add(T entity)
    {
        await _dbSet.AddAsync(entity);
        return await _context.SaveChangesAsync() > 0;
    }

    public async Task<bool> Update(T entity)
    {
        _dbSet.Update(entity);
        return await _context.SaveChangesAsync() > 0;
    }

    public async Task<bool> DeleteById(int id)
    {
        var entity = await _dbSet.FindAsync(id);
        if (entity == null)
            return false;

        _dbSet.Remove(entity);
        return await _context.SaveChangesAsync() > 0;
    }
}
